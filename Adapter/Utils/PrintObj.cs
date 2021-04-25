using System;
using Newtonsoft.Json.Linq;

namespace Adapter.Utils
{
    public static class PrintObj
    {
        public static void print(JObject obj)
        {
            foreach (var elem in obj)
            {
                Console.WriteLine(elem.Key + ": " + (string)elem.Value);
            }
        }
    }
}