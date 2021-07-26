using PaymentAPI.Data;
using PaymentAPI.Models;
using System.Security;

namespace PaymentTest
{
    //Inicializar bando de dados c/ dados
    public class DBUnitTestMockInitializer
    {
        public DBUnitTestMockInitializer() {}

        //Vai ser incluido na tabela para teste
        public void Seed(PaymentDetailContext context)
{
            context.paymentDetails.Add
                (new PaymentDetail { PaymentDetailId = 999, CardOwnerName = "xUnit-TEST", CardNumber = "12345678910111213", ExpirationDate = "1122", SecurityCode = "123" });

            context.SaveChanges();
            
        }
    }
}



