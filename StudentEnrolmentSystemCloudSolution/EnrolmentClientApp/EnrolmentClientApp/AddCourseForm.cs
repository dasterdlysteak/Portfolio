using EnrolmentClientApp.EnrolmentSystemReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnrolmentClientApp
{
    public partial class AddCourseForm : Form
    {
        EnrolmentSystemClient client = new EnrolmentSystemClient();

        public AddCourseForm()
        {
            InitializeComponent();
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void addCourseBtn_Click(object sender, EventArgs e)
        {
            addCourseListBox.Items.Clear();
            if (courseIDTextBox.Text == "" || courseNameTextBox.Text == "" || courseCostTextBox.Text == "" || schedTimeTextBox.Text == "")
            {
                addCourseListBox.Items.Add("Please Enter all Course detail fields");
            }
            else
            {
                try
                {
                    addCourseListBox.Items.Add(client.addCourse(courseIDTextBox.Text, courseNameTextBox.Text, Decimal.Parse(courseCostTextBox.Text), DateTime.Parse(schedTimeTextBox.Text)));
                    var course = client.viewCourseDetails(courseIDTextBox.Text);
                    addCourseListBox.Items.Add(" ");
                    addCourseListBox.Items.Add(course.courseID);
                    addCourseListBox.Items.Add(course.courseName);
                    addCourseListBox.Items.Add(course.cost);
                    addCourseListBox.Items.Add(course.allottedTime);
                }
                catch (FormatException ex)
                {
                    addCourseListBox.Items.Add("Please Ensure date and cost are correct!");
                }
                catch(Exception ex)
                {
                    addCourseListBox.Items.Add("Course already in Database");
                }
            }
        }
    }
}
