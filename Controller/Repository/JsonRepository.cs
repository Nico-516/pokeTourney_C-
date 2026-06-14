using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace   Controller.Repository
{
    public class JsonRepository<T> : IRepository<T>
    {
        private readonly string _rutaArchivo;
        public JsonRepository(string ruta) => _rutaArchivo = ruta;
        public List<T> LeerTodos()
        {
            string[] pathsToTry = new[]
            {
                $"{_rutaArchivo}",
                $"Controller/JsonGetters/{_rutaArchivo}",
                $"../../Controller/JsonGetters/{_rutaArchivo}",
                $"../../../Controller/JsonGetters/{_rutaArchivo}",
                $"../../../../Controller/JsonGetters/{_rutaArchivo}"
            };

            string jsonPath = "";
            foreach (var path in pathsToTry)
            {
                if (File.Exists(path))
                {
                    jsonPath = path;
                    break;
                }
            }

            if (string.IsNullOrEmpty(jsonPath))
                return new List<T>();
            
            string jsonString = File.ReadAllText(jsonPath);
            List<T>? resultado = JsonSerializer.Deserialize<List<T>>(jsonString);
            return resultado ?? new List<T>();

        }
        public void GuardarTodos(List<T> items)
            {
            var opts = new JsonSerializerOptions
            { WriteIndented = true };
            var json = JsonSerializer.Serialize(items, opts);
            File.WriteAllText(_rutaArchivo, json);
            }
    }
}