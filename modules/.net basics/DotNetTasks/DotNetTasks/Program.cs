using System;
using DotNetTasks.Tasks.Task2;

namespace DotNetTasks
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var reflection = new Reflection();
            var result = reflection.LoadAssemblyAndReturnIndex();
            reflection.LoadTypesWhereImplementAssembly();

            Console.Write(result);
            Console.Read();
        }
    }
}
