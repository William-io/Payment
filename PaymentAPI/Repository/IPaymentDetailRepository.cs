using System.Collections.Generic;
using System.Threading.Tasks;
using PaymentAPI.Models;
using PaymentAPI.Repository;

namespace PaymentAPI.Repository
{
    public interface IPaymentDetailRepository : IRepository<PaymentDetail>
    {
        //Método especifico para obter a lista de PaymentDetail por ID
        Task <IEnumerable<PaymentDetail>> GetPaymentDetailsByCustomerId();
    }

}