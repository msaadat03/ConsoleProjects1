using Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Create(T data);
        void Update(T data);
        void Delete(T data);
        IList<T> GetAll(Predicate<T> predicate = null);
        T GetById(int id);
    }
}
