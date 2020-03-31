using DotNetTasks.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DotNetTasks.Tasks.Task2
{
    public class Reflection : ICommand
    {
        public void Execute()
        {
            var index = LoadAssemblyAndReturnIndex();
            Console.WriteLine($"Next index is: {index}");

            var targetClasses = LoadTypesWhereImplementSpecificAssembly();
            
            foreach (var type in targetClasses)
            {
                Console.WriteLine($"Class name is: {type.Name}");
            }
        }

        public int Number => 2;

        public string DisplayName => "Task 2: Reflection";

        private static string LoadAssemblyAndReturnIndex()
        {
            var assemblyWithClasses = Assembly.LoadFrom("Education_dotNet_Reflection_classes.dll");
            var assemblyWithInterfaces = Assembly.LoadFrom("Education_dotNet_Reflection_interface.dll");

            var targetInterfaces = assemblyWithInterfaces.GetTypes()
                .Where(t => t.IsInterface);

            var targetType = assemblyWithClasses.GetTypes().FirstOrDefault(t => targetInterfaces.Any(i => i.IsAssignableFrom(t)));
            if (targetType == null)
            {
                return string.Empty;
            }

            var targetInstance = Activator.CreateInstance(targetType);
            var propertyInfoTargetType = targetType.GetProperty("CurrentIndex");

            propertyInfoTargetType?.SetValue(targetInstance, 111);

            var getIndexMethodInfo = targetType.GetMethod("GetNextIndex");

            var result = getIndexMethodInfo?.Invoke(targetInstance, null);

            return result?.ToString();
        }

        private static IEnumerable<Type> LoadTypesWhereImplementSpecificAssembly()
        {
            var assemblyWithClasses = Assembly.LoadFrom("Education_dotNet_Reflection_classes.dll");
            var assemblyWithInterfaces = Assembly.LoadFrom("Education_dotNet_Reflection_interface.dll");

            var targetInterfaces = assemblyWithInterfaces.GetTypes()
                .Where(t => t.IsInterface);

            return assemblyWithClasses.GetTypes()
                .Where(t => t.GetInterfaces().Any(targetInterfaces.Contains));
        }
    }
}
