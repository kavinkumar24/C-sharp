// factorial of the given number

namespace task1{
class Program{
    
    int factorial(int num){
        if(num == 0 || num == 1){
            return 1;
        }
        else{
            return num * factorial(num - 1);
        }

    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number to find the factorial");
        int num = Convert.ToInt32(Console.ReadLine());
        if(num>0){
            Console.WriteLine("Your input is valid.");
        }
        else if(num<0){
            Console.WriteLine("Your input is invalid, because factorial of negative number is not possible.");
            return;
        }
        Console.WriteLine("The factorial of given number " + num + " is: " + new Program().factorial(num));
        
    }
}
}
