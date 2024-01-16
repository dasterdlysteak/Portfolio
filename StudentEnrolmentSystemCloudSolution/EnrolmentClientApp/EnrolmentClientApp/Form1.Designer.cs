
namespace EnrolmentClientApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.studentsComboBox = new System.Windows.Forms.ComboBox();
            this.coursesComboBox = new System.Windows.Forms.ComboBox();
            this.resultsListBox = new System.Windows.Forms.ListBox();
            this.viewCoursesBtn = new System.Windows.Forms.Button();
            this.viewStudentsBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.enrolStudentBtn = new System.Windows.Forms.Button();
            this.addStudentBtn = new System.Windows.Forms.Button();
            this.addCourseBtn = new System.Windows.Forms.Button();
            this.studentDetailsBtn = new System.Windows.Forms.Button();
            this.courseDetailsBtn = new System.Windows.Forms.Button();
            this.billButton = new System.Windows.Forms.Button();
            this.timeTableButton = new System.Windows.Forms.Button();
            this.gradeBtn = new System.Windows.Forms.Button();
            this.gradUpdateBtn = new System.Windows.Forms.Button();
            this.gradeComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // studentsComboBox
            // 
            this.studentsComboBox.DropDownWidth = 194;
            this.studentsComboBox.FormattingEnabled = true;
            this.studentsComboBox.Location = new System.Drawing.Point(96, 62);
            this.studentsComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.studentsComboBox.Name = "studentsComboBox";
            this.studentsComboBox.Size = new System.Drawing.Size(246, 24);
            this.studentsComboBox.TabIndex = 0;
            this.studentsComboBox.SelectedIndexChanged += new System.EventHandler(this.studentsComboBox_SelectedIndexChanged);
            // 
            // coursesComboBox
            // 
            this.coursesComboBox.DropDownWidth = 189;
            this.coursesComboBox.FormattingEnabled = true;
            this.coursesComboBox.Location = new System.Drawing.Point(672, 62);
            this.coursesComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.coursesComboBox.Name = "coursesComboBox";
            this.coursesComboBox.Size = new System.Drawing.Size(172, 24);
            this.coursesComboBox.TabIndex = 1;
            this.coursesComboBox.SelectedIndexChanged += new System.EventHandler(this.coursesComboBox_SelectedIndexChanged);
            // 
            // resultsListBox
            // 
            this.resultsListBox.FormattingEnabled = true;
            this.resultsListBox.ItemHeight = 16;
            this.resultsListBox.Location = new System.Drawing.Point(323, 118);
            this.resultsListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resultsListBox.Name = "resultsListBox";
            this.resultsListBox.Size = new System.Drawing.Size(354, 212);
            this.resultsListBox.TabIndex = 2;
            // 
            // viewCoursesBtn
            // 
            this.viewCoursesBtn.Location = new System.Drawing.Point(196, 118);
            this.viewCoursesBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewCoursesBtn.Name = "viewCoursesBtn";
            this.viewCoursesBtn.Size = new System.Drawing.Size(121, 53);
            this.viewCoursesBtn.TabIndex = 3;
            this.viewCoursesBtn.Text = "View Courses";
            this.viewCoursesBtn.UseVisualStyleBackColor = true;
            this.viewCoursesBtn.Click += new System.EventHandler(this.viewCoursesBtn_Click);
            // 
            // viewStudentsBtn
            // 
            this.viewStudentsBtn.Location = new System.Drawing.Point(683, 118);
            this.viewStudentsBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewStudentsBtn.Name = "viewStudentsBtn";
            this.viewStudentsBtn.Size = new System.Drawing.Size(121, 53);
            this.viewStudentsBtn.TabIndex = 4;
            this.viewStudentsBtn.Text = "View Students";
            this.viewStudentsBtn.UseVisualStyleBackColor = true;
            this.viewStudentsBtn.Click += new System.EventHandler(this.viewStudentsBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Student List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(680, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Course List";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(351, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "--->";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(633, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "--->";
            // 
            // enrolStudentBtn
            // 
            this.enrolStudentBtn.Location = new System.Drawing.Point(393, 59);
            this.enrolStudentBtn.Margin = new System.Windows.Forms.Padding(4);
            this.enrolStudentBtn.Name = "enrolStudentBtn";
            this.enrolStudentBtn.Size = new System.Drawing.Size(207, 28);
            this.enrolStudentBtn.TabIndex = 11;
            this.enrolStudentBtn.Text = "Enrol Student in Course";
            this.enrolStudentBtn.UseVisualStyleBackColor = true;
            this.enrolStudentBtn.Click += new System.EventHandler(this.enrolStudentBtn_Click);
            // 
            // addStudentBtn
            // 
            this.addStudentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addStudentBtn.Location = new System.Drawing.Point(35, 326);
            this.addStudentBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addStudentBtn.Name = "addStudentBtn";
            this.addStudentBtn.Size = new System.Drawing.Size(205, 142);
            this.addStudentBtn.TabIndex = 12;
            this.addStudentBtn.Text = "Add Student";
            this.addStudentBtn.UseVisualStyleBackColor = true;
            this.addStudentBtn.Click += new System.EventHandler(this.addStudentBtn_Click);
            // 
            // addCourseBtn
            // 
            this.addCourseBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.addCourseBtn.Location = new System.Drawing.Point(761, 326);
            this.addCourseBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addCourseBtn.Name = "addCourseBtn";
            this.addCourseBtn.Size = new System.Drawing.Size(205, 142);
            this.addCourseBtn.TabIndex = 13;
            this.addCourseBtn.Text = "Add Course";
            this.addCourseBtn.UseVisualStyleBackColor = true;
            this.addCourseBtn.Click += new System.EventHandler(this.addCourseBtn_Click);
            // 
            // studentDetailsBtn
            // 
            this.studentDetailsBtn.Location = new System.Drawing.Point(196, 176);
            this.studentDetailsBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.studentDetailsBtn.Name = "studentDetailsBtn";
            this.studentDetailsBtn.Size = new System.Drawing.Size(121, 53);
            this.studentDetailsBtn.TabIndex = 14;
            this.studentDetailsBtn.Text = "View Student Details";
            this.studentDetailsBtn.UseVisualStyleBackColor = true;
            this.studentDetailsBtn.Click += new System.EventHandler(this.studentDetailsBtn_Click);
            // 
            // courseDetailsBtn
            // 
            this.courseDetailsBtn.Location = new System.Drawing.Point(683, 176);
            this.courseDetailsBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.courseDetailsBtn.Name = "courseDetailsBtn";
            this.courseDetailsBtn.Size = new System.Drawing.Size(121, 53);
            this.courseDetailsBtn.TabIndex = 15;
            this.courseDetailsBtn.Text = "View Course Details";
            this.courseDetailsBtn.UseVisualStyleBackColor = true;
            this.courseDetailsBtn.Click += new System.EventHandler(this.courseDetailsBtn_Click);
            // 
            // billButton
            // 
            this.billButton.Location = new System.Drawing.Point(69, 118);
            this.billButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.billButton.Name = "billButton";
            this.billButton.Size = new System.Drawing.Size(121, 53);
            this.billButton.TabIndex = 16;
            this.billButton.Text = "Bill Details";
            this.billButton.UseVisualStyleBackColor = true;
            this.billButton.Click += new System.EventHandler(this.billButton_Click);
            // 
            // timeTableButton
            // 
            this.timeTableButton.Location = new System.Drawing.Point(69, 176);
            this.timeTableButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.timeTableButton.Name = "timeTableButton";
            this.timeTableButton.Size = new System.Drawing.Size(121, 53);
            this.timeTableButton.TabIndex = 17;
            this.timeTableButton.Text = "Show Time Table";
            this.timeTableButton.UseVisualStyleBackColor = true;
            this.timeTableButton.Click += new System.EventHandler(this.timeTableButton_Click);
            // 
            // gradeBtn
            // 
            this.gradeBtn.Location = new System.Drawing.Point(196, 233);
            this.gradeBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gradeBtn.Name = "gradeBtn";
            this.gradeBtn.Size = new System.Drawing.Size(121, 53);
            this.gradeBtn.TabIndex = 18;
            this.gradeBtn.Text = "Display Grades";
            this.gradeBtn.UseVisualStyleBackColor = true;
            this.gradeBtn.Click += new System.EventHandler(this.gradeBtn_Click);
            // 
            // gradUpdateBtn
            // 
            this.gradUpdateBtn.Location = new System.Drawing.Point(683, 233);
            this.gradUpdateBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gradUpdateBtn.Name = "gradUpdateBtn";
            this.gradUpdateBtn.Size = new System.Drawing.Size(121, 53);
            this.gradUpdateBtn.TabIndex = 19;
            this.gradUpdateBtn.Text = "Update Grade";
            this.gradUpdateBtn.UseVisualStyleBackColor = true;
            this.gradUpdateBtn.Click += new System.EventHandler(this.gradUpdateBtn_Click);
            // 
            // gradeComboBox
            // 
            this.gradeComboBox.DropDownWidth = 189;
            this.gradeComboBox.FormattingEnabled = true;
            this.gradeComboBox.Location = new System.Drawing.Point(810, 262);
            this.gradeComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gradeComboBox.Name = "gradeComboBox";
            this.gradeComboBox.Size = new System.Drawing.Size(172, 24);
            this.gradeComboBox.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 514);
            this.Controls.Add(this.gradeComboBox);
            this.Controls.Add(this.gradUpdateBtn);
            this.Controls.Add(this.gradeBtn);
            this.Controls.Add(this.timeTableButton);
            this.Controls.Add(this.billButton);
            this.Controls.Add(this.courseDetailsBtn);
            this.Controls.Add(this.studentDetailsBtn);
            this.Controls.Add(this.addCourseBtn);
            this.Controls.Add(this.addStudentBtn);
            this.Controls.Add(this.enrolStudentBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.viewStudentsBtn);
            this.Controls.Add(this.viewCoursesBtn);
            this.Controls.Add(this.resultsListBox);
            this.Controls.Add(this.coursesComboBox);
            this.Controls.Add(this.studentsComboBox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox studentsComboBox;
        private System.Windows.Forms.ComboBox coursesComboBox;
        private System.Windows.Forms.ListBox resultsListBox;
        private System.Windows.Forms.Button viewCoursesBtn;
        private System.Windows.Forms.Button viewStudentsBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button enrolStudentBtn;
        private System.Windows.Forms.Button addStudentBtn;
        private System.Windows.Forms.Button addCourseBtn;
        private System.Windows.Forms.Button studentDetailsBtn;
        private System.Windows.Forms.Button courseDetailsBtn;
        private System.Windows.Forms.Button billButton;
        private System.Windows.Forms.Button timeTableButton;
        private System.Windows.Forms.Button gradeBtn;
        private System.Windows.Forms.Button gradUpdateBtn;
        private System.Windows.Forms.ComboBox gradeComboBox;
    }
}

