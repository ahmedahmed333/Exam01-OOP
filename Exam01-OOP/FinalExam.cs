using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Exam01_OOP
{
    internal class FinalExam : Exam
    {
        public FinalExam(float time, int numberOfQuestions) : base(time, numberOfQuestions)
        {
        }

        public override void ShowExam()
        {
            throw new NotImplementedException();
        }

    }
}
