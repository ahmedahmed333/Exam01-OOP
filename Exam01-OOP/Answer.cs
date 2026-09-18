using System;
using System.Collections.Generic;
using System.Text;

namespace Exam01_OOP
{
    internal class Answer 
    {
        public int Id { get; }
        public string Text { get; set; }
        public Answer(int id, string text)
        {
            Id = id;
            Text = text;

        }

        public override string ToString()
        {
            return $"{Id}. {Text}";
        }

      
    }
}
