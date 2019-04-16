using System;
using Newtonsoft.Json;

namespace Yanusosu.AbpCodeGenerator.Extensions
{
    public static class JsonExtension
    {
        public static string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T JsonToObj<T>(this string strObj)
        {
            var result = default(T);

            try
            {
                result = JsonConvert.DeserializeObject<T>(strObj);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return result;
        }
    }
}