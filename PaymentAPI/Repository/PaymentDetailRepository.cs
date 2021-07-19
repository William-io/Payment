using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;
using PaymentAPI.Repository;

namespace PaymentAPI.Repository
{
    public class PaymentDetailRepository : Repository<PaymentDetail>, IPaymentDetailRepository
    {
        public PaymentDetailRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<PaymentDetail> GetPaymentDetailsByCustomerId()
        {
            //Retorna a lista de payment ordenado por ID
            return Get().OrderBy(i => i.PaymentDetailId).ToList();
        }
    }
}