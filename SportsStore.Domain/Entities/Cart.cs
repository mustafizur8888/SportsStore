using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> lineCollections = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollections.FirstOrDefault(p => p.Product.ProductID == product.ProductID);
            if (line == null)
            {
                lineCollections.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollections.RemoveAll(x => x.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollections.Sum(e => e.Product.Price * e.Quantity);
        }

        public void Clear()
        {
            lineCollections.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollections; }
        }
    }
}
