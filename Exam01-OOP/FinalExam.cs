using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Exam01_OOP
{
    internal class FinalExam : Exam
    {
        public Answer[] StudentAnswers { get; set; }


        public FinalExam(float time, int numberOfQuestions) : base(time, numberOfQuestions)
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

            for (int i = 0; i < NumberOfQuestions; i++)
            {

                Question question = Questions[i];

                Console.WriteLine($"Question {i + 1}: {question.Body}");

                Console.WriteLine(
                    $"{question.Header}    Mark {question.Mark}");

                Console.WriteLine();

                foreach (Answer ans in question.AnswerList)
                {
                    Console.WriteLine(ans);
                }
                Console.Write("\nEnter your answer ID: ");
                //int studentAnswerId = int.Parse(Console.ReadLine()!);
                int studentAnswerId;

              while (!int.TryParse(Console.ReadLine(), out studentAnswerId) ||
       studentAnswerId < 1 ||
       studentAnswerId > question.AnswerList.Length)
                {
                    Console.WriteLine("Invalid answer ID.");
                    Console.Write("Enter your answer ID again: ");
                }
                Answer studentAnswer =
               question.AnswerList[studentAnswerId - 1];

                StudentAnswers[i] = studentAnswer;

                if (i < NumberOfQuestions - 1)
                {
                    Console.Clear();
                }
            }

            TimeSpan time = DateTime.Now - startTime;

            Console.Clear();


            Console.WriteLine("Final Exam Results:");

            float totalGrade = 0;
            float maxGrade = 0;

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Question question = Questions[i];

                Answer studentAnswer =
              StudentAnswers[i];

                maxGrade += question.Mark;

                if (studentAnswer.Id == question.CorrectAnswer.Id)
                {
                    totalGrade += question.Mark;
                }
                Console.WriteLine(
                    $"Question {i + 1}: {question.Body}");

                Console.WriteLine(
                    $"Your Answer => {studentAnswer.Text}");

                Console.WriteLine(
                    $"Correct Answer => {question.CorrectAnswer.Text}");

                Console.WriteLine();
            }
            Console.WriteLine(
           $"Your Grade is {totalGrade} from {maxGrade}");

            Console.WriteLine($"Time = {time}");

            Console.WriteLine();
            Console.WriteLine("Thank you");

        }
    }


}
