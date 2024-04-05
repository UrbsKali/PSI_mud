using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Scrat
{
    /// <summary>
    /// Représente une image de profondeur 24-bits (composantes R, G et B).
    /// </summary>
    public class MyImage                                // en hexadécimal
    {
        public const int OFFSET_TYPE = 0x00;            // type de l'image
        public const int OFFSET_FILESIZE = 0x02;        // taille totale du fichier (en octets)
        public const int OFFSET_STARTOFFSET = 0x0a;     // position du premier pixel dans le fichier (en octets)

        public const int OFFSET_INFOHEADERSIZE = 0x0e;  // taille de la deuxième partie de l'entête
        public const int OFFSET_WIDTH = 0x12;           // largeur de l'image en pixels
        public const int OFFSET_HEIGHT = 0x16;          // hauteur de l'image en pixels
        public const int OFFSET_COLORPLANES = 0x1a;     // vaudra toujours 1 pour un bitmap
        public const int OFFSET_COLORDEPTH = 0x1c;      // nombre de bits par pixel (souvent 24 car 3 octets * 8 bits = 24)

        byte[] rawHeader;                               // création du tableau de bytes/octets du header
        byte[] rawPixels;                               // création du tableau de bytes/octets de l'image

        public string Type => Encoding.ASCII.GetString(rawHeader.ExtractBytes(2, OFFSET_TYPE));     // Encoding.ASCII.GetString est une méthode permettant de transformer un tableau d'octets en string
        public uint FileSize => Utils.LittleEndianToUInt(rawHeader, OFFSET_FILESIZE);
        public uint StartOffset => Utils.LittleEndianToUInt(rawHeader, OFFSET_STARTOFFSET);

        public uint InfoHeaderSize => Utils.LittleEndianToUInt(rawHeader, OFFSET_INFOHEADERSIZE);
        public int Width => Utils.LittleEndianToInt(rawHeader, OFFSET_WIDTH);
        public int Height => Utils.LittleEndianToInt(rawHeader, OFFSET_HEIGHT);
        public ushort ColorPlanes => Utils.LittleEndianToUShort(rawHeader, OFFSET_COLORPLANES);
        public ushort ColorDepth => Utils.LittleEndianToUShort(rawHeader, OFFSET_COLORDEPTH);
        public int Stride => (Width * ColorDepth / 8 + 3) / 4 * 4; // by dividing then multiplying, we floor to the nearest smallest integer, nombre d'octets pour décrire une ligne de pixels

        /*public ReadOnlyCollection<byte> RawHeader => Array.AsReadOnly(rawHeader);
        public ReadOnlyCollection<byte> RawPixels => Array.AsReadOnly(rawPixels);*/

        public byte[] RawHeader => rawHeader;
        public byte[] RawPixels => rawPixels;

        /// <summary>
        /// Créé une instance d'<see cref="MyImage"/> à partir d'un fichier référencé par <paramref name="filename"/>.
        /// </summary>
        /// <param name="filename">Chemin de l'image à ouvrir.</param>
        public MyImage(string filename)
        {
            using (FileStream stream = File.OpenRead(filename))     // using appelle stream.Close() automatiquement
            {
                ConsumeStream(stream);
            }
        }

        /// <summary>
        /// Créé une instance d'<see cref="MyImage"/> dont le contenu est recupéré depuis le flux <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">Un <see cref="Stream"/> contenant les informations sur l'image.</param>
        public MyImage(Stream stream)
        {
            ConsumeStream(stream);
        }

        /// <summary>
        /// Consomme le flux <paramref name="stream"/> et remplit les attributs de cette <see cref="MyImage"/>.
        /// </summary>
        /// <param name="stream">Le <see cref="Stream"/> depuis lequel récupérer les attributs.</param>
        /// <exception cref="FormatException">Le flux ne contient pas une image BMP reconnaissable par <i>KayoEditor</i>.</exception>
        private void ConsumeStream(Stream stream)
        {
            rawHeader = stream.ReadBytes(54);

            if (Type != "BM")
                throw new FormatException("invalid magic file type!");

            if (ColorDepth != 24)
                throw new FormatException("KayoEditor can only load images with a depth of 24 bits");

            rawPixels = stream.ReadBytes((int)(FileSize - StartOffset));
        }

        /// <summary>
        /// Créé une instance d'<see cref="MyImage"/> à partir d'une hauteur <paramref name="height"/> et d'une largeur <paramref name="width"/>.
        /// <br/>L'image est automatiquement remplie de noir (composantes à 0).
        /// </summary>
        /// <param name="width">Largeur de l'image.</param>
        /// <param name="height">Hauteur de l'image.</param>
        public MyImage(int width, int height)
        {
            rawHeader = new byte[54];

            rawHeader.InsertBytes(Encoding.ASCII.GetBytes("BM"), OFFSET_TYPE);      // Encoding.ASCII.GetBytes est une méthode permettant de transformer un string en tableau octets
            rawHeader.InsertBytes(Utils.UIntToLittleEndian((uint)rawHeader.Length), OFFSET_STARTOFFSET);

            rawHeader.InsertBytes(Utils.UShortToLittleEndian(0x28), OFFSET_INFOHEADERSIZE); // hexadécimal car adresse
            rawHeader.InsertBytes(Utils.IntToLittleEndian(width), OFFSET_WIDTH);
            rawHeader.InsertBytes(Utils.IntToLittleEndian(height), OFFSET_HEIGHT);
            rawHeader.InsertBytes(Utils.UShortToLittleEndian(1), OFFSET_COLORPLANES);
            rawHeader.InsertBytes(Utils.UShortToLittleEndian(24), OFFSET_COLORDEPTH);

            rawPixels = new byte[height * Stride];

            rawHeader.InsertBytes(Utils.UIntToLittleEndian((uint)(rawHeader.Length + rawPixels.Length)), OFFSET_FILESIZE);
        }

        /// <summary>
        /// Créé une copie d'une instance d'<see cref="MyImage"/>.
        /// </summary>
        /// <param name="original"><see cref="MyImage"/> à copier.</param>
        public MyImage(MyImage original)
        {
            rawHeader = new byte[original.rawHeader.Length];
            Array.Copy(original.rawHeader, rawHeader, rawHeader.Length);        // Array.Copy agit comme une boucle for afin de copier le tableau

            rawPixels = new byte[original.rawPixels.Length];
            Array.Copy(original.rawPixels, rawPixels, rawPixels.Length);
        }

        /// <summary>
        /// Créé une copie de cette instance d'<see cref="MyImage"/>.
        /// </summary>
        /// <returns>Une nouvelle instance d'<see cref="MyImage"/> avec les même <see cref="Pixel"/>s.</returns>
        /// <seealso cref="MyImage(MyImage)"/>
        public MyImage Copy()
        {
            return new MyImage(this);
        }

        /// <summary>
        /// Calcule la position du 1er octet représentant le pixel à la position (<paramref name="x"/>, <paramref name="y"/>).
        /// </summary>
        /// <param name="x">Position <i>x</i> du pixel.</param>
        /// <param name="y">Position <i>x</i> du pixel.</param>
        /// <returns>La position du 1er octet représentant ce pixel.</returns>
        private int _position(int x, int y) => x * 3 + (Height - y - 1) * Stride;           // position du premier octet décrivant ce pixel

        /// <summary>
        /// Récupère le <see cref="Pixel"/> à une position donnée. 
        /// </summary>
        /// <param name="x">Position <i>x</i>.</param>
        /// <param name="y">Position <i>y</i>.</param>
        /// <returns>Le <see cref="Pixel"/> contenant la couleur présente à la position donnée.</returns>
        public Pixel this[int x, int y] // la propriété c'est l'instance elle-même      similaire à static bool operator ==(...)
        { // imageOriginale[x, y] <=> imageOriginale._pixels[y, x]
            get
            {
                int position = _position(x, y);
                return new Pixel(rawPixels[position + 2], rawPixels[position + 1], rawPixels[position + 0]);
            }

            set
            {
                int position = _position(x, y);
                rawPixels[position + 2] = value.R;
                rawPixels[position + 1] = value.G;
                rawPixels[position + 0] = value.B;
            }
        }

        /// <summary>
        /// Sauvegarde cette <see cref="MyImage"/> dans le fichier indiqué par <paramref name="filename"/>. 
        /// </summary>
        /// <param name="filename">Chemin de l'image à sauvegarder.</param>
        public void Save(string filename)
        {
            using (FileStream stream = File.OpenWrite(filename))
            {
                stream.Write(rawHeader, 0, rawHeader.Length);
                stream.Write(rawPixels, 0, rawPixels.Length);
            }
        }

        /// <summary>
        /// Transforme cette <see cref="MyImage"/> en nuances de gris (cette méthode créé une copie).
        /// </summary>
        /// <returns>Une copie en nuances de gris de cette <see cref="MyImage"/>.</returns>
        public MyImage Greyscale()
        {
            MyImage result = this.Copy();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    result[x, y] = this[x, y].Greyscale();
                }
            }

            return result;
        }

        /// <summary>
        /// Transforme cette <see cref="MyImage"/> en noir et blanc (cette méthode créé une copie).
        /// </summary>
        /// <returns>Une copie en noir et blanc de cette <see cref="MyImage"/>.</returns>
        public MyImage BlackAndWhite()
        {
            MyImage result = this.Copy();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    result[x, y] = this[x, y].Greyscale().R > 127 ? new Pixel(255) : new Pixel(0);
                }
            }

            return result;
        }

        /// <summary>
        /// Obtient le négatif de cette <see cref="MyImage"/> (cette méthode créé une copie).
        /// </summary>
        /// <returns>La copie en négatif de cette <see cref="MyImage"/>.</returns>
        public MyImage Negative()
        {
            MyImage result = this.Copy();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Pixel pixel = this[x, y];
                    result[x, y] = new Pixel((byte)(255 - pixel.R), (byte)(255 - pixel.G), (byte)(255 - pixel.B));
                }
            }

            return result;
        }

        /// <summary>
        /// Inverse les composantes R et B de chaque <see cref="Pixel"/> de l'image (cette méthode créé une copie).
        /// </summary>
        /// <returns>Une copie de cette <see cref="MyImage"/> avec les composantes R et B inversées.</returns>
        public MyImage Invert()
        {
            MyImage result = this.Copy();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Pixel pixel = this[x, y];
                    result[x, y] = new Pixel(pixel.B, pixel.G, pixel.R);
                }
            }

            return result;
        }

        /// <summary>
        /// Cache une image <paramref name="imageToHide"/> dans cette <see cref="MyImage"/>.
        /// </summary>
        /// <param name="imageToHide">Image à cacher.</param>
        /// <returns>Une copie de l'<see cref="MyImage"/> originale contenant les informations de <paramref name="imageToHide"/>.</returns>
        public MyImage HideImageInside(MyImage imageToHide)
        {
            MyImage result = this.Copy();

            if (this.Width < imageToHide.Width || this.Height < imageToHide.Height)
            {
                float scaleX = imageToHide.Width / this.Width;
                float scaleY = imageToHide.Height / this.Height;

                float scale = Math.Max(scaleX, scaleY);

                result = result.Scale(scale);
            }

            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    Pixel toHide = new Pixel();
                    if (x < imageToHide.Width && y < imageToHide.Height)
                    {
                        toHide = imageToHide[x, y];
                    }

                    Pixel pixel = result[x, y];
                    byte r = (byte)((pixel.R & 0b11110000) + ((toHide.R >> 4) & 0b00001111));
                    byte g = (byte)((pixel.G & 0b11110000) + ((toHide.G >> 4) & 0b00001111));
                    byte b = (byte)((pixel.B & 0b11110000) + ((toHide.B >> 4) & 0b00001111));

                    result[x, y] = new Pixel(r, g, b);
                }
            }

            return result;
        }

        /// <summary>
        /// Produit l'histogramme de cette <see cref="MyImage"/>.
        /// </summary>
        /// <param name="channel_r">Inclure la composante rouge.</param>
        /// <param name="channel_g">Inclure la composante verte.</param>
        /// <param name="channel_b">Inclure la composante bleue.</param>
        /// <returns>Un histogramme de cette <see cref="MyImage"/>.</returns>
        public MyImage Histogram(bool channel_r = true, bool channel_g = true, bool channel_b = true)
        {
            MyImage result = new MyImage(256, 100);

            int[] r = new int[256];
            int[] g = new int[256];
            int[] b = new int[256];

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Pixel pixel = this[x, y];
                    r[pixel.R]++;
                    g[pixel.G]++;
                    b[pixel.B]++;
                }
            }

            int max_r = channel_r ? r.Max() : 1;
            int max_g = channel_g ? g.Max() : 1;
            int max_b = channel_b ? b.Max() : 1;

            int max = Math.Max(max_r, Math.Max(max_g, max_b));

            int[] perc_r = new int[256];
            int[] perc_g = !channel_g ? null : g.Select(x => x * 100 / max).ToArray(); // sélect = boucle for pour chaque valeur du tableau
            int[] perc_b = !channel_b ? null : b.Select(x => x * 100 / max).ToArray(); // on transforme chaque valeur en pourcentage par rapport au max

            if (channel_r)   // alternative au Select
            {
                for (int i = 0; i < 256; i++)
                {
                    perc_r[i] = r[i] * 100 / max;
                }
            }

            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    result[x, 99 - y] = new Pixel((byte)(channel_r && y < perc_r[x] * 2 ? 255 : 0), (byte)(channel_g && y < perc_g[x] * 2 ? 255 : 0), (byte)(channel_b && y < perc_b[x] * 2 ? 255 : 0));
                }
            }

            return result;
        }

        /// <summary>
        /// Récupère l'image cachée dans cette <see cref="MyImage"/> par <see cref="HideImageInside(MyImage)"/>.
        /// </summary>
        /// <returns>L'image cachée par <see cref="HideImageInside(MyImage)"/>.</returns>
        public MyImage GetHiddenImage()
        {
            MyImage result = this.Copy();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Pixel pixel = this[x, y];
                    result[x, y] = new Pixel((byte)(pixel.R << 4), (byte)(pixel.G << 4), (byte)(pixel.B << 4));
                }
            }

            return result;
        }

        /// <summary>
        /// Tourne l'instance de l'<see cref="MyImage"/> selon <paramref name="angle"/>.
        /// </summary>
        /// <param name="angle">Angle de la rotation en degrés.</param>
        /// <returns>Une copie de cette <see cref="MyImage"/> tournée de <paramref name="angle"/> degrés.</returns>
        public MyImage Rotate(int angle)
        {
            double rad = angle * (double)Math.PI / 180;
            double cos = (double)Math.Cos(rad);
            double sin = (double)Math.Sin(rad);

            int newWidth = (int)(Width * Math.Abs(cos) + Height * Math.Abs(sin));
            int newHeight = (int)(Width * Math.Abs(sin) + Height * Math.Abs(cos));

            MyImage result = new MyImage(newWidth, newHeight);

            for (int x = 0; x < newWidth; x++)
            {
                for (int y = 0; y < newHeight; y++)
                {
                    double newX = (x - newWidth / 2) * cos - (y - newHeight / 2) * sin + Width / 2;
                    double newY = (x - newWidth / 2) * sin + (y - newHeight / 2) * cos + Height / 2;

                    if (newX >= 0 && newX < Width && newY >= 0 && newY < Height)
                    {
                        result[x, y] = this[(int)newX, (int)newY];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Agrandit/rétrécit cette <see cref="MyImage"/> selon le facteur <paramref name="scale"/>.
        /// </summary>
        /// <param name="scale">Facteur d'agrandissement/de rétrécissement.</param>
        /// <param name="reduceAntiAliasing">Applique un anti-aliasing en cas de rétrécissement (<paramref name="scale"/> < 1).</param>
        /// <returns>Une copie agrandie/rétrécie de cette <see cref="MyImage"/>.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Si <paramref name="scale"/> est inférieur ou égal à 0.</exception>
        public MyImage Scale(float scale, bool reduceAntiAliasing = true)
        {
            if (scale == 0)
                throw new ArgumentOutOfRangeException("scale", "scale must not be 0");

            if (scale < 0)
                throw new ArgumentOutOfRangeException("scale", "scale must be a positive number");

            MyImage source = this.Copy();

            if (scale == 1)
                return source;

            int newWidth = (int)(Width * scale);
            int newHeight = (int)(Height * scale);

            if (newWidth == 0)
                newWidth = 1;

            if (newHeight == 0)
                newHeight = 1;

            if (scale < 1 && reduceAntiAliasing)
            {
                // si on réduit, on met dans les pixels en haut à gauche de chaque groupe la moyenne des pixels du groupe

                int convolSize = (int)Math.Ceiling(1 / scale);
                float[,] kernel = new float[convolSize, convolSize];
                float coef = 1f / kernel.Length;    // 1f = 1 float

                for (int y = 0; y < convolSize; y++)
                {
                    for (int x = 0; x < convolSize; x++)
                    {
                        kernel[y, x] = coef;
                    }
                }

                source = source.ApplyKernel(kernel, Convolution.KernelOrigin.TopLeft, Convolution.EdgeProcessing.Extend);
            }

            MyImage result = new MyImage(newWidth, newHeight);

            for (int x = 0; x < newWidth; x++)
            {
                for (int y = 0; y < newHeight; y++)
                {
                    result[x, y] = new Pixel(source[(int)(x / scale), (int)(y / scale)]);     // 1/2 = 0 ; 3/2 = 1
                }
            }

            return result;
        }

        /// <summary>
        /// Applique un effet miroir sur cette <see cref="MyImage"/> (cette méthode créé une copie).
        /// </summary>
        /// <param name="mode">Direction de l'effet.</param>
        /// <returns>Une copie de cette <see cref="MyImage"/> avec l'effet miroir sur la direction <paramref name="mode"/>.</returns>
        public MyImage Flip(FlipMode mode)
        {
            MyImage result = this.Copy();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    int nx = x;
                    int ny = y;

                    if (/* vrai quand on change que x ou les 2 coords */mode == FlipMode.FlipX || mode == FlipMode.FlipBoth)
                        nx = Width - x - 1;

                    if (/* vrai quand on change que y ou les 2 coords */mode == FlipMode.FlipY || mode == FlipMode.FlipBoth)
                        ny = Height - y - 1;

                    result[nx, ny] = new Pixel(this[x, y]);
                }
            }

            return result;
        }

        /// <summary>
        /// Remplace une couleur <paramref name="input"/> par une autre couleur <paramref name="output"/> (cette méthode créé une copie).
        /// </summary>
        /// <param name="input">La couleur à remplacer.</param>
        /// <param name="output">Nouvelle couleur de remplacement.</param>
        /// <returns>Une copie de cette <see cref="MyImage"/> ne contenant plus la couleur <paramref name="input"/>.</returns>
        public MyImage ReplaceColor(Pixel input, Pixel output)
        {
            MyImage result = this.Copy();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (this[x, y] == input)
                        result[x, y] = output;
                }
            }

            return result;
        }

        private static Pixel BackgroundStickerPixel = new Pixel(230, 14, 249);
        /// <summary>
        /// Ajoute un <paramref name="sticker"/> sur cette <see cref="MyImage"/> (cette méthode créé une copie).
        /// </summary>
        /// <param name="sticker"><see cref="MyImage"/> à rajouter.</param>
        /// <returns>Une copie de cette <see cref="MyImage"/> contenant le sticker.</returns>
        public MyImage AddSticker(MyImage sticker)
        {
            MyImage result = this.Copy();
            sticker = sticker.Scale((float)this.Width / sticker.Width, false);

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Pixel pixel = BackgroundStickerPixel;
                    if (x < sticker.Width && y < sticker.Height)
                        pixel = sticker[x, y];

                    if (pixel == BackgroundStickerPixel)
                    {
                        pixel = this[x, y];
                    }

                    result[x, y] = pixel;
                }
            }

            return result;
        }

        /// <summary>
        /// Vérifie l'égalité entre 2 <see cref="MyImage"/> (taille et <see cref="Pixel"/>s identiques).
        /// </summary>
        /// <seealso cref="Equals(object)"/>
        public static bool operator ==(MyImage a, MyImage b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            if (a.Width != b.Width || a.Height != b.Height)
                return false;

            for (int x = 0; x < a.Width; x++)
            {
                for (int y = 0; y < a.Height; y++)
                {
                    if (a[x, y] != b[x, y])
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Vérifie l'inégalité entre 2 <see cref="MyImage"/> (taille ou <see cref="Pixel"/>s différents).
        /// </summary>
        /// <seealso cref="operator ==(MyImage, MyImage)"/>
        public static bool operator !=(MyImage a, MyImage b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Vérifie l'égalité de cette <see cref="MyImage"/> avec <paramref name="other"/>.
        /// </summary>
        /// <seealso cref="operator ==(MyImage, MyImage)"/>
        public override bool Equals(object other)
        {
            return other is MyImage && this == (MyImage)other;
        }

        public override int GetHashCode()
        {
            // méthode pour enlever le warning à cause des opérateurs == et !=.
            return base.GetHashCode();
        }
    }


    public enum FlipMode
    {
        [Description("Inverser les X")]
        FlipX,

        [Description("Inverser les Y")]
        FlipY,

        [Description("Inverser les 2 axes")]
        FlipBoth
    }
}