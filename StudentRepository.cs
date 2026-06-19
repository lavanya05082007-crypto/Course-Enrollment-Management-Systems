using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseEnrollmentConsoleApp
{
    public class StudentRepository
    {
        string connectionString = "Server=localhost;Database=courseEnrollment;Uid=root;pwd='lavanya@7002';";
        MySqlConnection con;
        public StudentRepository()
        {
            con=new MySqlConnection(connectionString);
        }

        public void AddStudent(Student student)
        {
       
                if (student != null)
                {
                    con.Open();
                    string query = "Insert into Students values(@id, @name, @email, @dept)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@id", student.StudentId);
                    cmd.Parameters.AddWithValue("@name", student.StudentName);
                    cmd.Parameters.AddWithValue("@email", student.Email);
                    cmd.Parameters.AddWithValue("@dept", student.Department);
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

        public void ViewStudent()
        {
            try
            { 
                con.Open();
                string query = "select*from Students";
                MySqlCommand cmd = new MySqlCommand(query, con);
                var data=cmd.ExecuteReader();
                List<Student> students = new List<Student> ();
                while (data.Read())
                {
                    Student student = new Student
                    {
                        StudentId = data.GetInt32("StudentId"),
                        StudentName = data.GetString("StudentName"),
                        Email = data.GetString("Email"),
                        Department = data.GetString("Department")
                    };

                    students.Add(student);

                }
                Console.WriteLine("StudentId  StudentName      Email                Department");
                
                foreach (Student s in students)
                {
                    

                    Console.WriteLine($"{s.StudentId,-10} {s.StudentName,-15} {s.Email,-20} {s.Department,-10}");
                    

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

