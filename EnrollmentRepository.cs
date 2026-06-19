using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseEnrollmentConsoleApp
{
    public class EnrollmentRepository
    {

        
        string connectionString = "Server=localhost;Database=courseEnrollment;Uid=root;pwd='lavanya@7002';";
        MySqlConnection con;
        public EnrollmentRepository()
        {
            con = new MySqlConnection(connectionString);
        }

        public void EnrollStudent(Enrollment enrollment)
        {
            try
            {
                if (enrollment != null)
                {
                    con.Open();
                    string query = "INSERT INTO Enrollments (StudentId, CourseId, EnrollmentDat) VALUES (@StudentId, @CourseId, @EnrollmentDat)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    
                    cmd.Parameters.AddWithValue("@StudentId", enrollment.StudentId);
                    cmd.Parameters.AddWithValue("@CourseId", enrollment.CourseId);
                    cmd.Parameters.AddWithValue("@EnrollmentDat", enrollment.EnrollmentDat);
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        Console.WriteLine("Data Inserted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Data was not Inserted");
                    }
                    con.Close();
                }
                else
                {
                    Console.WriteLine("The input is Empty");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ViewAllEnrollments()
        {

            try
            {
                con.Open();
                string query = "SELECT e.EnrollmentId, s.StudentId,s.StudentName,c.CourseId,c.CourseName,e.EnrollmentDat FROM Enrollments e INNER JOIN Students s ON e.StudentId = s.StudentId INNER JOIN Courses c ON e.CourseId = c.CourseId;";
                MySqlCommand cmd = new MySqlCommand(query, con);
                var data = cmd.ExecuteReader();

                Console.WriteLine("{0,-15} {1,-12} {2,-20} {3,-12} {4,-20} {5,-15}",
                                  "Enroll ID", "Student ID", "Student Name",
                                  "Course ID", "Course Name", "Enroll Date");

                while (data.Read())
                {
                    Console.WriteLine("{0,-15} {1,-12} {2,-20} {3,-12} {4,-20} {5,-15}",
                                      data["EnrollmentId"],
                                      data["StudentId"],
                                      data["StudentName"],
                                      data["CourseId"],
                                      data["CourseName"],
                                      Convert.ToDateTime(data["EnrollmentDat"]).ToString("yyyy-MM-dd"));
                }


                data.Close();
                con.Close();

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteEnrollment(int enrollmentId)
        {
            try
            {
                con.Open();
                string query = "Delete from Enrollments where EnrollmentId=@id";
                MySqlCommand cmd=new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", enrollmentId);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("Row Deleted");
                }
                else
                {
                    Console.WriteLine("Enrollment Id not found");
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void SerachStudentsByEnrollment(int id)
        {
            try
            {
                con.Open();
                string query = "select e.EnrollmentId, s.StudentName, c.CourseName, e.EnrollmentDat from Enrollments e Inner Join Students s on e.StudentId=s.StudentId Inner Join Courses c on e.CourseId=c.CourseId where e.StudentId=@id";
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                var data = cmd.ExecuteReader();
               
                Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-15}",
                                  "Enroll ID", "Student Name", "Course Name", "Enroll Date");
               

                while (data.Read())
                {
                    DateTime enrollDate = Convert.ToDateTime(data["EnrollmentDat"]);

                    Console.WriteLine("{0,-15} {1,-20} {2,-20} {3,-15}",
                                      data["EnrollmentId"],
                                      data["StudentName"],
                                      data["CourseName"],
                                      enrollDate.ToString("yyyy-MM-dd"));
                }

               
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        
    }
}


