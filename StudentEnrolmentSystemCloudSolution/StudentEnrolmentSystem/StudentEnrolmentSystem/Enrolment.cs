using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace StudentEnrolmentSystem
{
    [DataContract]
    public class Enrolment
    {
        [DataMember]
        public string studentID;

        [DataMember]
        public string courseID;

        [DataMember]
        public string grade;
    }
}