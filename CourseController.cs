using System;
using System.Collections.Generic;
using System.Text;

namespace CourseEnrollmentConsoleApp
{
    public class CourseController
    {
        CourseRepository crepo=new CourseRepository();
        public void AddCourse(Course course)
        {
            crepo.AddCourse(course);
        }

        public void ViewCourses()
        {
            crepo.ViewCourses();
        }
    }
}
