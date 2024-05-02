namespace Scrat
{
    class Utils
    {
        /// <summary>
        /// Transforme un tableau d'octets en <see cref="uint"/>
        /// </summary>
        /// <param name="input">Tableau d'octets à convertir</param>
        /// <param name="offset">Position de départ.</param>
        public static uint LittleEndianToUInt(byte[] input, int offset = 0)
        {
            uint ret = 0;
            for (int i = 0; i < 4; i++)
                ret += input[offset + i] * (uint)Math.Pow(256, i);

            return ret;
        }

        /// <summary>
        /// Transforme un tableau d'octets en <see cref="int"/>
        /// </summary>
        /// <param name="input">Tableau d'octets à convertir</param>
        /// <param name="offset">Position de départ</param>
        public static int LittleEndianToInt(byte[] input, int offset = 0)
        {
            int ret = 0;
            for (int i = 0; i < 4; i++)
                ret += input[offset + i] * (int)Math.Pow(256, i);

            return ret;
        }

        /// <summary>
        /// Transforme un tableau d'octets en <see cref="ushort"/>
        /// </summary>
        /// <param name="input">Tableau d'octets à convertir</param>
        /// <param name="offset">Position de départ</param>
        public static ushort LittleEndianToUShort(byte[] input, int offset = 0)
        {
            ushort ret = 0;
            for (int i = 0; i < 2; i++)
                ret += (ushort)(input[offset + i] * Math.Pow(256, i));

            return ret;
        }

        /// <summary>
        /// Transforme un tableau d'octets en <see cref="short"/>
        /// </summary>
        /// <param name="input">Tableau d'octets à convertir</param>
        /// <param name="offset">Position de départ</param>
        public static short LittleEndianToShort(byte[] input, int offset = 0)
        {
            short ret = 0;
            for (int i = 0; i < 2; i++)
                ret += (short)(input[offset + i] * Math.Pow(256, i));

            return ret;
        }

        /// <summary>
        /// Transforme un <see cref="int"/> en tableau d'octets
        /// </summary>
        /// <param name="input">Valeur à convertir</param>
        public static byte[] IntToLittleEndian(int input)
        {
            byte[] ret = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                ret[i] = (byte)(input % 256);
                input /= 256;
            }

            return ret;
        }

        /// <summary>
        /// Transforme un <see cref="uint"/> en tableau d'octets
        /// </summary>
        /// <param name="input">Valeur à convertir</param>
        public static byte[] UIntToLittleEndian(uint input)
        {
            byte[] ret = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                ret[i] = (byte)(input % 256);
                input >>= 8; // value /= 256;
            }

            return ret;
        }

        /// <summary>
        /// Transforme un <see cref="short"/> en tableau d'octets.
        /// </summary>
        /// <param name="input">short à convertir.</param>
        public static byte[] ShortToLittleEndian(short input)
        {
            byte[] ret = new byte[2];
            for (int i = 0; i < 2; i++)
            {
                ret[i] = (byte)(input % 256);
                input /= 256;
            }

            return ret;
        }

        /// <summary>
        /// Transforme un <see cref="ushort"/> en tableau d'octets.
        /// </summary>
        /// <param name="input">ushort à convertir.</param>
        public static byte[] UShortToLittleEndian(ushort input)
        {
            byte[] ret = new byte[2];
            for (int i = 0; i < 2; i++)
            {
                ret[i] = (byte)(input % 256);
                input /= 256;
            }

            return ret;
        }
    }
}