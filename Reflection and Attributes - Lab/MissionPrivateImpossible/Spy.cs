
using System.Reflection;
using System.Text;

namespace MissionPrivateImpossible
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldNames)
        {

            Console.WriteLine($"Class under investigation: {className}");

            var type = Type.GetType(className);

            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            var searchedFields = fields.Where(f => fieldNames.Contains(f.Name)).ToList();

            var instance = Activator.CreateInstance(type);

            var result = new StringBuilder();

            foreach (var field in searchedFields)
            {
                var value = field.GetValue(instance);

                result.AppendLine($"{field.Name} = {value}");
            }

            return result.ToString();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            var type = Type.GetType(className);

            var result = new StringBuilder();

            var fields = type.GetFields();

            foreach (var field in fields)
            {
                result.AppendLine($"{field.Name} must be private!");
            }

            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (var property in properties)
            {
                var getMethod = property.GetGetMethod(true);

                if (getMethod != null && !getMethod.IsPublic)
                {
                    result.AppendLine($"{getMethod.Name} have to be public!");
                }

                var setMethod = property.GetSetMethod();

                if (setMethod != null && !setMethod.IsPrivate)
                {
                    result.AppendLine($"{setMethod.Name} have to be private!");
                }
            }

            return result.ToString();
        }

        public string RevealPrivateMethods(string className)
        {
            Console.WriteLine($"All Private Methods of Class: {className}");

            var type = Type.GetType(className);

            Console.WriteLine($"Base Class: {type.BaseType.Name}");

            var allMethods = type.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);

            var result = new StringBuilder();

            foreach (var method in allMethods)
            {
                result.AppendLine(method.Name);
            }

            return result.ToString();
        }
    }
}

