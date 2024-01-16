using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace StudentEnrolmentSystem
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string studentID;

        [DataMember]
        public string studentName;

        [DataMember]
        public DateTime dateEnrolled;
    }
}