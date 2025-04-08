using System;
using System.Linq;
using System.Reflection;

namespace Reflection
{

    [AttributeUsage(AttributeTargets.Method)]
    public class RunnableAttribute : Attribute
    {
        public int Priority { get; }

        public RunnableAttribute(int priority)
        {
            Priority = priority;
        }
    }

    public class ClassA
    {
        [Runnable(2)]
        public void MethodA()
        {
            Console.WriteLine("Executing MethodA in ClassA...");
        }

        [Runnable(1)]
        public void MethodB()
        {
            Console.WriteLine("Executing MethodB in ClassA...");
        }
    }

    public class ClassB
    {
        [Runnable(3)]
        public void MethodC()
        {
            Console.WriteLine("Executing MethodC in ClassB...");
        }

        [Runnable(2)]
        public void MethodD()
        {
            Console.WriteLine("Executing MethodD in ClassB...");
        }

        public static void MethodF()
        {
            Console.WriteLine("Executing MethodF in ClassB...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();
            var runnableMethods = types
                .SelectMany(type => type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                    .Where(m => m.GetCustomAttribute<RunnableAttribute>() != null)
                    .Select(m => new
                    {
                        Method = m,
                        Type = type,
                        Priority = m.GetCustomAttribute<RunnableAttribute>()?.Priority
                    }))
                .OrderBy(method => method.Priority)
                .ToList();

            foreach (var methodInfo in runnableMethods)
            {
                var instance = Activator.CreateInstance(methodInfo.Type);
                Console.WriteLine($"\nExecuting {methodInfo.Method.Name} in {methodInfo.Type.Name} with priority {methodInfo.Priority}...");
                methodInfo.Method.Invoke(instance, null);
            }
        }
    }
}
