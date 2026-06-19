using MySql.Data.MySqlClient;

namespace CourseEnrollmentConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool continuepgm = true;
            while (continuepgm)
            {
                Console.WriteLine("========== Course Enrollment Management System ==========");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. View Courses");
                Console.WriteLine("5. Enroll Student in Course");
                Console.WriteLine("6. View All Enrollments");
                Console.WriteLine("7. Search Student Enrollments");
                Console.WriteLine("8. Delete Enrollment");
                Console.WriteLine("9. Exit");

                Console.Write("Enter your choice to perform specified operation: ");
                int ch=int.Parse(Console.ReadLine());

                switch (ch)
                {
                    case 1:

                        
                        try
                        {
                            StudentController sc = new StudentController();
                    
                            int sid;

                            while (true)
                            {
                                Console.Write("Enter Student Id: ");

                                if (int.TryParse(Console.ReadLine(), out sid) && sid > 0)
                                    break;

                                Console.WriteLine("Student Id must be a positive number.");
                            }

                            
                            string name;

                            do
                            {
                                Console.Write("Enter Student Name: ");
                                name = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(name))
                                {
                                    Console.WriteLine("Name cannot be empty.");
                                }

                            } while (string.IsNullOrWhiteSpace(name));
                           
                            string email;

                            do
                            {
                                Console.Write("Enter Student Email: ");
                                email = Console.ReadLine();

                                if (!email.Contains("@") || !email.Contains("."))
                                {
                                    Console.WriteLine("Invalid Email Format.");
                                }

                            } while (!email.Contains("@") || !email.Contains("."));
                            
                            string dept;

                            do
                            {
                                Console.Write("Enter Department: ");
                                dept = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(dept))
                                {
                                    Console.WriteLine("Department cannot be empty.");
                                }

                            } while (string.IsNullOrWhiteSpace(dept));

                            Student student = new Student(sid, name, email, dept);
                            sc.AddStudent(student);
                            Console.WriteLine();
                        }
                        catch (MySqlException ex)
                        {
                            if (ex.Number == 1062)
                            {
                                Console.WriteLine("Student ID already exists. Enter a different ID.");
                            }
                            else
                            {
                                Console.WriteLine("Database Error: " + ex.Message);
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input format.");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Input value is too large.");
                        }
                        
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        
                        break;


                    case 2:
                       
                        try
                        {
                            StudentController sc = new StudentController();
                            Console.WriteLine("Student Details Available");
                            Console.WriteLine();
                            sc.ViewStudent();
                            Console.WriteLine();

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input format.");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Input value is too large.");
                        }
                        catch (MySqlException e)
                        {
                            Console.WriteLine("Database Error: " + e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;


                    case 3:
                        
                        try
                        {
                            CourseController cc = new CourseController();
                            
                            int cid;

                            while (true)
                            {
                                Console.Write("Enter Course Id: ");

                                if (int.TryParse(Console.ReadLine(), out cid) && cid > 0)
                                    break;

                                Console.WriteLine("Course Id must be a positive number.");
                            }
                           
                            string cname;

                            do
                            {
                                Console.Write("Enter Course Name: ");
                                cname = Console.ReadLine();

                                if (string.IsNullOrWhiteSpace(cname))
                                {
                                    Console.WriteLine("Name cannot be empty.");
                                }

                            } while (string.IsNullOrWhiteSpace(cname));
                            
                            int du;

                            while (true)
                            {
                                Console.Write("Enter Course Duration (months): ");

                                if (int.TryParse(Console.ReadLine(), out du) && du > 0)
                                {
                                    break;
                                }

                                Console.WriteLine("Duration must be greater than 0.");
                            }
                            
                            decimal fee;

                            while (true)
                            {
                                Console.Write("Enter Course Fee: ");

                                if (decimal.TryParse(Console.ReadLine(), out fee) && fee > 0)
                                {
                                    break;
                                }

                                Console.WriteLine("Fee must be greater than 0.");
                            }

                            Course course = new Course(cid, cname, du, fee);
                            cc.AddCourse(course);
                            Console.WriteLine();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input format.");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Input value is too large.");
                        }
                        catch (MySqlException e)
                        {
                            Console.WriteLine("Database Error: " + e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 4:
                        
                        try
                        {
                            CourseController cc = new CourseController();
                            Console.WriteLine("Course Details Available");
                            Console.WriteLine();
                            cc.ViewCourses();
                            Console.WriteLine();

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input format.");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Input value is too large.");
                        }
                        catch (MySqlException e)
                        {
                            Console.WriteLine("Database Error: " + e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 5:
                       

                        try
                        {
                            EnrollmentController ec = new EnrollmentController();
                            
                            int sid;

                            while (true)
                            {
                                Console.Write("Enter Student Id: ");

                                if (int.TryParse(Console.ReadLine(), out sid) && sid > 0)
                                    break;

                                Console.WriteLine("Student Id must be a positive number.");
                            }
                            
                            int cid;

                            while (true)
                            {
                                Console.Write("Enter Course Id: ");

                                if (int.TryParse(Console.ReadLine(), out cid) && cid > 0)
                                    break;

                                Console.WriteLine("Course Id must be a positive number.");
                            }
              
                            DateTime enrollmentDate;

                            while (true)
                            {
                                Console.Write("Enter Enrollment Date (yyyy-MM-dd): ");

                                if (DateTime.TryParse(Console.ReadLine(), out enrollmentDate))
                                {
                                    break;
                                }

                                Console.WriteLine("Invalid date format.");
                            }

                            Enrollment e = new Enrollment(sid, cid, enrollmentDate);
                            ec.EnrollStudent(e);
                            Console.WriteLine();


                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input format.");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Input value is too large.");
                        }
                        catch (MySqlException e)
                        {
                            Console.WriteLine("Database Error: " + e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;

                    case 6:

                        try
                        {
                            EnrollmentController ec = new EnrollmentController();
                            Console.WriteLine("Student Details Available");
                            Console.WriteLine();
                            ec.ViewAllEnrollments();
                            Console.WriteLine();

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input format.");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Input value is too large.");
                        }
                        catch (MySqlException e)
                        {
                            Console.WriteLine("Database Error: " + e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 7:
                        try
                        {
                            EnrollmentController ec = new EnrollmentController();
                            Console.WriteLine("Enter Student Id to search: ");
                            int id = int.Parse(Console.ReadLine());
                            ec.SerachStudentsByEnrollment(id);
                            Console.WriteLine();

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input format.");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Input value is too large.");
                        }
                        catch (MySqlException e)
                        {
                            Console.WriteLine("Database Error: " + e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;



                    case 8:
                        try
                        {
                            EnrollmentController ec = new EnrollmentController();
                            Console.WriteLine("Enter Id to delete");
                            int id = int.Parse(Console.ReadLine());
                            ec.DeleteEnrollment(id);
                            Console.WriteLine();


                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input format.");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Input value is too large.");
                        }
                        catch (MySqlException e)
                        {
                            Console.WriteLine("Database Error: " + e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 9:
                        continuepgm = false;
                        Console.WriteLine("Program Ended.");
                        break;

                }
                    Console.Write("Do you want to continue still? (Y/N): ");
                    string answer = Console.ReadLine();

                    if (answer.ToUpper() != "Y")
                    {
                       continuepgm = false;
                    }

                
                

            }
            Console.WriteLine(">>Program Terminated<<");

        }
        }
}
