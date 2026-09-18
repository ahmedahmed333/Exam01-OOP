using System;
using System.Collections.Generic;
using System.Text;

namespace Exam01_OOP
{
    internal class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, float mark) : base(header, body, mark)
        {
        }

        public override object Clone()
        {
            var newQusetion = new MCQQuestion(Header, Body, Mark);

            if (AnswerList != null)
            {

                newQusetion.AnswerList = new Answer[AnswerList.Length];

                for (int i = 0; i < AnswerList.Length; i++)
                {

                    newQusetion.AnswerList[i] = new Answer(AnswerList[i].Id, AnswerList[i].Text);
                }
                if (CorrectAnswer != null)
                {
                    newQusetion.CorrectAnswer = new Answer(CorrectAnswer.Id, CorrectAnswer.Text);

                }
            }
            return newQusetion;


        }
    }
}
