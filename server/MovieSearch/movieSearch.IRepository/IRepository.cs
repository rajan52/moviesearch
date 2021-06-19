using System;
using System.Collections.Generic;
using System.Text;

namespace movieSearch.IRepository
{
    // Design pattern :- Generic Repository pattern
    public interface IRepository<AnyType>
    {
        void Add(AnyType obj); // Inmemory addition
        void Update(AnyType obj);  // Inmemory updation
        List<AnyType> Search(Func<AnyType, bool> lambda, string sortcolumn, bool isDescending);
        void Save(); // Physical committ
    }
}
