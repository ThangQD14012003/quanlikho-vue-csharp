using ApiNetCore6Book.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiNetCore6Book.Repositories
{
    public interface IBookRepository
    {
        public Task<List<BookModel>> GetAllBookAsync();
        public Task<BookModel> GetByIdAsync(int id);
        public Task<int> AddBookAsync(BookModel book);
        public Task UpdateBookAsync(BookModel book, int id);
        public Task DeleteBookAsync(int id);
        public Task<List<BookModel>> SearchBookAsync(string des); 
    }
}
