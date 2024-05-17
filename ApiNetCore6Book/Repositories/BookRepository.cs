using ApiNetCore6Book.Data;
using ApiNetCore6Book.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace ApiNetCore6Book.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;
        private readonly IMapper _mapper;

        public BookRepository(BookDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper; 
        }
        public async Task<int> AddBookAsync(BookModel book)
        {
            var newBook = _mapper.Map<Bookk>(book);
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }
        // đoạn dưới này là để so sánh với không dùng mapper
        //public IActionResult CreateNew(LoaiModel model)
        //{
        //    try
        //    {
        //        var loai = new Loai
        //        {
        //            TenLoai = model.TenLoai
        //        };
        //        _context.Add(loai);
        //        _context.SaveChanges();
        //        return Ok(loai);
        //    }
        //    catch
        //    {
        //        return BadRequest(0);
        //    }
        //}
        public async Task DeleteBookAsync(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);
            if(book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync(); 
            }
        }

        public async Task<List<BookModel>> GetAllBookAsync()
        {
            var books = await _context.Books.ToListAsync(); 
            return _mapper.Map<List<BookModel>>(books);
        }

        public async Task<BookModel> GetByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id); 
            return _mapper.Map<BookModel>(book); 
        }

        public async Task<List<BookModel>> SearchBookAsync(string des)
        {
            var books = await _context.Books.Where(b => b.Description == des).ToListAsync();
            return _mapper.Map<List<BookModel>>(books);
        }

        public async Task UpdateBookAsync(BookModel Modelbook, int id)
        {
            if(id == Modelbook.Id)
            {
                var updatebook = _mapper.Map<Bookk>(Modelbook); 
                _context.Books.Update(updatebook);
                await _context.SaveChangesAsync(); 
            }
        }
    }
}
