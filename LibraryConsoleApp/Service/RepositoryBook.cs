using System.Collections.Generic;
using System.Linq;
using LibraryConsoleApp.DbContext;
using LibraryConsoleApp.models;

namespace LibraryConsoleApp.Service
{
    public class RepositoryBook
    {
                 /**
            <summary> SelectAll is action for select and display all row in entity. </summary>
            <return> list of an entity </return>
        */
        public List<Book> SelectAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Set<Book>().ToList();
            }
        }
        
        /**
            <summary> Select by id is action for select a row by id in entity. </summary>
            <param  name = "id" > id will be search and will be presented per row </param>
            <return> tuple or row of entity. </return>
        */
        public Book SelectById(int id) 
        {
            using (var context = new AppDbContext())
            {
                // IQueryable<TEntity> entityQuery = context.Set<TEntity>();

                return context.Set<Book>().Find(id);

            }
        }
        
        /**
            <summary> Add is action for create or insert a row. </summary>
            <param  name = "book" > is an entity that will be add.</param>
        */
        public void Add(Book book)
        {
            using (var context = new AppDbContext())
            {
                context.Set<Book>().Add(book);
                context.SaveChanges();
            }
        }
        
        /**
            <summary> Change is action for update a row that already exist. </summary>
            <param  name = "book" > is an entity that will be update.</param>
        */
        public void Change(Book book)
        {
            using (var context = new AppDbContext())
            {
                context.Set<Book>().Update(book);
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
                var bookId = context.Set<Book>().Find(id);
                context.Set<Book>().Remove(bookId);
                context.SaveChanges();
            }
        }
    }
}