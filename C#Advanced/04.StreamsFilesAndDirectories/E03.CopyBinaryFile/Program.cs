﻿namespace CopyBinaryFile
{
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream reader = new FileStream(inputFilePath, FileMode.Open))
            {
                using (FileStream writer = new FileStream(outputFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    int size = 0;

                    while ((size = reader.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        writer.Write(buffer, 0, size);
                    }
                }
            }


        }
    }
}
