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
        }
    }
}
