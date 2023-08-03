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
            _bookService.AddBook(book);
            return Ok("Added Successfully");
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