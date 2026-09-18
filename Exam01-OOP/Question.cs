using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Exam01_OOP
{
    internal abstract class Question : IComparable<Question>, ICloneable
    {
        public string Header { get; set; }
        public string Body { get; set; }

        public float Mark { get; set; }
        public Answer CorrectAnswer { get; set; }

        public Answer[] AnswerList { get; set; }

        protected Question(string header, string body, float mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }
        protected Question(
        string header,
        string body,
        float mark,
        Answer[] answerList,
        Answer correctAnswer
    ) : this(header, body, mark)
        {
            AnswerList = answerList;
            CorrectAnswer = correctAnswer;
        }
        public override string ToString()
        {
            return $"{Header}\tMark:{Mark}\n{Body}";
        }
        public int CompareTo(Question? other)
        {
            if (other == null) return 1;
            return Mark.CompareTo(other.Mark);
        }

        public abstract object Clone();


    }
}
