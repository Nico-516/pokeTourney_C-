using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace Repository
{
    public class JsonRepository<T> : IRepository<T>
    {
        private string _rutaArchivo;

        public JsonRepository(string ruta)
        {
            string fileName = Path.GetFileName(ruta);
            string[] pathsToTry = new[]
            {
                Path.Combine("Repository", fileName),
                Path.Combine("..", "Repository", fileName),
                Path.Combine("..", "..", "Repository", fileName),
                Path.Combine("..", "..", "..", "Repository", fileName),
                Path.Combine("..", "..", "..", "..", "Repository", fileName),
                ruta
            };

            string foundPath = "";
            foreach (var path in pathsToTry)
            {
                if (File.Exists(path))
                {
                    foundPath = path;
                    break;
                }
            }

            if (!string.IsNullOrEmpty(foundPath))
            {
                _rutaArchivo = foundPath;
            }
            else
            {
                _rutaArchivo = Path.Combine("Repository", fileName);
            }
        }

        public List<T> LeerTodos()
        {
            if (!File.Exists(_rutaArchivo))
                return new List<T>();
            
            string jsonString = File.ReadAllText(_rutaArchivo);
            List<T>? resultado = JsonSerializer.Deserialize<List<T>>(jsonString);
            return resultado ?? new List<T>();
        }

        public void GuardarTodos(List<T> items)
        {
            var opts = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(items, opts);
            
            // Ensure the directory exists if needed
            string? dir = Path.GetDirectoryName(_rutaArchivo);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            
            File.WriteAllText(_rutaArchivo, json);
        }
    }
}