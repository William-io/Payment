using PaymentAPI.Data;
using System.Threading.Tasks;

namespace PaymentAPI.Repository
{
    //Unit of work
    public class Unit : IUnit
    {
        //Definição de cada instancia do objeto
        private PaymentDetailRepository _paymentDetail;
        public PaymentDetailContext _context;

        //Injetando a instancia do contexto
        public Unit(PaymentDetailContext context)
        {
            _context = context;
        }

        public IPaymentDetailRepository PaymentDetailRepository
        {
            //Verifico se a instancia do objeto está vazia NULL, se for nula eu passo uma instancia do contexto
            get
            {
                return _paymentDetail = _paymentDetail ?? new PaymentDetailRepository(_context);
            }
        }

        //persistir os dados
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        //Libera os recursos do context que está sendo injetado
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
