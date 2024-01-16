using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EnrolmentClientApp.EnrolmentSystemReference;

namespace EnrolmentClientApp
{
    public partial class Form1 : Form
    {
        EnrolmentSystemClient client = new EnrolmentSystemClient();
        public Form1()
        {
            InitializeComponent();
            var courses = client.getCourses();
            if (courses != null)
            {
                foreach (Course course in courses)
                {
                    coursesComboBox.Items.Add(course.courseID);
                }
            }
            else
            {
                resultsListBox.Items.Add("course list was empty");
            }
            var students = client.getStudents();
            if (students != null)
            {
                foreach (Student student in students)
                {
                    studentsComboBox.Items.Add(student.studentID + " - " + student.studentName);
                }
            }
            else
            {
                resultsListBox.Items.Add("student list was empty");
            }
            gradeComboBox.Items.Add("PASS");
            gradeComboBox.Items.Add("FAIL");
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void viewCoursesBtn_Click(object sender, EventArgs e)
        {
            resultsListBox.Items.Clear();
            if (studentsComboBox.SelectedItem != null)
            {
                string[] split = studentsComboBox.SelectedItem.ToString().Split('-');
                var courses = client.getCoursesForStudent(split[0]);
                foreach (Course course in courses)
                {
                    resultsListBox.Items.Add(course.courseID +" "+ course.courseName);
                }

            }
            else
            {
                resultsListBox.Items.Add("Please Select a Student from the drop down menu above");
            }
        }

        private void viewStudentsBtn_Click(object sender, EventArgs e)
        {
            resultsListBox.Items.Clear();
            if (coursesComboBox.SelectedItem != null)
            {
                var students = client.getStudentsInCourse(coursesComboBox.SelectedItem.ToString());
                foreach (Student student in students)
                {
                    resultsListBox.Items.Add(student.studentName);
                } 

            }
            else
            {
                resultsListBox.Items.Add("Please Select a course from the drop down menu above");
            }
        }

        private void enrolStudentBtn_Click(object sender, EventArgs e)
        {
            try
            {
                resultsListBox.Items.Clear();
                if (studentsComboBox.SelectedItem == null || coursesComboBox.SelectedItem == null)
                {
                    resultsListBox.Items.Add("Please select both a Student and Course from the drop down");
                }
                else
                {
                    string[] split = studentsComboBox.SelectedItem.ToString().Split('-');
                    resultsListBox.Items.Add(client.enrolStudent(split[0], coursesComboBox.SelectedItem.ToString()));

                }
            }
            catch (Exception ex)
            {
                resultsListBox.Items.Add("Error Student already Enrolled in this course");
            }
            
        }


        private void studentDetailsBtn_Click(object sender, EventArgs e)
        {
            resultsListBox.Items.Clear();
            if (studentsComboBox.SelectedItem != null)
            {
                string[] split = studentsComboBox.SelectedItem.ToString().Split('-');
                var student = client.viewStudentDetails(split[0]);
                resultsListBox.Items.Add("Student ID: " + student.studentID);
                resultsListBox.Items.Add("Student Name: " + student.studentName);
                resultsListBox.Items.Add("Date Enrolled: " + student.dateEnrolled);


            }
            else
            {
                resultsListBox.Items.Add("Please Select a Student from the drop down menu above");
            }
        }

        private void courseDetailsBtn_Click(object sender, EventArgs e)
        {
            resultsListBox.Items.Clear();
            if (coursesComboBox.SelectedItem != null)
            {
                var course = client.viewCourseDetails(coursesComboBox.SelectedItem.ToString());
                resultsListBox.Items.Add("Course ID: " + course.courseID);
                resultsListBox.Items.Add("Course Name: " + course.courseName);
                resultsListBox.Items.Add("Course Cost: " + course.cost);
                resultsListBox.Items.Add("Scheduled Time : " + course.allottedTime);
            }
            else
            {
                resultsListBox.Items.Add("Please Select a Student from the drop down menu above");
            }
        }

        private void addStudentBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddStudentForm studentForm = new AddStudentForm();
            studentForm.Show();
        }

        private void addCourseBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddCourseForm courseForm = new AddCourseForm();
            courseForm.Show();
        }

        private void timeTableButton_Click(object sender, EventArgs e)
        {
            resultsListBox.Items.Clear();
            if (studentsComboBox.SelectedItem != null)
            {
                string[] split = studentsComboBox.SelectedItem.ToString().Split('-');
                var courses = client.getCoursesForStudent(split[0]);
                foreach (Course course in courses)
                {
                    resultsListBox.Items.Add(course.courseName+ " " + course.allottedTime);
                }
            }
            else
            {
                resultsListBox.Items.Add("Please Select a Student from the drop down menu above");
            }
        }

        private void billButton_Click(object sender, EventArgs e)
        {
            resultsListBox.Items.Clear();
            if (studentsComboBox.SelectedItem != null)
            {
                decimal total = 0;
                string[] split = studentsComboBox.SelectedItem.ToString().Split('-');
                var courses = client.getCoursesForStudent(split[0]);
                foreach (Course course in courses)
                {
                    total = total + course.cost;
                    resultsListBox.Items.Add(course.courseName + " " + course.cost);
                }
                resultsListBox.Items.Add(" ");
                resultsListBox.Items.Add("Total Payable: " + total);
            }
            else
            {
                resultsListBox.Items.Add("Please Select a Student from the drop down menu above");
            }
        }

        private void studentsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultsListBox.Items.Clear();
        }

        private void coursesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            resultsListBox.Items.Clear();
        }

        private void gradUpdateBtn_Click(object sender, EventArgs e)
        {
            resultsListBox.Items.Clear();
            if (studentsComboBox.SelectedItem == null || coursesComboBox.SelectedItem == null)
            {
                resultsListBox.Items.Add("Please select both a Student and Course from the drop down");
            }
            else if(gradeComboBox.SelectedItem == null)
            {
                resultsListBox.Items.Add("Please select the appropriate grade for this subject");
            }
            else
            {
                string[] split = studentsComboBox.SelectedItem.ToString().Split('-');
                resultsListBox.Items.Add(client.setGrade(split[0], coursesComboBox.SelectedItem.ToString(), gradeComboBox.SelectedItem.ToString()));

            }
        }

        private void gradeBtn_Click(object sender, EventArgs e)
        {
            resultsListBox.Items.Clear();
            if (studentsComboBox.SelectedItem != null)
            {
                string[] split = studentsComboBox.SelectedItem.ToString().Split('-');
                var enrolments = client.getEnrolmentForStudent(split[0]);
                foreach (Enrolment enrolment in enrolments)
                {
                    Course course = (client.viewCourseDetails(enrolment.courseID));
                    resultsListBox.Items.Add(course.courseName + " " + enrolment.grade);
                }

            }
            else
            {
                resultsListBox.Items.Add("Please Select a Student from the drop down menu above");
            }
        }
    }
}
