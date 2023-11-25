﻿namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }

            Directory.CreateDirectory(outputPath);

            string[] fileFromInput = Directory.GetFiles(inputPath);

            foreach (var file in fileFromInput)
            {
                string fileName = Path.GetFileName(file);

                string fullFile = Path.Combine(outputPath, fileName);

                File.Copy(fileName, outputPath);
            }
        }
    }
}
