namespace task2{
    class Person
    {
        public string? Name;
        public int? Age;
        public void Introduce(){
            Console.WriteLine($"Hi, welcome to home {Name} and its very nice to meet you.");
            Console.WriteLine("Thanks for coming");
        }
    }
    class Program{
        static void Main(string[] args){
            Person person = new();
            Console.WriteLine("Enter your name:");
            person.Name = Console.ReadLine();
            Console.WriteLine("Enter your age:");
            person.Age = int.TryParse(Console.ReadLine(), out int age) ? age : (int?)null;
            person.Age = age;
            person.Introduce();
        }
    }
}