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

                Console.Clear();
                TimeSpan time = DateTime.Now - startTime;
                Console.WriteLine("Practical Exam Results:");
                Console.WriteLine();
                float totalGrade = 0;
                float maxGrade = 0;

                for (int s = 0; s < NumberOfQuestions; s++)
                {
                    Question questionNum = Questions[s];
                    Answer studentAnswer = StudentAnswers[s];

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

                    Console.WriteLine($"Your Grade is {totalGrade} from {maxGrade}");
                    Console.WriteLine($"Time = {time}");

                    Console.WriteLine("Thank you");
                }


            }




        }
    }
}
