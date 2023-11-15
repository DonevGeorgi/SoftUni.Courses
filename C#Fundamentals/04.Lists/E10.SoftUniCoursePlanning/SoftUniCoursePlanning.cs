using System;
using System.Collections.Generic;
using System.Linq;

namespace E10.SoftUniCoursePlanning
{
    class SoftUniCoursePlanning
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "course start")
            {
                string[] intputArgs = input.Split(":");

                if (intputArgs[0] == "Add")
                {
                    string lessonTitle = intputArgs[1];

                    if (!list.Contains(lessonTitle))
                    {
                        list.Add(lessonTitle);
                    }

                }
                else if (intputArgs[0] == "Insert")
                {
                    string lessonTitle = intputArgs[1];
                    int index = int.Parse(intputArgs[2]);

                    if (index < 0 || index >= list.Count)
                    {
                        continue;
                    }
                    else if (!list.Contains(lessonTitle))
                    {
                        list.Insert(index, lessonTitle);
                    }

                }
                else if (intputArgs[0] == "Remove")
                {
                    string lessonTitle = intputArgs[1];

                    if (list.Contains(lessonTitle))
                    {
                        list.Remove(lessonTitle);
                    }
                    else if (list.Contains(lessonTitle + "-Exercise"))
                    {
                        list.Remove(lessonTitle + "-Exercise");
                    }

                }
                else if (intputArgs[0] == "Swap")
                {
                    string lessonTitle1 = intputArgs[1];
                    string lessonTitle2 = intputArgs[2];
                    int index1 = list.IndexOf(lessonTitle1);
                    int index2 = list.IndexOf(lessonTitle2);

                    if (list.Contains(lessonTitle1) && list.Contains(lessonTitle2))
                    {
                        string tempLessonTitle1 = list.ElementAt(index1);
                        list[index1] = list[index2];
                        list[index2] = tempLessonTitle1;
                    }

                    if (list.Contains(lessonTitle1 + "-Exercise") && list.Contains(list[index1]))
                    {
                        index1 = list.IndexOf(lessonTitle1);
                        list.Remove(lessonTitle1 + "-Exercise");
                        list.Insert(index1 + 1, lessonTitle1 + "-Exercise");
                    }
                    else if (list.Contains(lessonTitle2 + "-Exercise") && list.Contains(list[index2]))
                    {
                        index2 = list.IndexOf(lessonTitle2);
                        list.Remove(lessonTitle2 + "-Exercise");
                        list.Insert(index2 + 1, lessonTitle2 + "-Exercise");
                    }

                }
                else if (intputArgs[0] == "Exercise")
                {
                    string lessonTitle = intputArgs[1];

                    if (list.Contains(lessonTitle) && !list.Contains(lessonTitle + "-Exercise"))
                    {
                        int index = list.IndexOf(lessonTitle);
                        list.Insert(index + 1, lessonTitle + "-Exercise");
                    }
                    else if (!list.Contains(lessonTitle))
                    {
                        list.Add(lessonTitle);
                        list.Add(lessonTitle + "-Exercise");
                    }

                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{list[i]}");
            }
        }
    }
}