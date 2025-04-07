namespace task_4{
    class Student{
        public string? Name;
        public string Grade { get; set; } = "F";
        public int Age;
    }
    class Program
    {
        public static int CompareGrades(string grade1, string grade2){
            Dictionary<string, int> gradeValue = new()
            {
                {"O", 10},
                {"A+", 9},
                {"A", 8},
                {"B+", 7},
                {"B", 6},
                {"C", 5},
                {"D", 4},
                {"E", 3},
                {"F", 0}
            };

            if(gradeValue.ContainsKey(grade1) && gradeValue.ContainsKey(grade2)){
                return gradeValue[grade1].CompareTo(gradeValue[grade2]);
            }
            else{
                throw new ArgumentException("Invalid grade value");
            }
        }
        static void Main(string[] args)
        {
            List<Student> students = [
                new Student { Name = "Kavin Kumar P", Grade = "O", Age = 22 },
                new Student { Name = "Ravi", Grade = "A+", Age = 19 },
                new Student { Name = "Jane", Grade = "A", Age = 23 },
                new Student { Name = "Sara", Grade = "O", Age = 21 },
                new Student { Name = "Anuj", Grade = "O", Age = 20 }
            ];
            
            string rankThreshold = "O";
            IEnumerable<Student> filteredStudents = 
                from student in students
                where CompareGrades(student.Grade, rankThreshold) >= 0
                orderby student.Name ascending
                select student;

            foreach (var student in filteredStudents)
            {
                Console.WriteLine($"Name: {student.Name}, Grade: {student.Grade}, Age: {student.Age}");
            }
        }
    }
}