using System.Collections.Generic;
using Tamirhane.Core.Models;

namespace Tamirhane.Core
{
    public interface GenericInterface<T>
    {
        Result Add(T p);
        Result Edit(T p);
        Result Remove(int Id);
        IEnumerable<T> GetAll();
        T FindById(int Id);
    }
}