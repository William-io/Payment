using System.Collections.Generic;
using PaymentAPI.Models;
using PaymentAPI.Repository;

namespace PaymentApi.Repository
{
    /*interface especifica para PaymentDetail que herda da interface generica

    */
    public interface IPaymentDetailRepository : IRepository<PaymentDetail>
    {
        //Método especifico para obter a lista de PaymentDetail por ID
        IEnumerable<PaymentDetail> GetPaymentDetailsByCustomerId();
    }

}