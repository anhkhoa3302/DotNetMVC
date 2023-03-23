using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNPayment
{
    public interface IVNPayPayment
    {
        public string CreatePaymentUrl(VnPayRequest vnPayRequest);
    }
}
