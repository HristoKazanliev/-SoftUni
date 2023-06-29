using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] requestedFields)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Public |
                                                                    BindingFlags.NonPublic |
                                                                    BindingFlags.Static |
                                                                    BindingFlags.Instance);

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {classType.FullName}");

            foreach (var field in classFields.Where(field => requestedFields.Contains(field.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            FieldInfo[] publicFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] publicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] nonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in publicFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in nonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (var method in publicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }
    }
}
