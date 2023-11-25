namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            SortedDictionary<string, List<FileInfo>> directoryInfo
                = new SortedDictionary<string, List<FileInfo>>();

            string[] files = Directory.GetFiles(inputFolderPath);

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                if (!directoryInfo.ContainsKey(fileInfo.Extension))
                {
                    directoryInfo[fileInfo.Extension] = new List<FileInfo>();
                }

                directoryInfo[fileInfo.Extension].Add(fileInfo);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var extensionFile in directoryInfo.OrderByDescending(value => value.Value.Count))
            {
                sb.AppendLine(extensionFile.Key);

                foreach (var file in extensionFile.Value.OrderBy(x => x.Length))
                {
                    sb.AppendLine($"--{file.Name} - {(double)file.Length / 1024:f3}kb");
                }
            }

            return sb.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(filePath, textContent);
        }
    }
}
