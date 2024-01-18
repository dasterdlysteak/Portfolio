using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02
{
    public class Enrollment
    {
        public DateTime DateEnrolled { get; set; }
        public string Grade { get; set; }
        public string Semester { get; set; }
        public List<Course> Courses = new List<Course>();

        public Enrollment(DateTime enrolled, string grade, string semester)
        {
            this.DateEnrolled = enrolled;
            this.Grade = grade;
            this.Semester = semester;
            
        }

        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }

        public string getCourses()
        {
            
            string courseString = "Course Info: \n";
            foreach (Course i in Courses)
            {
                courseString += i.ToString();
            }
            return courseString;
        }

        public override string ToString()
        {
            return $"   Enrollment details:\n    Date enrolled: {DateEnrolled}\n    Grade: {Grade}\n    Semester: {Semester}\n  {getCourses()}\n";
        }
    }
}
