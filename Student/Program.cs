using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement

{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<MarkSheet> marks = new List<MarkSheet>();

            bool running = true;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1.Register Student");
                Console.WriteLine("2.Get Student List");
                Console.WriteLine("3.Get Student Detail by Id");
                Console.WriteLine("4.Make Marksheet");
                Console.WriteLine("5.Show Result of Student by Id");
                Console.WriteLine("6.Exit");

                Console.WriteLine("Please select an option between 1 to 6.");

                string input = Console.ReadLine();
                int choice;

                if (int.TryParse(input, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            RegisterStudent(students);
                            break;
                        case 2:
                            GetStudentList(students);
                            break;
                        case 3:
                            GetStudentDetailbyID(students);
                            break;
                        case 4:
                            MakeMarksheet(students, marks);
                            break;
                        case 5:
                            ShowResultofStudentbyID(students, marks);
                            break;
                        case 6:
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid input. Please select a valid option.");
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input,Please enter a number between 1 to 6.");
                }

            } while (running);

        }

        static void RegisterStudent(List<Student> students)
        {
            Console.WriteLine("Enter Student ID:");
            string input = Console.ReadLine();
            int id;

            bool checkid = int.TryParse(input, out id);

            var student = students.FirstOrDefault(s => s.ID == id);
            if (checkid)
            {
                if (student != null)
                {
                    if (id != student.ID)
                    {
                        Console.WriteLine("Enter Student First Name:");
                        String firstname = Console.ReadLine();

                        Console.WriteLine("Enter Student Last Name:");
                        string lastname = Console.ReadLine();

                        Console.WriteLine("Enter Student Age:");
                        int age = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter Student City:");
                        string city = Console.ReadLine();

                        students.Add(new Student
                        {
                            ID = id,
                            FirstName = firstname,
                            LastName = lastname,
                            Age = age,
                            City = city
                        });
                    }
                    else
                    {
                        Console.WriteLine("Id is already registered.");
                    }

                }
                else
                {
                    Console.WriteLine("Enter Student First Name:");
                    String firstname = Console.ReadLine();

                    Console.WriteLine("Enter Student Last Name:");
                    string lastname = Console.ReadLine();

                    Console.WriteLine("Enter Student Age:");
                    int age = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Student City:");
                    string city = Console.ReadLine();

                    students.Add(new Student
                    {
                        ID = id,
                        FirstName = firstname,
                        LastName = lastname,
                        Age = age,
                        City = city
                    });
                }

            }
            else
            {
                Console.WriteLine("Id is Invalid.");
            }

        }

        static void GetStudentList(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No Student Data.");
            }
            else
            {
                Console.WriteLine("Student List:");
                int idWidth = 5;
                int firstnameWidth = 15;
                int lastnameWidth = 15;
                int ageWidth = 5;
                int cityWidth = 10;

                Console.WriteLine($"{"ID".PadRight(idWidth)}{"FirstName".PadRight(firstnameWidth)}{"LastName".PadRight(lastnameWidth)}{"Age".PadRight(ageWidth)}{"City".PadRight(cityWidth)} \n");
                foreach (var student in students)
                {
                    Console.WriteLine($"{student.ID.ToString().PadRight(idWidth)}{student.FirstName.PadRight(firstnameWidth)}{student.LastName.ToString().PadRight(lastnameWidth)}{student.Age.ToString().PadRight(ageWidth)}{student.City.ToString().PadRight(cityWidth)}");

                }

            }
        }

        static void GetStudentDetailbyID(List<Student> students)
        {

            Console.WriteLine("Enter Student ID:");
            string input = Console.ReadLine();
            int id;

            bool checkid = int.TryParse(input, out id);

            var student = students.FirstOrDefault(s => s.ID == id);
            if (checkid)
            {
                if (student != null)
                {
                    int idWidth = 5;
                    int firstnameWidth = 15;
                    int lastnameWidth = 15;
                    int ageWidth = 5;
                    int cityWidth = 10;

                    Console.WriteLine($"{"ID".PadRight(idWidth)}{"FirstName".PadRight(firstnameWidth)}{"LastName".PadRight(lastnameWidth)}{"Age".PadRight(ageWidth)}{"City".PadRight(cityWidth)} \n");
                    Console.WriteLine($"{student.ID.ToString().PadRight(idWidth)}{student.FirstName.PadRight(firstnameWidth)}{student.LastName.ToString().PadRight(lastnameWidth)}{student.Age.ToString().PadRight(ageWidth)}{student.City.ToString().PadRight(cityWidth)}");
                }
                else
                {
                    Console.WriteLine("Id is not registered.");
                }


            }
            else
            {
                Console.WriteLine("Id is Invalid.");
            }
        }

        static void MakeMarksheet(List<Student> students, List<MarkSheet> marks)
        {
            Console.WriteLine("Enter Student ID:");
            string input = Console.ReadLine();
            int id;

            bool checkid = int.TryParse(input, out id);

            var student = students.FirstOrDefault(s => s.ID == id);

            var mark = marks.FirstOrDefault(s => s.StudentId == id);

            if (checkid)
            {
                if (mark != null)
                {
                    if (id != mark.StudentId)
                    {
                        Console.WriteLine("Enter Mathematics marks:");
                        int marksofmath;
                        while (!(int.TryParse(Console.ReadLine(), out marksofmath)) || marksofmath < 0)
                        {
                            Console.WriteLine("Marks is Invalid.Please Enter a Valid Mark:");
                        }

                        Console.WriteLine("Enter Science marks:");
                        int marksofscience;
                        while (!(int.TryParse(Console.ReadLine(), out marksofscience)) || marksofscience < 0)
                        {
                            Console.WriteLine("Marks is Invalid.Please Enter a Valid Mark:");
                        }

                        Console.WriteLine("Enter English marks:");
                        int marksofenglish;
                        while (!(int.TryParse(Console.ReadLine(), out marksofenglish)) || marksofenglish < 0)
                        {
                            Console.WriteLine("Marks is Invalid.Please Enter a Valid Mark:");
                        }

                        Console.WriteLine("Enter SocialScience marks:");
                        int marksofsocialscience;
                        while (!(int.TryParse(Console.ReadLine(), out marksofsocialscience)) || marksofsocialscience < 0)
                        {
                            Console.WriteLine("Marks is Invalid.Please Enter a Valid Mark:");
                        }

                        Console.WriteLine("Enter Hindi marks:");
                        int marksofhindi;
                        while (!(int.TryParse(Console.ReadLine(), out marksofhindi)) || marksofhindi < 0)
                        {
                            Console.WriteLine("Marks is Invalid.Please Enter a Valid Mark:");
                        }

                        Console.WriteLine("Enter Gujarati marks:");
                        int marksofgujarati;
                        while (!(int.TryParse(Console.ReadLine(), out marksofgujarati)) || marksofgujarati < 0)
                        {
                            Console.WriteLine("Marks is Invalid.Please Enter a Valid Mark:");
                        }

                        int obtainedmarks = marksofmath + marksofscience + marksofsocialscience + marksofenglish + marksofhindi + marksofgujarati;

                        int totalmark = 600;
                        int percentage = obtainedmarks * 100 / totalmark;
                        string grade;
                        string result;

                        if (90 < percentage && percentage <= 100)
                        {
                            grade = "A1";
                        }
                        else if (80 < percentage && percentage <= 90)
                        {
                            grade = "A2";
                        }
                        else if (70 < percentage && percentage <= 80)
                        {
                            grade = "B1";
                        }
                        else if (60 < percentage && percentage <= 70)
                        {
                            grade = "B2";
                        }
                        else if (50 < percentage && percentage <= 60)
                        {
                            grade = "C1";
                        }
                        else if (40 < percentage && percentage <= 50)
                        {
                            grade = "C2";
                        }
                        else if (32 < percentage && percentage <= 40)
                        {
                            grade = "D";
                        }
                        else if (20 < percentage && percentage <= 32)
                        {
                            grade = "E1";
                        }
                        else
                        {
                            grade = "E2";
                        }

                        if (mark.Mathematics <= 32 || mark.Science <= 32 || mark.English <= 32 || mark.SocialScience <= 32 || mark.Hindi <= 32 || mark.Gujarati <= 32)
                        {
                            result = "FAIL";
                        }
                        else
                        {
                            result = "PASS";
                        }

                        marks.Add(new MarkSheet { StudentId = id, Mathematics = marksofmath, Science = marksofscience, English = marksofenglish, SocialScience = marksofsocialscience, Hindi = marksofhindi, Gujarati = marksofgujarati, ObtainedMark = obtainedmarks, TotalMark = totalmark, Percentage = percentage, Grade = grade, Result = result });

                        Console.WriteLine("Marks Registered Successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Marks already registered.");
                    }
                }
                else if (student == null)
                {
                    Console.WriteLine("Id is not registered.");
                }
                else
                {
                    Console.WriteLine("Enter Mathematics marks:");
                    int marksofmath;
                    while (!int.TryParse(Console.ReadLine(), out marksofmath) || marksofmath < 0)
                    {
                        Console.WriteLine("Marks is Invalid.Please Enter a Valid Mark:");
                    }

                    Console.WriteLine("Enter Science marks:");
                    int marksofscience;
                    while (!(int.TryParse(Console.ReadLine(), out marksofscience)) || marksofscience < 0)
                    {
                        Console.WriteLine("Marks is Invalid.Please Enter a Valid Mark:");
                    }

                    Console.WriteLine("Enter English marks:");
                    int marksofenglish;
                    while (!(int.TryParse(Console.ReadLine(), out marksofenglish)) || marksofenglish < 0)
                    {
                        Console.WriteLine("Marks is Invalid.Please Enter a Valid Mark:");
                    }

                    Console.WriteLine("Enter SocialScience marks:");
                    int marksofsocialscience;
                    while (!(int.TryParse(Console.ReadLine(), out marksofsocialscience)) || marksofsocialscience < 0)
                    {
                        Console.WriteLine("Marks is Invalid.Please Enter a Valid Mark:");
                    }

                    Console.WriteLine("Enter Hindi marks:");
                    int marksofhindi;
                    while (!(int.TryParse(Console.ReadLine(), out marksofhindi)) || marksofhindi < 0)
                    {
                        Console.WriteLine("Marks is Invalid.Please Enter a Valid Mark:");
                    }

                    Console.WriteLine("Enter Gujarati marks:");
                    int marksofgujarati;
                    while (!(int.TryParse(Console.ReadLine(), out marksofgujarati)) || marksofgujarati < 0)
                    {
                        Console.WriteLine("Marks is Invalid.Please Enter a Valid Mark:");
                    }

                    int obtainedmarks = marksofmath + marksofscience + marksofsocialscience + marksofenglish + marksofhindi + marksofgujarati;

                    int totalmark = 600;
                    int percentage = obtainedmarks * 100 / totalmark;
                    string grade;
                    string result;

                    if (90 < percentage && percentage <= 100)
                    {
                        grade = "A1";
                    }
                    else if (80 < percentage && percentage <= 90)
                    {
                        grade = "A2";
                    }
                    else if (70 < percentage && percentage <= 80)
                    {
                        grade = "B1";
                    }
                    else if (60 < percentage && percentage <= 70)
                    {
                        grade = "B2";
                    }
                    else if (50 < percentage && percentage <= 60)
                    {
                        grade = "C1";
                    }
                    else if (40 < percentage && percentage <= 50)
                    {
                        grade = "C2";
                    }
                    else if (32 < percentage && percentage <= 40)
                    {
                        grade = "D";
                    }
                    else if (20 < percentage && percentage <= 32)
                    {
                        grade = "E1";
                    }
                    else
                    {
                        grade = "E2";
                    }

                    if (marksofmath <= 32 || marksofscience <= 32 || marksofenglish <= 32 || marksofsocialscience <= 32 || marksofhindi <= 32 || marksofgujarati <= 32)
                    {
                        result = "FAIL";
                    }
                    else
                    {
                        result = "PASS";
                    }

                    marks.Add(new MarkSheet { StudentId = id, Mathematics = marksofmath, Science = marksofscience, English = marksofenglish, SocialScience = marksofsocialscience, Hindi = marksofhindi, Gujarati = marksofgujarati, ObtainedMark = obtainedmarks, TotalMark = totalmark, Percentage = percentage, Grade = grade, Result = result });

                    Console.WriteLine("Marks Registered Successfully.");

                }

            }
            else
            {
                Console.WriteLine("Id is Invalid.");
            }

        }

        static void ShowResultofStudentbyID(List<Student> students, List<MarkSheet> marks)
        {
            Console.WriteLine("Enter Student ID:");
            string input = Console.ReadLine();
            int id;

            bool checkid = int.TryParse(input, out id);

            var student = students.FirstOrDefault(s => s.ID == id);

            var mark = marks.FirstOrDefault(s => s.StudentId == id);

            if (checkid)
            {
                if (mark != null)
                {
                    int idWidth = 5;
                    int firstnameWidth = 15;
                    int lastnameWidth = 15;
                    int obtainedMarkWidth = 15;
                    int percentageWidth = 15;
                    int gradeWidth = 15;
                    int totalmarkWidth = 15;
                    int resultWidth = 15;

                    Console.WriteLine($"{"ID".PadRight(idWidth)}{"FirstName".PadRight(firstnameWidth)}{"LastName".PadRight(lastnameWidth)}{"ObtainedMark".PadRight(obtainedMarkWidth)}{"Percentage".PadRight(percentageWidth)}{"Grade".PadRight(gradeWidth)}{"TotalMark".PadRight(totalmarkWidth)}{"Result".PadRight(resultWidth)} \n");

                    Console.WriteLine($"{student.ID.ToString().PadRight(idWidth)}{student.FirstName.PadRight(firstnameWidth)}{student.LastName.PadRight(lastnameWidth)}{mark.ObtainedMark.ToString().PadRight(obtainedMarkWidth)}{mark.Percentage.ToString().PadRight(percentageWidth)}{mark.Grade.PadRight(gradeWidth)}{mark.TotalMark.ToString().PadRight(totalmarkWidth)}{mark.Result.PadRight(resultWidth)}");
                }
                else if (student == null)
                {
                    Console.WriteLine("Id is not registered.");
                }
                else
                {
                    Console.WriteLine("Mark is not registered.");
                }

            }
            else
            {
                Console.WriteLine("Id is Invalid.");
            }
        }

    }
    
}
