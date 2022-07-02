using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        private const string END_COMMAND = "course start";
        private const string COMMAND_SEPARATOR = ":";
        private const string LESSON_SEPARATOR = ", ";
        private const string EXERCISE = "-Exercise";

        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(LESSON_SEPARATOR).ToList();

            string input = Console.ReadLine();
            while (input != END_COMMAND)
            {
                string[] commandArgs = input.Split(COMMAND_SEPARATOR);
                string command = commandArgs[0];
                string lessonTitle = commandArgs[1];
                switch (command)
                {
                    case "Add":
                        AddLesson(lessonTitle, lessons);
                        break;
                    case "Insert":
                        int index = int.Parse(commandArgs[2]);
                        InserLesson(lessonTitle, index, lessons);
                        break;
                    case "Remove":
                        RemoveLesson(lessonTitle, lessons);
                        break;
                    case "Swap":
                        string secondLessonTitle = commandArgs[2];
                        SwapLesson(lessonTitle, secondLessonTitle, lessons);
                        break;
                    case "Exercise":
                        AddExercise(lessonTitle, lessons);
                        break;
                    default:
                        break;
                }

                input = Console.ReadLine();
            }


            int counter = 0;
            foreach (string lesson in lessons)
            {
                counter++;
                Console.WriteLine($"{counter}.{lesson}");
            }
        }

        private static void AddLesson(string lessonTitle, List<string> lessons)
        {
            if (!lessons.Contains(lessonTitle))
            {
                lessons.Add(lessonTitle);
            }
        }

        private static void InserLesson(string lessonTitle, int index, List<string> lessons)
        {
            if (!lessons.Contains(lessonTitle))
            {
                lessons.Insert(index, lessonTitle);
            }
        }

        private static void RemoveLesson(string lessonTitle, List<string> lessons)
        {
            if (lessons.Contains(lessonTitle))
            {
                lessons.Remove(lessonTitle);
            }
            if (lessons.Contains(lessonTitle + EXERCISE))
            {
                lessons.Remove(lessonTitle + EXERCISE);
            }
        }

        private static void SwapLesson(string firstLessonTitle, string secondLessonTitle, List<string> lessons)
        {
            if (lessons.Contains(firstLessonTitle) && lessons.Contains(secondLessonTitle))
            {
                int firstIndex = lessons.IndexOf(firstLessonTitle);
                int secondIndex = lessons.IndexOf(secondLessonTitle);

                string firstExercise = firstLessonTitle + EXERCISE;
                string secondExercise = secondLessonTitle + EXERCISE;

                bool firstHasExercise = lessons.Contains(firstExercise);
                bool secondHasExercise = lessons.Contains(secondExercise);

                lessons[firstIndex] = secondLessonTitle;
                lessons[secondIndex] = firstLessonTitle;

                if (firstHasExercise)
                {
                    lessons.Remove(firstExercise);
                    AddExercise(firstLessonTitle, lessons);
                }
                if (secondHasExercise)
                {
                    lessons.Remove(secondExercise);
                    AddExercise(secondLessonTitle, lessons);
                }
            }
        }

        private static void AddExercise(string lessonTitle, List<string> lessons)
        {
            string exercise = lessonTitle + EXERCISE;
            if (lessons.Contains(lessonTitle))
            {
                if (!lessons.Contains(exercise))
                {
                    lessons.Insert(lessons.IndexOf(lessonTitle) + 1, exercise);
                }
            }
            else
            {
                lessons.Add(lessonTitle);
                lessons.Add(exercise);
            }
        }
    }
}
