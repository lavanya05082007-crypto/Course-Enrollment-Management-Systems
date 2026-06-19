using System;
using System.Collections.Generic;
using System.Text;

namespace CourseEnrollmentConsoleApp
{
    public class Course
    {
        public int CourseId {  get; set; }
        public string CourseName {  get; set; }
        public int Duration {  get; set; }
        public decimal Fee {  get; set; }

        public Course()
        {
            
        }

        public Course(int CourseId, string CourseName, int Duration, decimal Fee)
        {
            this.CourseId = CourseId;
            this.CourseName = CourseName;
            this.Duration = Duration;
            this.Fee = Fee;
        }
        

    }
}
