
namespace FileOperations{
class Program
{
    static void Main(string[] args)
    {
        string fileInputPath = "E:/Presidio-Training/data/sample.sv";
        string fileOutputPath = "E:/Presidio-Training/data/output.txt";

        try
        {
            FileStream inputFs = new(fileInputPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new(inputFs);
            FileStream outputFs = new(fileOutputPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new(outputFs);

            int lineCount = 0;
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] values = line.Split(',');
                Console.WriteLine($"{string.Join(", ", values)}");
                lineCount++;
                sw.WriteLine($"{string.Join(", ", values)}");
            }

            sw.Close();
            outputFs.Close();
            sr.Close();
            inputFs.Close();

            Console.WriteLine("---------File read and written successfully.-----------");
            Console.WriteLine($"Total lines: {lineCount}");
        }
        catch (PathTooLongException e)
        {
            Console.WriteLine("Path too long: " + e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine("Access denied: " + e.Message);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File not found: " + e.Message);
        }
        catch (IOException e)
        {
            Console.WriteLine("IO Exception: " + e.Message);
        }
    }
}

}