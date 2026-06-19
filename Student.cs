using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CourseEnrollmentConsoleApp
{
    public class Student
    {
        public int StudentId {  get; set; }
        public string StudentName {  get; set; }
        public string Email {  get; set; }
        public string Department {  get; set; }

        public Student()
        {
            
        }

        public Student(int StudentId, string StudentName, string Email, string Department)
        {
           
               
                this.StudentId = StudentId;
                this.StudentName = StudentName;
                this.Email = Email;
                this.Department = Department;
            
           
        }
        
    }
}
