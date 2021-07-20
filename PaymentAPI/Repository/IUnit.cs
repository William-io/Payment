using System.Threading.Tasks;

namespace PaymentAPI.Repository
{
    public interface IUnit
    {
        IPaymentDetailRepository PaymentDetailRepository { get; }
        //Metodo para salvar
        Task Commit();

    }

}