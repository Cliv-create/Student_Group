using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Student_Group
{
    internal class Group : ICloneable
    {
        List<Student> students;
        private string _group_name;
        private string _group_specialization;
        private int _course_number;

        public Group() : this("n/a", "n/a", 0) { }

        public Group(string group_name, string group_specialization, int course_number)
        {
            students = new List<Student>();
            _group_name = group_name;
            _group_specialization = group_specialization;
            _course_number = course_number;
        }

        public Group(List<Student> student_list, string group_name, string group_specialization, int course_number)
        {
            // Deep copy of student_list
            students = student_list.Select(student => new Student(student)).ToList();
        }

        public Group(Group source_group)
        {
            students = new List<Student>(source_group.GetStudentsCopy());
            _group_name = source_group.GroupName;
            _group_specialization = source_group.GroupSpecialization;
            _course_number = source_group.CourseNumber;
        }

        public static bool operator true(Group group) => group.students.Count > 0;
        public static bool operator false(Group group) => group.students.Count == 0;

        public static bool operator > (Group a, Group b)
        {
            if (a.students.Count > b.students.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator < (Group a, Group b)
        {
            return !(a > b);
        }

        public static bool operator == (Group a, Group b)
        {
            if (a.students.Count == b.students.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator != (Group a, Group b)
        {
            return !(a == b);
        }

        public Student this[int key]
        {
            get => students[key];
            set => students[key] = value;
        }

        public string GroupName
        {
            get { return _group_name; }
        }

        public string GroupSpecialization
        {
            get { return _group_specialization; }
        }

        public int CourseNumber
        {
            get { return _course_number; }
            set { _course_number = value; }
        }

        public List<Student> GetStudentsCopy()
        {
            return students.Select(s => new Student(s)).ToList();
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void AddArrayOfStudents(IEnumerable<Student> collection)
        {
            students.AddRange(collection);
        }

        public bool RemoveStudent(Student student)
        {
            return students.Remove(student);
        }

        public void ClearStudentList()
        {
            students.Clear();
        }

        public void PrintGroup()
        {
            var temp_students = new List<Student>(students);
            temp_students.Sort(new Student.SurnameAZComparer());
            Console.WriteLine($"Group name: {GroupName}\n" +
                              $"Group specialization: {GroupSpecialization}\n" +
                              $"Group course number: {CourseNumber}\n" +
                              $"Students count: {students.Count}\n"
            );

            Console.WriteLine("Group's students:\n");
            for (int i = 0; i < temp_students.Count; i++)
            {
                Console.WriteLine($"{i} - " + $"{temp_students[i].Name} " + $"{temp_students[i].Surname} " + $"Email: {temp_students[i].Email} " + $"Phone number: {temp_students[i].PhoneNumber}");
            }
            Console.WriteLine("End of Group's students\n");
        }

        /// <summary>
        /// Returns a deep copy of original Group.
        /// </summary>
        /// <returns>Deep copy of Group.</returns>
        public object Clone()
        {
            var temp_group = new Group(this);
            return temp_group;
        }
    }
}
