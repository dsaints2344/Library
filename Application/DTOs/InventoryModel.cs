using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class InventoryModel
    {
        public int BookId { get; set; }
        public int NewAmount { get; set; } = 0;
    }
}
