using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;

namespace StudentEnrolmentSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "EnrolmentSystem" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select EnrolmentSystem.svc or EnrolmentSystem.svc.cs at the Solution Explorer and start debugging.
    public class EnrolmentSystem : IEnrolmentSystem
    {
        StudentDataSetTableAdapters.studentTableAdapter StudentTA = new StudentDataSetTableAdapters.studentTableAdapter();
        CourseDataSetTableAdapters.courseTableAdapter CourseTA = new CourseDataSetTableAdapters.courseTableAdapter();
        EnrolmentDataSetTableAdapters.enrolmentTableAdapter EnrolmentTA = new EnrolmentDataSetTableAdapters.enrolmentTableAdapter();
        public string addCourse(string courseID, string courseName, decimal cost, DateTime allottedTime)
        {

            CourseTA.InsertQuery(courseID, courseName, cost, allottedTime);
            return "Course Added Successfully";
            
        }

        public string addStudent(string studentID, string studentName, DateTime dateEnrolled)
        {
            StudentTA.InsertQuery(studentID, studentName, dateEnrolled.ToString());
            return "Student Successfully Entered";
        }


        public string enrolStudent(string studentID, string courseID)
        {
            EnrolmentTA.InsertQuery(courseID, studentID);
            return "Student Successfully Enrolled";
        }

        public List<Course> getCoursesForStudent(string studentID)
        {
            List<Enrolment> enrolmentList = new List<Enrolment>();
            List<Course> studentCourses = new List<Course>();
            enrolmentList = getEnrolmentForStudent(studentID);
            foreach (Enrolment enrolment in enrolmentList)
            {
                Course Course = new Course();
                Course = viewCourseDetails(enrolment.courseID);
                studentCourses.Add(Course);
            }
            return studentCourses;
        }

        public List<Course> getCourses()
        {
            
            try
            {
                CourseDataSet.courseDataTable courseTable = CourseTA.GetData();
                List<Course> courseList = new List<Course>();
                foreach (DataRow row in courseTable)
                {
                    Course course = new Course();
                    course.courseID = row["courseID"].ToString();
                    course.courseName = row["courseName"].ToString();
                    course.cost = (decimal)row["cost"];
                    // need to fix DateTime so that it only send and retrieves the Time portion
                    course.allottedTime = (DateTime)row["allottedTime"];
                    courseList.Add(course);
                }
                return courseList;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                Console.WriteLine($"Exception in getCourses: {ex.Message}");
                throw; // Rethrow the exception

            }
            
        }

        // may need to tweak based on client functionality
        public List<Enrolment> getEnrolmentForStudent(string studentID)
        {
            EnrolmentDataSet.enrolmentDataTable enrolmentTable = EnrolmentTA.GetEnrolmentsForStudent(studentID);
            List<Enrolment> enrolmentList = new List<Enrolment>();
            foreach (DataRow row in enrolmentTable)
            {
                Enrolment enrolment = new Enrolment();
                enrolment.studentID = row["studentID"].ToString();
                enrolment.courseID = row["courseID"].ToString();
                enrolment.grade = row["grade"].ToString();
                enrolmentList.Add(enrolment);
            }
            return enrolmentList;
        }

        public List<Student> getStudentsInCourse(string courseID)
        {
            List<Enrolment> enrolmentList = new List<Enrolment>();
            List<Student> studentList = new List<Student>();
            enrolmentList = getEnrolmentForCourse(courseID);
            foreach (Enrolment enrolment in enrolmentList)
            {
                Student student = new Student();
                student = viewStudentDetails(enrolment.studentID);
                studentList.Add(student);
            }
            return studentList;
        }

        public List<Enrolment> getEnrolmentForCourse(string courseID)
        {
            EnrolmentDataSet.enrolmentDataTable enrolmentTable = EnrolmentTA.GetEnrolmentsForCourse(courseID);
            List<Enrolment> enrolmentList = new List<Enrolment>();
            foreach (DataRow row in enrolmentTable)
            {
                Enrolment enrolment = new Enrolment();
                enrolment.studentID = row["studentID"].ToString();
                enrolment.courseID = row["courseID"].ToString();
                enrolment.grade = row["grade"].ToString();
                enrolmentList.Add(enrolment);
            }
            return enrolmentList;
        }

        // Im pretty sure this is redundant but i will leave for now: note to self delete if not used
        public List<string> getGrades(string studentID)
        {
            List<Enrolment> enrolmentList = getEnrolmentForStudent(studentID);
            List<string> grades = new List<string>();
            foreach(Enrolment enrolment in enrolmentList)
            {
                string grade = enrolment.courseID + ": " + enrolment.grade;
                grades.Add(grade);
            }
            return grades;
        }

        public string setGrade(string studentID, string courseID, string grade)
        {
            EnrolmentTA.SetGrade(grade, courseID, studentID);
            return ("Course ID: " + courseID + " Updated Grade: " + grade);
        }

        public Course viewCourseDetails(string courseID)
        {
            CourseDataSet.courseDataTable courseTable = CourseTA.GetCourse(courseID);
            Course course = new Course();
            CourseDataSet.courseRow row = courseTable.Rows[0] as CourseDataSet.courseRow;
            course.courseID = row["courseID"].ToString();
            course.courseName = row["courseName"].ToString();
            course.cost = (decimal)row["cost"];
            course.allottedTime = (DateTime)row["allottedTime"];

            return course;
        }

        public Student viewStudentDetails(string studentID)
        {
            StudentDataSet.studentDataTable studentTable = StudentTA.GetStudent(studentID);
            Student student = new Student();
            StudentDataSet.studentRow row = studentTable.Rows[0] as StudentDataSet.studentRow;
            student.studentID = row["studentID"].ToString();
            student.studentName = row["studentName"].ToString();
            student.dateEnrolled = (DateTime)row["dateEnrolled"];

            return student;
        }


        /*this method is rudantant as it will do the same thing as getBill and getCoursesForStudent
         * public string viewTimetable(string studentID)
        {
            List<Course> studentCourses = new List<Course>;
            studentCourses = getCoursesForStudent();
            return studentCourses;
            throw new NotImplementedException();
        }*/

        public List<Student> getStudents()
        {
            StudentDataSet.studentDataTable studentTable = StudentTA.GetData();
            List<Student> studentList = new List<Student>();
            foreach (DataRow row in studentTable)
            {
                Student student = new Student();
                student.studentID = row["studentID"].ToString();
                student.studentName = row["studentName"].ToString();
                student.dateEnrolled = (DateTime)row["dateEnrolled"];
                studentList.Add(student);
            }
            return studentList;
        }

    }
}
