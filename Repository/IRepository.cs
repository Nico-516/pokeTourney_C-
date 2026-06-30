using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Model;
using Model.Interfaces;

namespace Repository
{
    public interface IRepository<T> where T : IEntity
    {
        List<T> GetAll();
        T? GetById(int id);
        void Add(T item);
        void Update(T item);
        void Delete(int id);
    }
}