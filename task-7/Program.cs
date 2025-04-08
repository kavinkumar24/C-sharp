using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;


namespace task_7
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Enter User ID (1-30): ");
            string? userId = int.TryParse(Console.ReadLine(), out int id) ? id.ToString() : null;

            if (userId == null)
            {
                Console.WriteLine("Invalid User ID.");
                return;
            }

            string userDataUrl = $"https://jsonplaceholder.typicode.com/users/{id}";
            string userPostsUrl = $"https://jsonplaceholder.typicode.com/posts/{id}";
            string userTodosUrl = $"https://jsonplaceholder.typicode.com/todos/{id}";


            try
            {
                var FetchingTasks = new List<Task>
                {
                    FetchUserData(userDataUrl),
                    FetchUserPosts(userPostsUrl),
                    FetchUserTodos(userTodosUrl)
                };

                await Task.WhenAll(FetchingTasks);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            stopwatch.Stop();
            Console.WriteLine("------------------");
            Console.WriteLine($"Total Time: {stopwatch.Elapsed.TotalSeconds} seconds");
        }

        static async Task FetchUserData(string url)
        {
            using HttpClient client = new HttpClient();
            try
            {
                await Task.Delay(1000);
                Console.WriteLine("Data from UserProfile - 1000ms delay");

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"User Data: {data}");
                }
                else
                {
                    Console.WriteLine("Error fetching user data.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in FetchUserData: {ex.Message}");
            }
        }

        static async Task FetchUserPosts(string url)
        {
            using HttpClient client = new HttpClient();
            try
            {
                await Task.Delay(2000);
                Console.WriteLine("Data from UserPosts - 2000ms delay");

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"User Posts: {data}");
                }
                else
                {
                    Console.WriteLine("Error fetching user posts.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in FetchUserPosts: {ex.Message}");
            }
        }

        static async Task FetchUserTodos(string url)
        {
            using HttpClient client = new HttpClient();
            try
            {
                await Task.Delay(3000);
                Console.WriteLine("Data from UserTodos - 3000ms delay");

                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"User Todos: {data}");
                }
                else
                {
                    Console.WriteLine("Error fetching user todos.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in FetchUserTodos: {ex.Message}");
            }
        }
    }
}
