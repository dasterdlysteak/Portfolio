using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02
{
    public class Course : IComparable<Course>
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public double Cost { get; set; }

        public Course(string courseCode, string courseName, double cost)
        {
            this.CourseCode = courseCode;
            this.CourseName = courseName;
            this.Cost = cost;
        }

        public int CompareTo(Course other)
        {
            if (other == null)
            {
                return 1;
            }
            return this.CourseCode.CompareTo(other.CourseCode);
        }

        public override string ToString()
        {
            return $"   Course Code: {CourseCode}\n   Course Name: {CourseName}\n   Cost: {Cost}";
        }
    }
}
