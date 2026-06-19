using System;
using System.Collections.Generic;
using System.Text;

namespace CourseEnrollmentConsoleApp
{
    public class Enrollment
    {
        public int EnrollmentId {  get; set; }
        public int StudentId {  get; set; }
        public int CourseId {  get; set; }
        public DateTime EnrollmentDat {  get; set; }

        public Enrollment()
        {
            
        }

        public Enrollment(int enrollmentId)
        {
            EnrollmentId = enrollmentId;
        }


        public Enrollment(int StudentId, int CourseId, DateTime EnrollmentDat) 
        {
            
            this.StudentId = StudentId;
            this.CourseId = CourseId;
            this.EnrollmentDat = EnrollmentDat;
        }
    }
}
