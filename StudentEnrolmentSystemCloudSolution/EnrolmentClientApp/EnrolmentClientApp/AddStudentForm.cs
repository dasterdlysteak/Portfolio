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
    public partial class AddStudentForm : Form
    {
        EnrolmentSystemClient client = new EnrolmentSystemClient();
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void returnBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void addStudentBtn_Click(object sender, EventArgs e)
        {
            addstudentListBox.Items.Clear();
            try
            {
                if (studentIDTextBox.Text == "" || studentNameTextBox.Text == "")
                {
                    addstudentListBox.Items.Add("Please Enter all Student detail fields required");
                }
                else
                {
                    addstudentListBox.Items.Add(client.addStudent(studentIDTextBox.Text, studentNameTextBox.Text, DateTime.Now));
                    var student = client.viewStudentDetails(studentIDTextBox.Text);
                    addstudentListBox.Items.Add(" ");
                    addstudentListBox.Items.Add("Student ID: " + student.studentID);
                    addstudentListBox.Items.Add("Student Name: " + student.studentName);
                    addstudentListBox.Items.Add("Date Enrolled: " + student.dateEnrolled);
                }
            }
            catch(Exception ex)
            {
                addstudentListBox.Items.Add("Student Already Exists in the Database");

            }

        }
    }
}
