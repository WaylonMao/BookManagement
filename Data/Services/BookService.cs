namespace BookManagement.Data
{
    public class BookService : IBookService
    {
        public void AddBook(Book book)
        {
            Data.Books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var book = Data.Books.FirstOrDefault(n => n.Id == id);
            Data.Books.Remove(book);
        }

        public List<Book> GetAllBooks()
        {
            return Data.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return Data.Books.FirstOrDefault(n => n.Id == id) ?? throw new InvalidOperationException();
        }

        public void UpdateBook(int id, Book book)
        {
            var oldBook = Data.Books.FirstOrDefault(n => n.Id == id);
            if (oldBook != null)
            {
                oldBook.Title = book.Title;
                oldBook.Author = book.Author;
                oldBook.Description = book.Description;
                oldBook.Rate = book.Rate;
                oldBook.DateStart = book.DateStart;
                oldBook.DateRead = book.DateRead;
            }
        }
    }
}