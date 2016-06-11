using blqw.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = Guid.NewGuid().ToString("n").ToLowerInvariant();
            var code = string.Format(CODE, name);
            var obj = (ITester)DyCompiler.CompileObject(code,typeof(ITester));
            Console.WriteLine($"{nameof(name)}:{name}");
            Console.WriteLine($"{nameof(obj.GetText)}:{obj.GetText()}");
        }

        const string CODE = @"
class _{0} : ITester
    {{
        public string GetText()
        {{
            return ""{0}"";
        }}
    }}
";
    }

    public interface ITester
    {
        string GetText();
    }

    

}
