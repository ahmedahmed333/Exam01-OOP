using System;
using System.Collections.Generic;
using System.Text;

namespace Exam01_OOP
{
    internal class Subject
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public Exam Exam { get; set; }


        public Subject(int id, string name)
        {
            Id = id;
            Name = name;

        }

        public void CreateExam()
        {
            Console.WriteLine("Please choose exam type (PracticalExam a, FinalExam b)");

            string? examType = Console.ReadLine()?.ToLower();
            while (examType != "a" && examType != "b")
            {
                Console.WriteLine("Invalid exam type. Please choose (a) or (b):");
                examType = Console.ReadLine()?.ToLower();
            }

            Console.WriteLine("Please enter exam time (30 to 180 min):");

            float time = int.Parse(Console.ReadLine()!);
            while (time < 30 || time > 180)
            {
                Console.WriteLine("Invalid time. Exam time must be between 30 and 180 minutes.");
                Console.Write("Please enter exam time again: ");
                time = float.Parse(Console.ReadLine()!);
            }
            Console.Write("Please enter number of questions: ");

            int numberOfQuestions = int.Parse(Console.ReadLine()!);
            while (numberOfQuestions <= 0)
            {
                Console.WriteLine("Invalid number of questions. It must be greater than 0.");
                numberOfQuestions = int.Parse(Console.ReadLine()!);
            }
            if (examType == "a")
            {
                Exam = new PracticalExam(time, numberOfQuestions);
            }
            else
            {
                Exam = new FinalExam(time, numberOfQuestions);
            }

            for (int i = 0; i < numberOfQuestions; i++)
            {

                Console.Write("Please enter question body: ");
                string body = Console.ReadLine()!;

                Console.Write("Please enter question mark: ");
                float mark = float.Parse(Console.ReadLine()!);

                Answer[] answers = new Answer[4];

                for (int j = 0; j < answers.Length; j++)
                {
                    Console.Write($"Please enter choice number {j + 1}: ");

                    string text = Console.ReadLine()!;
                    answers[j] = new Answer(j + 1, text);
                }
                Console.Write("Please enter the ID of the correct answer (1 to 4): ");

                int correctAnswerId = int.Parse(Console.ReadLine()!);

                while (correctAnswerId < 1 || correctAnswerId > 4)
                {
                    Console.WriteLine("Invalid answer ID. Please enter a number from 1 to 4:");
                    correctAnswerId = int.Parse(Console.ReadLine()!);
                }

                Answer correctAnswer = answers[correctAnswerId - 1];

                MCQQuestion question = new MCQQuestion("MCQ Question", body, mark);


                question.AnswerList = answers;
                question.CorrectAnswer = correctAnswer;

                Exam.Questions[i] = question;




            }

        }

    }
}
