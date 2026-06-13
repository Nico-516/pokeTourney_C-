using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Model;

namespace   Controller.Repository
{
    public interface IRepository<T>
    {
        List<T> LeerTodos();
        void GuardarTodos(
        List<T> items);
    }
}