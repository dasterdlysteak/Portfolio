using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace StudentEnrolmentSystem
{
    public class Course
    {
        [DataMember]
        public string courseID;

        [DataMember]
        public string courseName;

        [DataMember]
        public decimal cost;

        [DataMember]
        public DateTime allottedTime;
    }
}