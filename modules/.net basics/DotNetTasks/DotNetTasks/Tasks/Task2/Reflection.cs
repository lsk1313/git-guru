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

            var targetType = assemblyWithClasses.GetTypes().Single(t => t.GetInterface("IInterface") != null);
            var targetInstance = Activator.CreateInstance(targetType) as IInterface;

            targetInstance.CurrentIndex = int.MaxValue;

            return targetInstance.GetNextIndex();
        }
    }
}
