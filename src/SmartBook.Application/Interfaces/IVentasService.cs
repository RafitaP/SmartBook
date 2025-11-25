using SmartBook.Application.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Application.Interfaces
{
    public interface IVentasService
    {
        Task<uint> CrearAsync(CrearVentaDto dto);
    }
}
