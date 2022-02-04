using System.Collections.Generic;

namespace LibraryConsoleApp.Service
{
    public interface IRepositoryService<TEntity>
    {
        List<TEntity> SelectAll();
        TEntity SelectById(int id);
        public void Add(TEntity entity);  
        public void Change(TEntity entity);  
        public void Delete(int id);
    }
}