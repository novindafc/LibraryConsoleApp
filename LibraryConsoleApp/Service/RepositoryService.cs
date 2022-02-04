using System.Collections.Generic;
using System.Linq;
using LibraryConsoleApp.DbContext;

namespace LibraryConsoleApp.Service
{
    public class RepositoryService<TEntity> : IRepositoryService<TEntity> where TEntity : class
    {
        /**
            <summary> SelectAll is action for select and display all row in entity. </summary>
            <return> list of an entity </return>
        */
        public List<TEntity> SelectAll()
        {
            using (var context = new AppDbContext())
            {
                // IEnumerable<Employee> employees = new IEnumerable<Employee>();
                return context.Set<TEntity>().ToList();
            }
        }
        
        /**
            <summary> Select by id is action for select a row by id in entity. </summary>
            <param  name = "id" > id will be search and will be presented per row </param>
            <return> tuple or row of entity. </return>
        */
        public TEntity SelectById(int id) 
        {
            using (var context = new AppDbContext())
            {
                // IQueryable<TEntity> entityQuery = context.Set<TEntity>();

                return context.Set<TEntity>().Find(id);

            }
        }
        
        /**
            <summary> Add is action for create or insert a row. </summary>
            <param  name = "entity" > is an entity that will be add.</param>
        */
        public void Add(TEntity entity)
        {
            using (var context = new AppDbContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }
        
        /**
            <summary> Change is action for update a row that already exist. </summary>
            <param  name = "entity" > is an entity that will be update.</param>
        */
        public void Change(TEntity entity)
        {
            using (var context = new AppDbContext())
            {
                context.Set<TEntity>().Update(entity);
                context.SaveChanges();
            }
        }
        /**
            <summary> Delete is action for delete a row. </summary>
            <param  name = "entity" > is an entity that will be delete.</param>
        */

        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var employeeId = context.Set<TEntity>().Find(id);
                context.Set<TEntity>().Remove(employeeId);
                context.SaveChanges();
            }
        }

    }

    }
