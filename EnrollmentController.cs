using System;
using System.Collections.Generic;
using System.Text;

namespace CourseEnrollmentConsoleApp
{
    public class EnrollmentController
    {
        EnrollmentRepository erepo=new EnrollmentRepository();

        public void EnrollStudent(Enrollment enrollment)
        {
            erepo.EnrollStudent(enrollment);
        }

        public void ViewAllEnrollments()
        {
            erepo.ViewAllEnrollments();
        }

        public void DeleteEnrollment(int enrollmentId)
        {
            erepo.DeleteEnrollment(enrollmentId);
        }

        public void SerachStudentsByEnrollment(int id)
        {
            erepo.SerachStudentsByEnrollment(id);
        }


    }
}
