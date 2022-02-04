using System.Collections.Generic;

namespace LibraryConsoleApp.models
{
    public class Book:ModelBase
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Position { get; set; }
        public int Qty { get; set; }
        public int Remains { get; set; }
        
        public virtual ICollection<BookLog> BookLog { get; set; }
    }
}