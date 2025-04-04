
namespace task_3{
    class Program{
        static void Main(string[] args){
            var tasks = new List<string>();
            var userDisplay = new string[]
            {
                "1. Add a task",
                "2. Remove a task",
                "3. Display all tasks",
                "4. Exit"
            };
            bool running = true;
            StringHelper.StringMethodsExecution();

            Console.WriteLine("--------------------");
            Console.WriteLine("Welcome to the task manager!");
            while(running){
                Console.WriteLine("Select an option");
                foreach (var item in userDisplay){
                    Console.WriteLine(item);
                }

                string? input = Console.ReadLine();
                switch(input)
                {

                    case "1":
                        Console.WriteLine("Enter a task to add:");  
                        string? newTask = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newTask))
                        {
                            tasks.Add(newTask);
                        }
                        else
                        {
                            Console.WriteLine("Task cannot be empty.");
                        }
                        break;
                    
                    case "2":
                        Console.WriteLine($"Enter the position of the task to remove");
                        if (int.TryParse(Console.ReadLine(), out int index) && index-1 >= 0 && index-1 < tasks.Count)
                        {
                            tasks.RemoveAt(index-1);
                            Console.WriteLine("Task removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid index.");
                        }
                        
                    break;

                    case "3":
                        Console.WriteLine("Tasks:");
                        Console.WriteLine("---------");
                        foreach (var task in tasks)
                        {
                            Console.WriteLine(task);
                        }
                        Console.WriteLine("---------");
                    break;

                    case "4":
                        running = false;
                        break;

                }
            }
            
        }
    }
}