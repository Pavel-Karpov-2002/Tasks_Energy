using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace Task_2_API
{
    public static class JsonParse
    {
        public static async Task<string> GetJson(string path)
        {
            using (var reader = File.OpenText(path))
            {
                string jsonFile = await reader.ReadToEndAsync();
                return jsonFile;
            }
        }

        public static T GetObject<T>(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return default(T);
            }
        }
    }
}
