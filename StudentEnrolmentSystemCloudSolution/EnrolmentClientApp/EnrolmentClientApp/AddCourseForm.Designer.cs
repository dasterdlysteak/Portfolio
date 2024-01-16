
namespace EnrolmentClientApp
{
    partial class AddCourseForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.addCourseListBox = new System.Windows.Forms.ListBox();
            this.addCourseBtn = new System.Windows.Forms.Button();
            this.returnBtn = new System.Windows.Forms.Button();
            this.courseNameTextBox = new System.Windows.Forms.TextBox();
            this.courseIDTextBox = new System.Windows.Forms.TextBox();
            this.schedTimeTextBox = new System.Windows.Forms.TextBox();
            this.courseCostTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.label3.Location = new System.Drawing.Point(202, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Enter Course Details";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 106);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Course Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Course ID: ";
            // 
            // addCourseListBox
            // 
            this.addCourseListBox.FormattingEnabled = true;
            this.addCourseListBox.ItemHeight = 16;
            this.addCourseListBox.Location = new System.Drawing.Point(11, 186);
            this.addCourseListBox.Margin = new System.Windows.Forms.Padding(4);
            this.addCourseListBox.Name = "addCourseListBox";
            this.addCourseListBox.Size = new System.Drawing.Size(537, 164);
            this.addCourseListBox.TabIndex = 13;
            // 
            // addCourseBtn
            // 
            this.addCourseBtn.Location = new System.Drawing.Point(383, 131);
            this.addCourseBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addCourseBtn.Name = "addCourseBtn";
            this.addCourseBtn.Size = new System.Drawing.Size(135, 49);
            this.addCourseBtn.TabIndex = 12;
            this.addCourseBtn.Text = "Add Course";
            this.addCourseBtn.UseVisualStyleBackColor = true;
            this.addCourseBtn.Click += new System.EventHandler(this.addCourseBtn_Click);
            // 
            // returnBtn
            // 
            this.returnBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.returnBtn.Location = new System.Drawing.Point(23, 369);
            this.returnBtn.Margin = new System.Windows.Forms.Padding(4);
            this.returnBtn.Name = "returnBtn";
            this.returnBtn.Size = new System.Drawing.Size(212, 133);
            this.returnBtn.TabIndex = 11;
            this.returnBtn.Text = "Return to Main Page";
            this.returnBtn.UseVisualStyleBackColor = true;
            this.returnBtn.Click += new System.EventHandler(this.returnBtn_Click);
            // 
            // courseNameTextBox
            // 
            this.courseNameTextBox.Location = new System.Drawing.Point(113, 103);
            this.courseNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.courseNameTextBox.Name = "courseNameTextBox";
            this.courseNameTextBox.Size = new System.Drawing.Size(132, 22);
            this.courseNameTextBox.TabIndex = 10;
            // 
            // courseIDTextBox
            // 
            this.courseIDTextBox.Location = new System.Drawing.Point(113, 58);
            this.courseIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.courseIDTextBox.Name = "courseIDTextBox";
            this.courseIDTextBox.Size = new System.Drawing.Size(132, 22);
            this.courseIDTextBox.TabIndex = 9;
            // 
            // schedTimeTextBox
            // 
            this.schedTimeTextBox.Location = new System.Drawing.Point(386, 103);
            this.schedTimeTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.schedTimeTextBox.Name = "schedTimeTextBox";
            this.schedTimeTextBox.Size = new System.Drawing.Size(132, 22);
            this.schedTimeTextBox.TabIndex = 17;
            // 
            // courseCostTextBox
            // 
            this.courseCostTextBox.Location = new System.Drawing.Point(386, 58);
            this.courseCostTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.courseCostTextBox.Name = "courseCostTextBox";
            this.courseCostTextBox.Size = new System.Drawing.Size(132, 22);
            this.courseCostTextBox.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(264, 106);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Scheduled Time: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 61);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "Course Cost:";
            // 
            // AddCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 515);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.courseCostTextBox);
            this.Controls.Add(this.schedTimeTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addCourseListBox);
            this.Controls.Add(this.addCourseBtn);
            this.Controls.Add(this.returnBtn);
            this.Controls.Add(this.courseNameTextBox);
            this.Controls.Add(this.courseIDTextBox);
            this.Name = "AddCourseForm";
            this.Text = "AddCourseForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox addCourseListBox;
        private System.Windows.Forms.Button addCourseBtn;
        private System.Windows.Forms.Button returnBtn;
        private System.Windows.Forms.TextBox courseNameTextBox;
        private System.Windows.Forms.TextBox courseIDTextBox;
        private System.Windows.Forms.TextBox schedTimeTextBox;
        private System.Windows.Forms.TextBox courseCostTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}