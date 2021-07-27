using PaymentAPI.Data;
using PaymentAPI.Models;
using System.Security;

namespace PaymentTest
{
    //Inicializar bando de dados c/ dados
    public class DBUnitTestMockInitializer
    {
        public DBUnitTestMockInitializer() { }

        //Vai ser incluido na tabela para teste
        public void Seed(PaymentDetailContext context)
        {
            context.paymentDetails.Add(new PaymentDetail { PaymentDetailId = 999, CardOwnerName = "Julia-TEST", CardNumber = "12345678910111213", ExpirationDate = "1122", SecurityCode = "123" });
            context.paymentDetails.Add(new PaymentDetail { PaymentDetailId = 2, CardOwnerName = "Costa-TEST", CardNumber = "12345678910111213", ExpirationDate = "1122", SecurityCode = "123" });
            context.paymentDetails.Add(new PaymentDetail { PaymentDetailId = 3, CardOwnerName = "Debora-TEST", CardNumber = "12345678910111213", ExpirationDate = "1122", SecurityCode = "123" });
            context.paymentDetails.Add(new PaymentDetail { PaymentDetailId = 4, CardOwnerName = "Jess-TEST", CardNumber = "12345678910111213", ExpirationDate = "1122", SecurityCode = "123" });
            context.paymentDetails.Add(new PaymentDetail { PaymentDetailId = 5, CardOwnerName = "Mari-TEST", CardNumber = "12345678910111213", ExpirationDate = "1122", SecurityCode = "123" });
            context.paymentDetails.Add(new PaymentDetail { PaymentDetailId = 6, CardOwnerName = "Bol-TEST", CardNumber = "12345678910111213", ExpirationDate = "1122", SecurityCode = "123" });
            context.paymentDetails.Add(new PaymentDetail { PaymentDetailId = 7, CardOwnerName = "Gui-TEST", CardNumber = "12345678910111213", ExpirationDate = "1122", SecurityCode = "123" });

            context.SaveChanges();

        }
    }
}



