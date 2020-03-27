using Education_dotNet_Reflection_interface;
using System;
using System.Linq;
using System.Reflection;

namespace DotNetTasks.Tasks.Task2
{
    public class Reflection
    {
        public int LoadAssemblyAndReturnIndex()
        {
            var assemblyWithClasses = Assembly.LoadFrom("Education_dotNet_Reflection_classes.dll");

            var targetType = assemblyWithClasses.GetTypes().FirstOrDefault(t => t.GetInterface("IInterface") != null);
            if (targetType == null)
            {
                return 0;
            }

            var targetInstance = Activator.CreateInstance(targetType) as IInterface;

            targetInstance.CurrentIndex = int.MaxValue;

            return targetInstance.GetNextIndex();
        }

        public void LoadTypesWhereImplementAssembly()
        {
            var assemblyWithClasses = Assembly.LoadFrom("Education_dotNet_Reflection_classes.dll");
            var assemblyWithInterfaces = Assembly.LoadFrom("Education_dotNet_Reflection_interface.dll");

            var targetInterfaces = assemblyWithInterfaces.GetTypes()
                .Where(t => t.IsInterface);
            var targetClasses = assemblyWithClasses.GetTypes()
                .Where(t => t.GetInterfaces().Any(targetInterfaces.Contains));

        }
    }
}
