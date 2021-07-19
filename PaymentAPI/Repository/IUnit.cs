namespace PaymentAPI.Repository
{
    public interface IUnit
    {
        IPaymentDetailRepository PaymentDetailRepository { get; }
        //Metodo para salvar
        void Commit();

    }

}