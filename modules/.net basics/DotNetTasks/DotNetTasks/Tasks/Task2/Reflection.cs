using System;
using System.Linq;
using System.Reflection;

namespace DotNetTasks.Tasks.Task2
{
    public class Reflection
    {
        public string LoadAssemblyAndReturnIndex()
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
