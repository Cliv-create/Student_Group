﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Group
{
    internal class Student
    {
        public class SurnameAZComparer : IComparer<Student>
        {
            public int Compare(Student? student_a, Student? student_b)
            {
                return student_a.Surname.CompareTo(student_b.Surname);
            }
        }

        public class SurnameZAComparer : IComparer<Student>
        {
            public int Compare(Student? student_a, Student? student_b)
            {
                return student_b.Name.CompareTo(student_a.Name);
            }
        }

        public class NameLengthComparer : IComparer<Student>
        {
            public int Compare(Student? student_a, Student? student_b)
            {
                if (student_a.Name.Length > student_b.Name.Length) return 1; // левый объект (первый параметр метода) БОЛЬШЕ
                if (student_a.Name.Length < student_b.Name.Length) return -1; // левый объект (первый параметр метода) МЕНЬШЕ
                return 0; // состояние по выбранному критерию идентично
            }
        }

        private string _name; // get
        private string _surname; // get
        private string _email; // get-set
        private int _id; // get-set
        DateTime birthday; // get
        private string home_adress; // get-set
        private string phone_number; // get-set
        bool is_member; // get-set
        private uint min_rate; // TODO: Use variable
        private uint max_rate; // TODO: Use variable

        List<int> test_rates = [0];
        List<int> coursework_rates = [0];
        List<int> exam_rates = [0];

        public Student() : this("n/a", "n/a", "example@mail.com", 0, new DateTime(), "n/a", "00-000-000-00-00", 1, 12) { }

        public Student(string name, string surname, string phone_number) : this(name, surname, "example@mail.com", 0, new DateTime(), "n/a", phone_number, 1, 12) { }

        // Main c-tor
        public Student(string name, string surname, string email, int student_id, DateTime birthday, string home_adress, string phone_number, uint min_rate, uint max_rate)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _id = student_id;
            this.birthday = birthday;
            this.home_adress = home_adress;
            this.phone_number = phone_number;
            this.is_member = true;
            this.min_rate = min_rate;
            this.max_rate = max_rate;
        }

        public Student(Student source_student)
        {
            _name = source_student.Name;
            _surname = source_student.Surname;
            _email = source_student.Email;
            _id = source_student.Id;
            birthday = source_student.Birthday;
            home_adress = source_student.HomeAdress;
            phone_number = source_student.PhoneNumber;
            is_member = source_student.IsMember;
        }

        public static bool operator > (Student a, Student b)
        {
            if (a.test_rates.Average() > b.test_rates.Average())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator < (Student a, Student b)
        {
            return !(a > b);
        }
        
        public static bool operator true(Student student) => student.test_rates.Average() >= 7;
        public static bool operator false(Student student) => student.test_rates.Average() <= 7;

        public static bool operator == (Student a, Student b)
        {
            if (a.test_rates.Average() == b.test_rates.Average())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator != (Student a, Student b)
        {
            return !(a == b);
        }

        public string Name
        {
            get { return _name; }
        }
        public string Surname
        {
            get { return _surname; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public DateTime Birthday
        {
            get { return birthday; }
        }
        public string HomeAdress
        {
            get { return home_adress; }
            set { home_adress = value; }
        }
        public string PhoneNumber
        {
            get { return phone_number; }
            set { phone_number = value; }
        }
        public bool IsMember
        {
            get { return is_member; }
            set { is_member = value; }
        }
        public uint MinRate
        {
            get { return min_rate; }
        }
        public uint MaxRate
        {
            get { return max_rate; }
        }

        // ---
        // Collections handling

        public List<int> GetTestRatesCopy()
        {
            return new List<int>(test_rates);
        }

        public void AddTestRate(int rate)
        {
            test_rates.Add(rate);
        }

        public void AddArrayToTestRate(IEnumerable<int> collection)
        {
            test_rates.AddRange(collection);
        }

        public bool RemoveTestRate(int rate)
        {
            return test_rates.Remove(rate);
        }

        public void ClearTestRates()
        {
            test_rates.Clear();
        }

        // coursework_rates

        public List<int> GetCourseWorkCopy()
        {
            return new List<int>(coursework_rates);
        }

        public void AddCourseworkRate(int rate)
        {
            coursework_rates.Add(rate);
        }

        public void AddArrayToCourseworkRate(IEnumerable<int> collection)
        {
            coursework_rates.AddRange(collection);
        }

        public bool RemoveCourseworkRate(int rate)
        {
            return coursework_rates.Remove(rate);
        }

        public void ClearCourseworkRates()
        {
            coursework_rates.Clear();
        }

        // exam_rates

        public List<int> GetExamRatesCopy()
        {
            return new List<int>(exam_rates);
        }

        public void AddExamRate(int rate)
        {
            exam_rates.Add(rate);
        }

        public void AddArrayToExamRate(IEnumerable<int> collection)
        {
            exam_rates.AddRange(collection);
        }

        public bool RemoveExamRate(int rate)
        {
            return exam_rates.Remove(rate);
        }

        public void ClearExamRates()
        {
            exam_rates.Clear();
        }

        // Collections handling
        // ---


    }
}
