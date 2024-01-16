using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace StudentEnrolmentSystem
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEnrolmentSystem" in both code and config file together.
    [ServiceContract]
    public interface IEnrolmentSystem
    {
        // ask nadil about how a DAO factors into the method implementation 

        // ask whether we need to have seperate service contracts for different methods and how to
        // orginise if so 
        /*-------------------------------------------------------------------------------
                  These are the methods related to the Student Class 
        */

        [OperationContract]
        string addStudent(string studentID, string studentName, DateTime dateEnrolled);
        [OperationContract]
        List<Course> getCoursesForStudent(string studentID);
        [OperationContract]// im not sure if i need this for this method ask nadil

        // may need to change to toString if that is all we need.
        // or a list of Enrolments - this looks like the winner as other methods will need the list
        List<Enrolment> getEnrolmentForStudent(string studentID);

        [OperationContract]
        Student viewStudentDetails(string studentID);
        
        // prints enrolments to the screen via calling the getEnrolment method
        
        /*-------------------------------------------------------------------------------
                  These are the methods related to the Course Class 
        */
        [OperationContract]
        string addCourse(string courseID, string courseName, decimal cost, DateTime allottedTime);

        [OperationContract]
        // ask nadil if getting the enrolments and querying from that would be better than just returning a
        // list of students
        List<Student> getStudentsInCourse(string courseID);
        [OperationContract]
        Course viewCourseDetails(string courseID);
        [OperationContract]
        // creates a list of courses
        List<Course> getCourses();
        //[OperationContract] do we need these are we implementing 
        // void setAllotedTime();
        //[OperationContract]
        // string getAllotedTime();]
        [OperationContract]
        List<Enrolment> getEnrolmentForCourse(string courseID);

        /*-------------------------------------------------------------------------------
                  These are the methods related to the Course Class 
        */
        [OperationContract]
        string setGrade(string studentID, string courseID, string grade);
        [OperationContract]
        List<string> getGrades(string studentID);
        [OperationContract]
        string enrolStudent(string studentID, string courseID);

        [OperationContract]
        List<Student> getStudents();

    }
}
