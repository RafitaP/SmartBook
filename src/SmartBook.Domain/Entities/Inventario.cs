using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBook.Domain.Entities
{
    public class Inventario : BaseAuditable
    {
        public uint LoteId { get; set; }
        public int Stock { get; set; }
    }
}
