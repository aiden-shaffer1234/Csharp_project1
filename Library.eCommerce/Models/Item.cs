using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_project1.Models;

namespace Library.eCommerce.Models
{
    public class Item
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantitiy {  get; set; }
    }
}
