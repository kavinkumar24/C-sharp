namespace Models
{
    public class Student(int rollNo, string? name, int age, string? department, string? year)
    {
        public int RollNo { get; set; } = rollNo;
        public string? Name { get; set; } = name;
        public int Age { get; set; } = age;
        public string? Department { get; set; } = department;
        public string? Year { get; set; } = year;
    }
}