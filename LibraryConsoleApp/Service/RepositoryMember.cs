using System.Collections.Generic;
using System.Linq;
using K4os.Compression.LZ4.Internal;
using LibraryConsoleApp.DbContext;
using LibraryConsoleApp.models;

namespace LibraryConsoleApp.Service
{
    public class RepositoryMember
    {
          /**
            <summary> SelectAll is action for select and display all row in entity. </summary>
            <return> list of an entity </return>
        */
        public List<Member> SelectAll()
        {
            using (var context = new AppDbContext())
            {
                return context.Set<Member>().ToList();
            }
        }
        
        /**
            <summary> Select by id is action for select a row by id in entity. </summary>
            <param  name = "id" > id will be search and will be presented per row </param>
            <return> tuple or row of entity. </return>
        */
        public Member SelectById(int id) 
        {
            using (var context = new AppDbContext())
            {
                // IQueryable<TEntity> entityQuery = context.Set<TEntity>();

                return context.Set<Member>().Find(id);

            }
        }
        
        /**
            <summary> Add is action for create or insert a row. </summary>
            <param  name = "member" > is an entity that will be add.</param>
        */
        public void Add(Member member)
        {
            using (var context = new AppDbContext())
            {
                context.Set<Member>().Add(member);
                context.SaveChanges();
            }
        }
        
        /**
            <summary> Change is action for update a row that already exist. </summary>
            <param  name = "member" > is an entity that will be update.</param>
        */
        public void Change(Member member)
        {
            using (var context = new AppDbContext())
            {
                context.Set<Member>().Update(member);
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
                var memberId = context.Set<Member>().Find(id);
                context.Set<Member>().Remove(memberId);
                context.SaveChanges();
            }
        }
    }
}