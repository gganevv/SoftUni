namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        internal string StealFieldInfo(string className, params string[] fields)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {className}");
            Type classType = Type.GetType(className);
            FieldInfo[] fieldInfo = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            foreach (FieldInfo field in fieldInfo.Where(x => fields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().TrimEnd();

        }

        internal string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            FieldInfo[] fieldInfo = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethodsInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethodsInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fieldInfo)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in nonPublicMethodsInfo.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in publicMethodsInfo.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();

        }

        internal string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);

            MethodInfo[] nonPublicMethodsInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var field in nonPublicMethodsInfo.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{field.Name} will return {field.ReturnType}");
            }
            foreach (var field in nonPublicMethodsInfo.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{field.Name} will set field of {field.GetParameters().First().ParameterType}");
            }
            return sb.ToString().TrimEnd();
        }

        internal string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");

            Type classType = Type.GetType(className);
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            MethodInfo[] nonPublicMethodsInfo = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in nonPublicMethodsInfo)
            {
                sb.AppendLine(field.Name);
            }
            return sb.ToString().TrimEnd();
        }
    }
}