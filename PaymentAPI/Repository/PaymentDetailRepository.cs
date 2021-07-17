using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;
using PaymentAPI.Repository;

namespace PaymentApi.Repository
{
    /*Classe que herda de Repository para ter acesso a implementação que foi feita na classe
    */
    public class PaymentDetailRepository : Repository<PaymentDetail>, IPaymentDetailRepository
    {
        //Receber um dbContext para que seja passado para classe base.
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