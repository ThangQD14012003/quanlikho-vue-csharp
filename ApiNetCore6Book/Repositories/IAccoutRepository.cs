using ApiNetCore6Book.Models;
using Microsoft.AspNetCore.Identity;

namespace ApiNetCore6Book.Repositories
{
    public interface IAccoutRepository
    {
        public Task<IdentityResult> SigUpAsync(SigUpModel model);
        public Task<string> SigInAsync(SigInModel model);   
    }
}
