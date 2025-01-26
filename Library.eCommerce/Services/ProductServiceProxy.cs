using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_project1.Models;

namespace Library.eCommerce.Services
{
    public class ProductServiceProxy
    {
        private static object instanceLock = new Object();
        private ProductServiceProxy() { }
        private static ProductServiceProxy? instance;
        public static ProductServiceProxy Current
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductServiceProxy();
                    }
                }

                return instance;
            }
        }

        private List<Product?> list = new List<Product?>();

        public List<Product?> Products => list; // => is the same as products with only a get 
    }
}
