using System;
using System.Linq;
using Models;
using InMemoryRepository;
using GenericRepository;

namespace task_8
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository<Student> repository = new Repository<Student>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Get All Students");
                Console.WriteLine("4. Get Student by Roll No");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Exit");
                Console.Write("Please select an option: ");
                string? userInput = Console.ReadLine();

                try
                {
                    switch (userInput)
                    {
                        case "1":
                            Console.Write("Enter Roll No: ");
                            string? rollNoInput = Console.ReadLine();
                            if (!int.TryParse(rollNoInput, out int rollNo))
                            {
                                Console.WriteLine("Invalid Roll No. Please enter a valid number.");
                                break;
                            }
                            Console.Write("Enter Name: ");
                            string? name = Console.ReadLine();
                            Console.Write("Enter Age: ");
                            string? ageInput = Console.ReadLine();
                            if (!int.TryParse(ageInput, out int age))
                            {
                                Console.WriteLine("Invalid Age. Please enter a valid number.");
                                break;
                            }
                            Console.Write("Enter Department: ");
                            string? department = Console.ReadLine();
                            Console.Write("Enter Year: ");
                            string? year = Console.ReadLine();

                            repository.Add(new Student(rollNo, name, age, department, year));
                            break;

                        case "2":
                            Console.Write("Enter Roll No of the student to update: ");
                            string? updateRollNoInput = Console.ReadLine();
                            if (!int.TryParse(updateRollNoInput, out int updateRollNo))
                            {
                                Console.WriteLine("Invalid Roll No. Please enter a valid number.");
                                break;
                            }
                            var studentToUpdate = repository.GetAll().FirstOrDefault(s => s.RollNo == updateRollNo);

                            if (studentToUpdate != null)
                            {
                                Console.Write("Enter New Name: ");
                                studentToUpdate.Name = Console.ReadLine();
                                Console.Write("Enter New Age: ");
                                string? newAgeInput = Console.ReadLine();
                                if (!int.TryParse(newAgeInput, out int newAge))
                                {
                                    Console.WriteLine("Invalid Age. Please enter a valid number.");
                                    break;
                                }
                                studentToUpdate.Age = newAge;
                                Console.Write("Enter New Department: ");
                                studentToUpdate.Department = Console.ReadLine();
                                Console.Write("Enter New Year: ");
                                studentToUpdate.Year = Console.ReadLine();

                                repository.Update(studentToUpdate);
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                            break;

                        case "3":
                            var allStudents = repository.GetAll();
                            Console.WriteLine("-----------------All Students:------------------");
                            if (!allStudents.Any())
                            {
                                Console.WriteLine("No students found.");
                                break;
                            }
                            foreach (var s in allStudents)
                            {
                                Console.WriteLine($"Roll No: {s.RollNo}, Name: {s.Name}, Age: {s.Age}, Department: {s.Department}, Year: {s.Year}");
                            }
                            Console.WriteLine("-----------------------------------------------");
                            break;

                        case "4":
                            Console.Write("Enter Roll No: ");
                            string? rollNoInputToGet = Console.ReadLine();
                            if (!int.TryParse(rollNoInputToGet, out int rollNoToGet))
                            {
                                Console.WriteLine("Invalid Roll No. Please enter a valid number.");
                                break;
                            }
                            var student = repository.GetById(rollNoToGet);

                            if (student != null)
                            {
                                Console.WriteLine("-----------------Student Details:------------------");
                                Console.WriteLine($"Roll No: {student.RollNo}, Name: {student.Name}, Age: {student.Age}, Department: {student.Department}, Year: {student.Year}");
                                Console.WriteLine("-----------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                            break;

                        case "5":
                            Console.Write("Enter Roll No of the student to delete: ");
                            string? rollNoToDeleteInput = Console.ReadLine();
                            if (!int.TryParse(rollNoToDeleteInput, out int rollNoToDelete))
                            {
                                Console.WriteLine("Invalid Roll No. Please enter a valid number.");
                                break;
                            }

                            var studentToDelete = repository.GetAll().FirstOrDefault(s => s.RollNo == rollNoToDelete);

                            if (studentToDelete != null)
                            {
                                repository.Delete(rollNoToDelete);
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                            break;

                        case "6":
                            running = false;
                            Console.WriteLine("Exiting...");
                            break;

                        default:
                            Console.WriteLine("Invalid option, please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
