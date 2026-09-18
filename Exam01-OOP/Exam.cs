using System;
using System.Collections.Generic;
using System.Text;

namespace Exam01_OOP
{
    internal abstract class Exam
    {

        public float Time { set; get; }
        public int NumberOfQuestions { set; get; }
        public Question[] Questions { get; set; }

        protected Exam(float time, int numberOfQuestions)
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = new Question[numberOfQuestions];
        }

        public abstract void ShowExam();
    }
}
