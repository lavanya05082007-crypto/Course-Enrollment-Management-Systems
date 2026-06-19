using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Xml.Linq;

namespace CourseEnrollmentConsoleApp
{
    public class CourseRepository
    {
        
        string connectionString = "Server=localhost;Database=courseEnrollment;Uid=root;pwd='lavanya@7002';";
        MySqlConnection con;
        public CourseRepository()
        {
            con = new MySqlConnection(connectionString);
        }

        public void AddCourse(Course course)
        {
            try
            {

                if (course != null)
                {
                    con.Open();
                    

                    string query = "INSERT INTO Courses(CourseId, CourseName, Duration, Fee)VALUES(@id, @name, @duration, @fee)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", course.CourseId);
                    cmd.Parameters.AddWithValue("@name", course.CourseName);
                    cmd.Parameters.AddWithValue("@duration", course.Duration);
                    cmd.Parameters.AddWithValue("@fee", course.Fee);
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

        public void ViewCourses()
        {
            try
            {
                con.Open();
                string query = "select*from Courses";
                MySqlCommand cmd = new MySqlCommand(query, con);
                var data = cmd.ExecuteReader();
                List<Course> courses = new List<Course>();
                while (data.Read())
                {
                    Course course = new Course
                    {
                        CourseId = data.GetInt32("CourseId"),
                        CourseName = data.GetString("CourseName"),
                        Duration=data.GetInt32("Duration"),
                        Fee = data.GetDecimal("Fee")
                    };

                    courses.Add(course);

                }
                Console.WriteLine("CourseId  CourseName      Duration                Fee");
                
                foreach (Course s in courses)
                {


                    Console.WriteLine($"{s.CourseId,-10} {s.CourseName,-15} {s.Duration,-20} {s.Fee,-10}");


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
