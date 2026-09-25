using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserService.Application.DTO
{
    public record RegisterRequest(string Email, string name, string Password);
    public record LoginRequest(string Email, string Password);
    public record AuthResponse(string Token);

}
