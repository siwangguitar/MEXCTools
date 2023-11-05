using Newtonsoft.Json;
using System.IO;
namespace MEXCTools
{
    public class Config
    {
        public string BaseUrl { get; set; }

        public List<MasterMEXCApi> MasteMexcApis { get; set; }

        public Config()
        {
            MasteMexcApis = new List<MasterMEXCApi>();
            BaseUrl = "https://api.mexc.com";
        }
        public static Config? Make(string fileName)
        {

            string result = LoadResource(GetPath(fileName));
            if (IsNullOrEmpty(result))
            {
                return null;
            }
            Config config = FromJson<Config>(result);

            if (config != null)
            {
                if (config.MasteMexcApis == null)
                {
                    config.MasteMexcApis = new List<MasterMEXCApi>();
                }
            }
            return config;
        }

        public static string StartupPath()
        {
            return Application.StartupPath;
        }
        public static string GetPath(string fileName)
        {
            string startupPath = StartupPath();
            if (IsNullOrEmpty(fileName))
            {
                return startupPath;
            }
            return Path.Combine(startupPath, fileName);
        }

        public static string LoadResource(string res)
        {
            string result = string.Empty;

            try
            {
                using (StreamReader reader = new StreamReader(res))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch
            {
            }
            return result;
        }

        public static T FromJson<T>(string strJson)
        {
            try
            {
                T obj = JsonConvert.DeserializeObject<T>(strJson);
                return obj;
            }
            catch
            {
                return JsonConvert.DeserializeObject<T>("");
            }
        }
        public static bool IsNullOrEmpty(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return true;
            }
            if (text.Equals("null"))
            {
                return true;
            }
            return false;
        }
        public int ToJsonFile(string filePath, bool nullValue = true)
        {
            int result;
            try
            {
                using (StreamWriter file = File.CreateText(filePath))
                {
                    JsonSerializer serializer;
                    if (nullValue)
                    {
                        serializer = new JsonSerializer() { Formatting = Formatting.Indented };
                    }
                    else
                    {
                        serializer = new JsonSerializer() { Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore };
                    }

                    serializer.Serialize(file, this);
                }
                result = 0;
            }
            catch
            {
                result = -1;
            }
            return result;
        }
    }


}
