using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace project3data
{
     class Student
        {

            public string Name { get; set; }
            public string Class { get; set; }

        }

        class Program
        {
            static void Main()
            {
                List<Student> students = LoadStudentData("StudentData.txt");

                if (students.Count == 0)
                {
                    Console.WriteLine("No student data found.");
                    
                }
                else
                {

                    Console.WriteLine("Student Data:");
                    Console.WriteLine("Name\tClass");
                    DisplayStudentData(students);

                    Console.WriteLine("\nSorting Students Data By Name:");
                    Console.WriteLine("Name\tClass");
                    students = students.OrderBy(student => student.Name).ToList();
                    DisplayStudentData(students);


                    Console.WriteLine("\nSearch for a student by name:");
                    string searchName = Console.ReadLine();
                    SearchAndDisplayStudent(students, searchName);
                    Console.ReadLine();

                }
            }

            static List<Student> LoadStudentData(string filePath)
            {
                List<Student> students = new List<Student>();

                try
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            students.Add(new Student
                            {
                                Name = parts[0].Trim(),
                                Class = parts[1].Trim()
                            });
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occurred while reading the file: {e.Message}");
                }

                return students;
            }

            static void DisplayStudentData(List<Student> students)
            {
                foreach (var student in students)
                {
                    Console.WriteLine($" {student.Name}  {student.Class}");
                }
            }

            static void SearchAndDisplayStudent(List<Student> students, string searchName)
            {
                var searchResults = students.Where(student => student.Name.ToLower().Contains(searchName.ToLower())).ToList();

                if (searchResults.Count > 0)
                {
                    Console.WriteLine($"Search Results for '{searchName}':");
                    DisplayStudentData(searchResults);
                }
                else
                {
                    Console.WriteLine($"No students found with the name '{searchName}'.");
                Console.ReadLine();
                }
                
            }
        }
}


 

    

