using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json;

namespace StudentManagementSystem
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Grade { get; set; }

        public string Address { get; set; }
        public string Branch { get; set; }

        //Use List to hold student records in memory

        static List<Student> students = new List<Student>();
        //Here students is a list name that contains Student class objects 

       //----------------------Now Creating Menu for User Interaction----------------------

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n Student Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Student");
                Console.WriteLine("3. Edit Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Save To File");
                Console.WriteLine("6. Load From File");
                Console.WriteLine("7. Exit");
                Console.Write("Choose an Option: ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        ViewStudent();
                        break;
                    case "3":
                        EditStudent();
                        break;
                    case "4":
                        DeleteStudent();
                        break;
                    case "5":
                        SaveToFile();
                        break;
                    case "6":
                        LoadFromFile();
                        break;
                    case "7": return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }


        //---------------------------Now Adding a Student in the list---------------------
        static void AddStudent()
        {
            Console.WriteLine("\n ---Add Student---");
            Student student = new Student();

            Console.Write("Enter Id: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Please enter in number form.");
                return;
            }
            else
            {
                student.Id = id;
            }

            Console.Write("Enter Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter Age: ");
            if (!int.TryParse(Console.ReadLine(), out int age))
            {
                Console.WriteLine("Please enter in number form.");
                return;
            }
            else
            {
                student.Age = age;
            }

            Console.Write("Enter Grade: ");
            student.Grade = Console.ReadLine();

            Console.Write("Enter Address: ");
            student.Address = Console.ReadLine();

            Console.Write("Enter Branch: ");
            student.Branch = Console.ReadLine();

            students.Add(student);//Adding the student objects in students list
            Console.WriteLine("Students added Successfully\n");
        }


        //-----------------------------Now View/Display items from the list------------------------------------
        static void ViewStudent()
        {
            Console.WriteLine("\n --------Displaying Students--------");
            if (students.Count == 0)
            {
                Console.WriteLine("No Students are found");
            }
            else
            {
                foreach (var student in students) //Here student is variable name which stores data & students is list name.
                {
                    Console.WriteLine("Id : " + student.Id);
                    Console.WriteLine("Name : " + student.Name);
                    Console.WriteLine("Age : " + student.Age);
                    Console.WriteLine("Branch : " + student.Branch);
                    Console.WriteLine("Grade : " + student.Grade);
                    Console.WriteLine("Address : " + student.Address);
                }
            }
        }

        //------------------------Now edit Student from the list----------------------------

        static void EditStudent()
        {
            Console.WriteLine("\n\n-------------Editing Students-------------");
            Console.Write("Enter the Id of the Student for Editing Details: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid input. Please enter a valid ID.");
                return;
            }
            var student1 = students.Find(s => s.Id == id);
            //Here s referes Student class object which will check whether this Id is present is students List or not& =>(Lambda Expression)
            //If results found now it will store Student object data in student1 variable otherwise null value will store.
            if (student1 == null)
            {
                Console.WriteLine("\nNo Student found with the given ID");
                return;
            }
            Console.WriteLine("\n What would you like to edit: ");
            Console.WriteLine("1) Edit Specific Data");
            Console.WriteLine("2) Edit whole data");
            Console.Write("Enter your choice (1-2): ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid choice. Please try again.");
                return;
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("What would you like to Edit");
                    Console.WriteLine("1) Name");
                    Console.WriteLine("2)Age");
                    Console.WriteLine("3)Address");
                    Console.WriteLine("4)Branch");
                    Console.WriteLine("5)Grade");
                    Console.Write("Enter your choice (1-5): ");

                    if (!int.TryParse(Console.ReadLine(), out int SpecificChoice))
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                        return;
                    }
                    switch (SpecificChoice)
                    {
                        case 1:
                            Console.Write("Enter Name: ");
                            student1.Name = Console.ReadLine();
                            break;

                        case 2:
                            Console.Write("Enter Age : ");
                            if (int.TryParse(Console.ReadLine(), out int age))
                            {
                                student1.Age = age;
                            }                   
                            else
                            {
                                Console.WriteLine("Invalid age. Age not updated.");
                            }
                            break;
                        case 3:
                            Console.Write("Enter Address: ");
                            student1.Address = Console.ReadLine();
                            break;
                        case 4:
                            Console.Write("Enter Branch: ");
                            student1.Branch = Console.ReadLine();
                            break;
                        case 5:
                            Console.Write("Enter Grade: ");
                            student1.Grade = Console.ReadLine();
                            break;
                        default:
                            Console.WriteLine("Invalid choice!");
                            return;
                    }
                    break;

                case 2:
                    Console.Write("Enter Name: ");
                    student1.Name = Console.ReadLine();
                    Console.Write("Enter Age: ");
                    if (int.TryParse(Console.ReadLine(), out int age1))
                    {
                        student1.Age = age1;
                    }
                    else
                    {
                        Console.WriteLine("Invalid age. Age not updated.");
                    }
                    Console.Write("Enter Address: ");
                    student1.Address = Console.ReadLine();
                    Console.Write("Enter Grade: ");
                    student1.Grade = Console.ReadLine();
                    Console.Write("Enter Branch: ");
                    student1.Branch = Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
            Console.WriteLine("Data updated successfully!");
        }


        //-------------------------Now Deleting Students from the List---------------------------------

        static void DeleteStudent()
        {
            Console.WriteLine("\n Enter the id of the Student to delete: ");
            int id;
            //Loop until a user enter a valid integer
            while(true)
            {
                if(int.TryParse(Console.ReadLine(), out id))
                {
                    if (id >0)
                    {
                        break;
                        
                    }
                    Console.WriteLine("OOPS!! Please Enter Positive integer Id.");
                }
                else
                {
                    Console.WriteLine("\"Invalid input! Please enter a valid integer ID.\"");
                    return;
                }
            }
            // Find Student in the list
            var student = students.Find(s => s.Id == id);
            if (student == null)//Check if student exist
            {
                Console.WriteLine("No student found with this id: "+id);
                return;
            }
                students.Remove(student);
                Console.WriteLine("Student Deleted Successfully!!");   
        }
        //------------------------------File handling-----------------------------

        static string defaultFileName = "students.txt"; // Changed extension to .txt for plain text format

        static void SaveToFile()
        {
            try
            {
                // Get the full file path
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), defaultFileName);

                // Serialize data into plain text format
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var student in students)
                    {
                        writer.WriteLine($"Id: {student.Id}");
                        writer.WriteLine($"Name: {student.Name}");
                        writer.WriteLine($"Age: {student.Age}");
                        writer.WriteLine($"Grade: {student.Grade}");
                        writer.WriteLine($"Address: {student.Address}");
                        writer.WriteLine($"Branch: {student.Branch}");
                        writer.WriteLine("--------------------------");
                    }
                }

                Console.WriteLine($"Data saved to file: {filePath}"); // Show full file path
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving data: " + ex.Message);
            }
        }

        static void LoadFromFile()
        {
            try
            {
                // Get the full file path
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), defaultFileName);

                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"File not found: {filePath}");
                    return;
                }

                // Read the data back from the text file
                using (StreamReader reader = new StreamReader(filePath))
                {
                    students.Clear(); // Clear the list before loading new data
                    while (!reader.EndOfStream)
                    {
                        Student student = new Student();
                        student.Id = int.Parse(reader.ReadLine().Split(": ")[1]);
                        student.Name = reader.ReadLine().Split(": ")[1];
                        student.Age = int.Parse(reader.ReadLine().Split(": ")[1]);
                        student.Grade = reader.ReadLine().Split(": ")[1];
                        student.Address = reader.ReadLine().Split(": ")[1];
                        student.Branch = reader.ReadLine().Split(": ")[1];
                        reader.ReadLine(); // Skip separator line
                        students.Add(student);
                    }
                }

                Console.WriteLine($"Data loaded from file: {filePath}"); // Show full file path
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while loading data: " + ex.Message);
            }
        }


    }
}
