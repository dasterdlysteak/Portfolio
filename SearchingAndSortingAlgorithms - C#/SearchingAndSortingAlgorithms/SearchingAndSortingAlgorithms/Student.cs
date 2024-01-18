using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02
{
    public class Student : Person, IComparable<Student>
    {
        public string Program {get; set;}
        public DateTime DateRegistered { get; set; }
        public Enrollment Enrollment { get; set; }

        public Student(string name, string email, string telnum, string program,
            DateTime dateReg,string number, string street, string suburb, string postcode, string state, 
            DateTime enrolled, string grade, string semester) :
            base(name, email, telnum, number, street, suburb, postcode, state)
        {
            Program = program;
            DateRegistered = dateReg;
            Enrollment = new Enrollment(enrolled, grade, semester);
        }

        public static bool operator ==(Student a, Student b)
        {
            return object.Equals(a, b);
        }

        public static bool operator !=(Student a, Student b)
        {
            return !object.Equals(a, b);
        }

        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }
            if(ReferenceEquals(obj, this))
            {
                return true;
            }
            Student stu = obj as Student;
            return this.Email == stu.Email && this.DateRegistered == stu.DateRegistered;
        }

        // I have chosend the email and date registered fields to hash, as together they make the most unique hash code
        // possible for the student object, reducing the liklihood of collisions when using them for sorting and searching.
        public override int GetHashCode()
        {
            return this.Email.GetHashCode() ^ this.DateRegistered.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {Name}\nEmail: {Email}\nTelephone: {TelNum}\nProgram {Program}\nRegistration Date: {DateRegistered}\n{Enrollment} \n\n";
        }

        public override void displayPerson()
        {
            Console.WriteLine($"Name: {Name}\nEmail: {Email}\nTelephone: {TelNum}\nProgram {Program}\nRegistration Date: {DateRegistered}\n\n");
        }

        public int CompareTo(Student other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.GetHashCode().CompareTo(other.GetHashCode()); 
        }

        public int CompareName(Student other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.Name.CompareTo(other);
        }

    }
}
