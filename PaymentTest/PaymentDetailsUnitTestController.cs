using Microsoft.EntityFrameworkCore;
using PaymentAPI.Data;
using PaymentAPI.Repository;

namespace PaymentTest
{
    public class PaymentDetailsUnitTestController
    {
        private IUnit repository;

        //Variavel estatica
        public static DbContextOptions<PaymentDetailContext> dbContextOptions { get; }

        //string de conexão
        public static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=PaymentDetailDB;Trusted_Connection=True;MultipleActiveResultSets=True;";

        //Construtor static para inicializar o dbContextOptions        
        static PaymentDetailsUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<PaymentDetailContext>()
            .UseSqlServer(connectionString)
            .Options;

        }

        public PaymentDetailsUnitTestController()
        {
            var context = new PaymentDetailContext(dbContextOptions);

            //vai ser utilizado os dados do banco em vez de criar um novo contexto
            // DBUnitTestMockInitializer db = new DBUnitTestMockInitializer();
            // db.Seed(context);

            repository = new Unit(context);
        }
    }

}