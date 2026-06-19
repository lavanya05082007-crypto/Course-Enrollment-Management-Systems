using System;
using System.Collections.Generic;
using System.Text;

namespace CourseEnrollmentConsoleApp
{
    public class StudentController
    {
        StudentRepository srepo=new StudentRepository();
        public void AddStudent(Student student)
        {
            srepo.AddStudent(student);
        }

        public void ViewStudent()
        {
            srepo.ViewStudent();
        }
    }
}
