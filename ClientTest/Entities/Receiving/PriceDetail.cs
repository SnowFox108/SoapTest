using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTest.Entities.Receiving
{
    public class PriceDetail
    {
        public TotalAmount TotalAmount { get; set; }
        public BaseAmount BaseAmount { get; set; }
        public Taxes Taxes { get; set; }
    }
}
