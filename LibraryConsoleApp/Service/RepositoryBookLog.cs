using System.Collections.Generic;
using System.Linq;
using LibraryConsoleApp.DbContext;
using LibraryConsoleApp.models;

namespace LibraryConsoleApp.Service
{
    public class RepositoryBookLog
    {
          /**
            <summary> SelectAll is action for select and display all row in entity. </summary>
            <return> list of an entity </return>
        */
        public List<BookLog> SelectAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Set<BookLog>().ToList();
            }
        }
        
        /**
            <summary> Select by id is action for select a row by id in entity. </summary>
            <param  name = "id" > id will be search and will be presented per row </param>
            <return> tuple or row of entity. </return>
        */
        public BookLog SelectById(int id) 
        {
            using (var context = new AppDbContext())
            {
                // IQueryable<TEntity> entityQuery = context.Set<TEntity>();

                return context.Set<BookLog>().Find(id);

            }
        }
        
        /**
            <summary> Add is action for create or insert a row. </summary>
            <param  name = "booklog" > is an entity that will be add.</param>
        */
        public void Add(BookLog booklog)
        {
            using (var context = new AppDbContext())
            {
                context.Set<BookLog>().Add(booklog);
                context.SaveChanges();
            }
        }
        
        /**
            <summary> Change is action for update a row that already exist. </summary>
            <param  name = "booklog" > is an entity that will be update.</param>
        */
        public void Change(BookLog booklog)
        {
            using (var context = new AppDbContext())
            {
                context.Set<BookLog>().Update(booklog);
                context.SaveChanges();
            }
        }
        /**
            <summary> Delete is action for delete a row. </summary>
            <param  name = "id" > is an id that will be delete.</param>
        */

        public void Delete(int id)
        {
            using (var context = new AppDbContext())
            {
                var bookLogId = context.Set<BookLog>().Find(id);
                context.Set<BookLog>().Remove(bookLogId);
                context.SaveChanges();
            }
        }
    }
}