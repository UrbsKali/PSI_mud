namespace Scrat
{
    /// <summary>
    /// Représente une couleur selon 3 composantes RGB entre 0 et 255
    /// </summary>
    public class Pixel
    {
        byte r;
        byte g;
        byte b;

        public byte R => r;
        public byte G => g;
        public byte B => b;

        /// <summary>
        /// Calcule la valeur en niveau de gris de ce pixel
        /// </summary>
        public Pixel Greyscale()
        {
            return new Pixel((byte)((r + g + b) / 3));
        }

        /// <summary>
        /// Crée un <see cref="Pixel"/> selon ses 3 composantes RGB.
        /// </summary>
        public Pixel(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
        }

        /// <summary>
        /// Crée un <see cref="Pixel"/> noir (3 composantes RGB à 0).
        /// </summary>
        public Pixel() : this(0, 0, 0) { }

        /// <summary>
        /// Crée un <see cref="Pixel"/> selon son niveau de gris <paramref name="val"/> entre 0 et 255.
        /// </summary>
        /// <param name="val">Niveau de gris.</param>
        public Pixel(byte val) : this(val, val, val) { }

        /// <summary>
        /// Crée une copie d'un <see cref="Pixel"/> déjà instancié <paramref name="p"/>.
        /// </summary>
        /// <param name="p">Instance à copier.</param>
        /// <seealso cref="Copy"/>
        public Pixel(Pixel p)
        {
            r = p.r;
            g = p.g;
            b = p.b;
        }

        /// <summary>
        /// Crée une copie du <see cref="Pixel"/>.
        /// </summary>
        /// <seealso cref="Pixel(Pixel)"/>
        public Pixel Copy()
        {
            return new Pixel(this);
        }

        /// <summary>
        /// Représentation textuelle du <see cref="Pixel"/> (composantes RGB).
        /// </summary>
        public override string ToString()
        {
            return "(" + R + ", " + G + ", " + B + ")";
        }

        /// <summary>
        /// Compare deux <see cref="Pixel"/> pour vérifier leur égalité (composantes R, G et B identiques).
        /// </summary>
        /// <seealso cref="Equals(object)"/>
        public static bool operator ==(Pixel a, Pixel b)
        {
            return a.r == b.r && a.g == b.g && a.b == b.b;
        }

        /// <summary>
        /// Compare deux <see cref="Pixel"/> pour vérifier leur différence (composantes R, G ou B différentes).
        /// </summary>
        /// <seealso cref="operator ==(Pixel, Pixel)"/>
        public static bool operator !=(Pixel a, Pixel b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Compare deux <see cref="Pixel"/> pour vérifier leur égalité (composantes R, G et B identiques).
        /// </summary>
        /// <seealso cref="operator ==(Pixel, Pixel)"/>
        public override bool Equals(object p)
        {
            return p is Pixel && this == (Pixel)p;
        }
    }
}