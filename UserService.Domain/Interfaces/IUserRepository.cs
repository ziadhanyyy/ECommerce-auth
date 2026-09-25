using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Entities;

namespace UserService.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?>GetByEmailAsync(string email);
        Task<int> CreateAsync(User user);
    }
}
