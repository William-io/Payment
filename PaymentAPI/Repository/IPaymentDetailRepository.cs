using System.Collections.Generic;
using PaymentAPI.Models;
using PaymentAPI.Repository;

namespace PaymentAPI.Repository
{
    public interface IPaymentDetailRepository : IRepository<PaymentDetail>
    {
        //Método especifico para obter a lista de PaymentDetail por ID
        IEnumerable<PaymentDetail> GetPaymentDetailsByCustomerId();
    }

}