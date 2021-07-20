using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<PaymentDetail>> GetPaymentDetailsByCustomerId()
        {
            //Retorna a lista de payment ordenado por ID
            return await Get().OrderBy(i => i.PaymentDetailId).ToListAsync();
        }
    }
}