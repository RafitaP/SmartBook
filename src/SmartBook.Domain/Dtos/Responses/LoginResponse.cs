using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Application.Dtos.Responses
{
    public record LoginResponse(string AccessToken, DateTime ExpiresAt);
}
