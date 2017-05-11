using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UFSC.Extension
{
    public static class ExtensionMethods
    {
        public static string MetricJoin(this string str, string outra, int distance)
        {
            if (distance <= str.Length)
                throw new Exception();

            while (str.Length < distance)
                str += " ";

            str += outra;
            return str;
        }
    }
}
