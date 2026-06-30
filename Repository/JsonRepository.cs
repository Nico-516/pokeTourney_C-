using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;
using Model.Interfaces;

namespace Repository
{
    public class JsonRepository<T> : IRepository<T> where T : IEntity
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

        public List<T> GetAll()
        {
            if (!File.Exists(_rutaArchivo))
                return new List<T>();
            
            string jsonString = File.ReadAllText(_rutaArchivo);
            List<T>? resultado = JsonSerializer.Deserialize<List<T>>(jsonString);
            return resultado ?? new List<T>();
        }

        private void Save(List<T> items)
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

        public T? GetById(int id)
        {
            return GetAll().FirstOrDefault(e => e.Id == id);
        }

        public void Add(T item)
        {
            var items = GetAll();
            item.Id = items.Count > 0 ? items.Max(e => e.Id) + 1 : 1;
            items.Add(item);
            Save(items);
        }

        public void Update(T item)
        {
            var items = GetAll();
            int idx = items.FindIndex(e => e.Id == item.Id);
            if (idx >= 0)
            {
                items[idx] = item;
            }
            Save(items);
        }

        public void Delete(int id)
        {
            var items = GetAll();
            items.RemoveAll(e => e.Id == id);
            Save(items);
        }
    }
}