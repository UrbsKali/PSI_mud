﻿using System.ComponentModel;

namespace Scrat
{
    /// <summary>
    /// Méthodes d'application de convolution sur une <see cref="MyImage"/>
    /// </summary>
    public static class Convolution
    {
        private static Dictionary<Kernel, float[,]> kernels = new Dictionary<Kernel, float[,]>
        {
            {
                Kernel.EdgeDetection, new float[,]
                {
                     { -1, -1, -1 },
                     { -1,  8, -1 },
                     { -1, -1, -1 }
                }
            },
            {
                Kernel.BoxBlur, new float[,]
                {
                    { 1/9f, 1/9f, 1/9f },
                    { 1/9f, 1/9f, 1/9f },
                    { 1/9f, 1/9f, 1/9f }
                }
            },
            {
                Kernel.GaussianBlur3x3, new float[,]
                {
                    { 1/16f, 2/16f, 1/16f },
                    { 2/16f, 4/16f, 2/16f },
                    { 1/16f, 2/16f, 1/16f }
                }
            },
            {
                Kernel.GaussianBlur5x5, new float[,]
                {
                    {  1/256f,  4/256f,  6/256f,  4/256f, 1/256f },
                    {  4/256f, 16/256f, 24/256f, 16/256f, 4/256f },
                    {  6/256f, 24/256f, 36/256f, 24/256f, 6/256f },
                    {  4/256f, 16/256f, 24/256f, 16/256f, 4/256f },
                    {  1/256f,  4/256f,  6/256f,  4/256f, 1/256f }
                }
            }
        };

        /// <summary>
        /// Applique une convolution à une instance d'<see cref="MyImage"/> donnée.
        /// </summary>
        /// <param name="image"><see cref="MyImage"/> sur laquelle va être appliquée le noyau.</param>
        /// <param name="kernel">Noyau à appliquer.</param>
        /// <param name="origin">Origine du noyau.</param>
        /// <param name="edgeProcessing">Gestion des bords de l'image.</param>
        /// <returns></returns>
        public static MyImage ApplyKernel(this MyImage image, Kernel kernel, KernelOrigin origin = KernelOrigin.Center, EdgeProcessing edgeProcessing = EdgeProcessing.KernelCrop)
        {
            return ApplyKernel(image, kernels[kernel], origin, edgeProcessing);
        }

        /// <summary>
        /// Applique une convolution à une instance d'MyImage donnée.
        /// </summary>
        /// <param name="image"><see cref="MyImage"/> sur laquelle va être appliquée le noyau.</param>
        /// <param name="kernel">Noyau à appliquer.</param>
        /// <param name="origin">Origine du Kernel.</param>
        /// <param name="edgeProcessing">Gestion des bords de l'image.</param>
        /// <returns></returns>
        public static MyImage ApplyKernel(this MyImage image, float[,] kernel, KernelOrigin origin = KernelOrigin.Center, EdgeProcessing edgeProcessing = EdgeProcessing.KernelCrop)
        {
            if (kernel == null)
                throw new ArgumentException("kernel", "kernel cannot be null!");

            int kernelH = kernel.GetLength(0);
            int kernelW = kernel.GetLength(1);

            int imageHeight = image.Height;
            int imageWidth = image.Width;

            if (origin == KernelOrigin.Center && (kernelH % 2 != 1 || kernelW % 2 != 1))
            {
                origin = KernelOrigin.TopLeft;
            }

            int halfKerH = kernelH / 2;
            int halfKerW = kernelW / 2;

            int resultH = imageHeight;
            int resultW = imageWidth;
            if (edgeProcessing == EdgeProcessing.Crop)
            {
                resultH -= kernelH - 1;
                resultW -= kernelW - 1;
            }

            if (resultH <= 0 || resultW <= 0)
                throw new ArithmeticException("result of negative size!");

            MyImage result = new MyImage(resultW, resultH);

            for (int y = 0; y < resultH; y++)
            {
                for (int x = 0; x < resultW; x++)
                {
                    int acc_r = 0;
                    int acc_g = 0;
                    int acc_b = 0;

                    for (int dy = 0; dy < kernelH; dy++)
                    {
                        for (int dx = 0; dx < kernelW; dx++)
                        {
                            int pos_dy = y + dy, pos_dx = x + dx;
                            if (origin == KernelOrigin.Center && edgeProcessing != EdgeProcessing.Crop)
                            {
                                pos_dy -= halfKerH;
                                pos_dx -= halfKerW;
                            }

                            if (pos_dy < 0 || pos_dy >= imageHeight)
                            {
                                switch (edgeProcessing)
                                {
                                    // no need for crop
                                    case EdgeProcessing.Extend:
                                        if (pos_dy < 0)
                                        {
                                            pos_dy = 0;
                                        }
                                        else
                                        {
                                            pos_dy = imageHeight - 1;
                                        }
                                        break;
                                    case EdgeProcessing.KernelCrop:
                                        continue; // skip this kernel position
                                    case EdgeProcessing.Mirror:
                                        if (pos_dy < 0)
                                        {
                                            pos_dy = -pos_dy;
                                        }
                                        else
                                        {
                                            pos_dy = imageHeight - (pos_dy % imageHeight);
                                        }
                                        break;
                                    case EdgeProcessing.Wrap:
                                        while (pos_dy < 0)
                                            pos_dy += imageHeight;
                                        pos_dy %= imageHeight;
                                        break;
                                }
                            }

                            if (pos_dx < 0 || pos_dx >= imageWidth)
                            {
                                switch (edgeProcessing)
                                {
                                    // no need for crop
                                    case EdgeProcessing.Extend:
                                        if (pos_dx < 0)
                                        {
                                            pos_dx = 0;
                                        }
                                        else
                                        {
                                            pos_dx = imageWidth - 1;
                                        }
                                        break;
                                    case EdgeProcessing.KernelCrop:
                                        continue; // skip this kernel position
                                    case EdgeProcessing.Mirror:
                                        if (pos_dx < 0)
                                        {
                                            pos_dx = -pos_dx;
                                        }
                                        else
                                        {
                                            pos_dx = imageWidth - (pos_dx % imageWidth);
                                        }
                                        break;
                                    case EdgeProcessing.Wrap:
                                        while (pos_dx < 0)
                                            pos_dx += imageWidth;
                                        pos_dx %= imageWidth;
                                        break;
                                }
                            }

                            float factor = kernel[dy, dx];
                            Pixel pixel = image[pos_dx, pos_dy];

                            acc_r += (int)(factor * pixel.R);
                            acc_g += (int)(factor * pixel.G);
                            acc_b += (int)(factor * pixel.B);
                        }
                    }

                    acc_r = Math.Min(255, Math.Max(0, acc_r));
                    acc_g = Math.Min(255, Math.Max(0, acc_g));
                    acc_b = Math.Min(255, Math.Max(0, acc_b));

                    result[x, y] = new Pixel((byte)acc_r, (byte)acc_g, (byte)acc_b);
                }
            }

            return result;
        }

        public enum EdgeProcessing
        {
            Extend, Wrap, Mirror, Crop, KernelCrop
        }

        public enum KernelOrigin
        {
            Center, TopLeft
        }

        public enum Kernel
        {

            [Description("Détection des contours")]
            EdgeDetection,

            [Description("Flou simple")]
            BoxBlur,

            [Description("Flou de Gauss 3x3")]
            GaussianBlur3x3,

            [Description("Flou de Gauss 5x5")]
            GaussianBlur5x5
        }
    }
}