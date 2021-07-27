using System;
using System.Collections.Generic;
using System.Linq;
namespace Linq_Student
{
    class Program
    {
        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }

        static List<Student> students = new List<Student>
{

   new Student {First="Svetlana", Last="Omelchenko", ID=111, Scores= new List<int> {97, 92, 81, 60}},
   new Student {First="Claire", Last="O’Donnell", ID=112, Scores= new List<int> {75, 84, 91, 39}},
};

        static void Main(string[] args)
        {
            var studentQuery5 =
            from student in students
            let totalScore = student.Scores[0] + student.Scores[1] +  student.Scores[2] + student.Scores[3]
            where totalScore / 4 < student.Scores[0]   select student.Last + " " + student.First;

            foreach (string s in studentQuery5)
            {
                Console.WriteLine(s);
            }









        }
    }
}
