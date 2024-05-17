using ApiNetCore6Book.Models;
using ApiNetCore6Book.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SqlServer; 
namespace ApiNetCore6Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelfBookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public SelfBookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                return Ok(await _bookRepository.GetAllBookAsync()); 
            }
            catch
            {
                return BadRequest(); 
            }
        }
       
        [HttpPost]
        
        public async Task<IActionResult> Add(BookModel book)
        {
            //return Ok(await _bookRepository.AddBookAsync(book)); // chỉ cần 1 dòng này là cũng đúng
            try
            {
                var newBook = await _bookRepository.AddBookAsync(book);
                var bookk = await _bookRepository.GetByIdAsync(newBook); 
                return bookk==null?NotFound() : Ok(bookk);
            }
            catch
            {
                return BadRequest(); 
            }
        }
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> updateBook(int id, BookModel model)
        {
            if(id != model.Id)
            {
                return NotFound(); 
            }
            await _bookRepository.UpdateBookAsync(model, id);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteBook(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            return Ok(); 
        }
        
        [HttpGet("search/{des}")]
        // Nếu để [Httpget("{des}")] thì bị sai vì trùng với cái GetById
        
        public async Task<IActionResult> searchBook(string des)
        {
            try
            {
                return Ok(await _bookRepository.SearchBookAsync(des)); 
            }
           catch
            {
                return NotFound(); 
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return book == null ? NotFound() : Ok(book);
        }
    }
}
