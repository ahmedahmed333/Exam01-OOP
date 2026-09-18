namespace Exam01_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Subject subject = new Subject(1, "c");


            subject.CreateExam();

            Console.WriteLine("\nExam has been created successfully.");

            Console.WriteLine("Press Enter to continue...");

            Console.ReadLine();

            subject.Exam.ShowExam();

        }
    }
}
