using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Afalex.Extensions.Json
{
    public enum ModelType { Input, Output }
    public static class JsonExtenstions
    {
        public const string jsonFolderName = "JsonStorage";

        public static string RegisterJson<TClassCaller>(this object model, ModelType type, [CallerMemberName] string method = null)
        {
            string className = typeof(TClassCaller).Name;
            string json = JsonSerializer.Serialize(model, model.GetType(), new JsonSerializerOptions { WriteIndented = true, IgnoreNullValues = true });
            string path = Path.Combine(jsonFolderName, className);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            File.WriteAllText(Path.Combine(path, method + type.ToString() + ".txt"), json);

            return json;
        }
    }
}
