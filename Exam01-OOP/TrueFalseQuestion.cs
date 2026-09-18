using System;
using System.Collections.Generic;
using System.Text;

namespace Exam01_OOP
{
    internal class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string header, string body, float mark) : base(header, body, mark)
        {
            AnswerList = new Answer[]
            {
                new Answer(1, "True"),
                new Answer(2, "False")

            };
        }

        public override object Clone()
        {
           var newQuestion = new TrueFalseQuestion(Header, Body, Mark);
            if(CorrectAnswer != null)
            {
                newQuestion.CorrectAnswer = new Answer(CorrectAnswer.Id, CorrectAnswer.Text);


            }
            return newQuestion;
        }
    }
}
