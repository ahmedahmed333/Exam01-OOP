using System;
using System.Collections.Generic;
using System.Text;

namespace Exam01_OOP
{
    internal class PracticalExam : Exam
    {
        public Answer[] StudentAnswers { get; set; }
        public PracticalExam(float time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
            StudentAnswers = new Answer[numberOfQuestions];

        }

        public override void ShowExam()
        {
            Console.Clear();

            Console.WriteLine("Do you want to start exam (y | n)");

            string? answer = Console.ReadLine()?.ToLower();
            if (answer != "y")
            {
                Console.WriteLine("Exam cancelled.");
                return;
            }
            Console.Clear();
            DateTime startTime = DateTime.Now;

            float totalGrade = 0;


            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Question question = Questions[i];

                Console.WriteLine($"question {i + 1}");
                Console.WriteLine(question.Body);
                Console.WriteLine($"Mark : {question.Mark}");
                Console.WriteLine();

                foreach (Answer ans in question.AnswerList)
                {
                    Console.WriteLine(ans);
                }

                Console.WriteLine("Enter your answer ID:");
                int studentAnswerId = int.Parse(Console.ReadLine()!);
                if (studentAnswerId < 1 || studentAnswerId > question.AnswerList.Length)
                {
                    Console.WriteLine("Invaild answer ID");
                    Console.WriteLine("Enter yout answer ID again:");
                    studentAnswerId = int.Parse(Console.ReadLine()!);

                }
                Answer studentAnwser = question.AnswerList[studentAnswerId - 1];

                StudentAnswers[i] = studentAnwser;

                Console.WriteLine();

                if (studentAnwser.Id == question.CorrectAnswer.Id)
                {
                    totalGrade += question.Mark;
                    Console.WriteLine("Correct Answer!");
                    Console.WriteLine($"Your Answer: {studentAnwser}");
                    Console.WriteLine($"Correct Answer {question.CorrectAnswer}");
                    Console.WriteLine($"Grade: {question.Mark}");

                }
                else
                {
                    Console.WriteLine("Wrong Answer!");
                    Console.WriteLine($"Your Answer: {studentAnwser}");
                    Console.WriteLine($"Correct Answer {question.CorrectAnswer}");
                    Console.WriteLine($"Grade: 0");
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
            TimeSpan time = DateTime.Now - startTime;

            Console.WriteLine("================================");
            Console.WriteLine("Exam Finished!");
            Console.WriteLine($"Total Grade: {totalGrade}");
            Console.WriteLine($"Elapsed Time: {time.TotalSeconds:F2} seconds");
            Console.WriteLine("Thank you for taking the exam.");
            Console.WriteLine("================================");



        }
    }
}
