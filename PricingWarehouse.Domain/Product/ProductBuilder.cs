using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricingWarehouse.Domain.Product
{
    public interface IProductBuilder<T> where T : IProduct
    {
        T Build();
    }
}
