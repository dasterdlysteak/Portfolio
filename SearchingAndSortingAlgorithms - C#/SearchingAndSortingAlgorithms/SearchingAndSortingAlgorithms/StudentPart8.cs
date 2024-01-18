using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02
{
    public class StudentPart8 : Person, IComparable<StudentPart8>
    {
        
        public string Program { get; set; }
        public DateTime DateRegistered { get; set; }
        public Enrollment Enrollment { get; set; }

        public StudentPart8(string name, string email, string telnum, string program,
            DateTime dateReg, string number, string street, string suburb, string postcode, string state,
            DateTime enrolled, string grade, string semester) :
            base(name, email, telnum, number, street, suburb, postcode, state)
        {
            Program = program;
            DateRegistered = dateReg;
            Enrollment = new Enrollment(enrolled, grade, semester);
        }

        public static bool operator ==(StudentPart8 a, StudentPart8 b)
        {
            return object.Equals(a, b);
        }

        public static bool operator !=(StudentPart8 a, StudentPart8 b)
        {
            return !object.Equals(a, b);
        }


        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (ReferenceEquals(obj, this))
            {
                return true;
            }
            StudentPart8 stu = obj as StudentPart8;
            return this.Name.Equals(stu.Name);
        }

        // we have created this extra class in order to override the gethash and Equals method to fit in with 
        // the requirements presented in the question which would not work with our original class
        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {Name}\nEmail: {Email}\nTelephone: {TelNum}\nProgram {Program}\nRegistration Date: {DateRegistered}\n{Enrollment} \n\n";
        }

        public override void displayPerson()
        {
            Console.WriteLine($"Name: {Name}\nEmail: {Email}\nTelephone: {TelNum}\nProgram {Program}\nRegistration Date: {DateRegistered}\n\n");
        }

        public int CompareTo(StudentPart8 other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.Name.CompareTo(other.Name);
        }

        public int CompareName(StudentPart8 other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.Name.CompareTo(other);
        }

    }
}

