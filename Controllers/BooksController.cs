using BookManagement.Data;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        private readonly ILogger<BooksController> _logger;

        public BooksController(IBookService bookService, ILogger<BooksController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        // Add a new book
        [HttpPost("AddBook")]
        public IActionResult AddBook([FromBody] Book book)
        {
            try
            {
                if (book.Author != null && book.Title != null && book.Description != null)
                {
                    int lastBookId = 0;
                    if (_bookService.GetAllBooks().LastOrDefault() != null)
                    {
                        lastBookId = _bookService.GetAllBooks().LastOrDefault()!.Id;
                    }

                    book.Id = lastBookId + 1;

                    _bookService.AddBook(book);
                    return Ok(book);
                }

                return BadRequest("Book was not added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Get all books
        [HttpGet("[action]")]
        public IActionResult GetBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        // Update a book
        [HttpPut("UpdateBook/{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            _bookService.UpdateBook(id, book);
            return Ok(book);
        }

        // Delete a book
        [HttpDelete("DeleteBook/{id}")]
        public IActionResult DeleteBook(int id)
        {
            _bookService.DeleteBook(id);
            return Ok();
        }

        // Get a book by id
        [HttpGet("SingleBook/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            return Ok(book);
        }
    }
}