using System.Formats.Asn1;
using System.Threading;

namespace Student_Group
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var s = new Student();
            var s1 = new Student("Testingname", "Testing surname", "38-435-23-53");
            Group g = new Group();
            g.AddStudent(s);
            g.AddStudent(s1);
            g.PrintGroup();

            var s2 = new Student("Name", "Surname", "038-263-57-23");
            var g2 = new Group();
            g2.AddStudent(s2);

            var g3 = g2.Clone() as Group;
            Console.WriteLine("Modified group:\n");
            g3.PrintGroup();
            g3[0].PhoneNumber = "074-263-23-16";
            g3[0].Id = 123923;
            g3[0].Email = "newstudentmail@mail.com";
            g3.PrintGroup();
            Console.WriteLine("Original group:\n");
            g2.PrintGroup();
        }
    }
}
