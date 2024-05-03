
using System;
using Scrat;
namespace TestsUnitaires
{
    [TestClass]
    public class UtilsTests
    {
        [TestMethod]
        public void LitteEndianToUintTest()
        {
            byte[] input = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            uint expected = 0x04030201;
            uint actual = Scrat.Utils.LittleEndianToUInt(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LitteEndianToIntTest()
        {
            byte[] input = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            int expected = 0x04030201;
            int actual = Scrat.Utils.LittleEndianToInt(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void LitteEndianToUShortTest()
        {
            byte[] input = new byte[] { 0x01, 0x02 };
            ushort expected = 0x0201;
            ushort actual = Scrat.Utils.LittleEndianToUShort(input);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void IntToLittleEndianTest()
        {
            int input = 0x04030201;
            byte[] expected = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            byte[] actual = Scrat.Utils.IntToLittleEndian(input);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UintToLittleEndianTest()
        {
            uint input = 0x04030201;
            byte[] expected = new byte[] { 0x01, 0x02, 0x03, 0x04 };
            byte[] actual = Scrat.Utils.UIntToLittleEndian(input);
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void UShortToLittleEndianTest()
        {
            ushort input = 0x0201;
            byte[] expected = new byte[] { 0x01, 0x02 };
            byte[] actual = Scrat.Utils.UShortToLittleEndian(input);
            CollectionAssert.AreEqual(expected, actual);
        }
    }

    [TestClass]
    public class  ConvolutionTest
    {
        [TestMethod]

        public void ApplyKernelTest()
        {
            //write the test for convolution
            MyImage image = new MyImage(3, 3);
            image[0, 0] = new Pixel(0, 0, 0);
            image[1, 0] = new Pixel(0, 0, 0);
            image[2, 0] = new Pixel(0, 0, 0);
            image[0, 1] = new Pixel(0, 0, 0);
            image[1, 1] = new Pixel(255, 255, 255);
            image[2, 1] = new Pixel(0, 0, 0);
            image[0, 2] = new Pixel(0, 0, 0);
            image[1, 2] = new Pixel(0, 0, 0);
            image[2, 2] = new Pixel(0, 0, 0);
            float[,] kernel = new float[,] { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
            MyImage expected = new MyImage(3, 3);
            expected[0, 0] = new Pixel(0, 0, 0);
            expected[1, 0] = new Pixel(0, 0, 0);
            expected[2, 0] = new Pixel(0, 0, 0);
            expected[0, 1] = new Pixel(0, 0, 0);
            expected[1, 1] = new Pixel(255, 255, 255);
            expected[2, 1] = new Pixel(0, 0, 0);
            expected[0, 2] = new Pixel(0, 0, 0);
            expected[1, 2] = new Pixel(0, 0, 0);
            expected[2, 2] = new Pixel(0, 0, 0);
            MyImage actual = image.ApplyKernel(kernel);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(expected[i, j], actual[i, j]);
                }
            }
        }
    }

}