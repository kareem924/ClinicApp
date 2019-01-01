using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.Connection;
using Data.Repositry;
using Framework.UnitOfWork;

namespace IntegrationTest.Repositries
{
    public class BaseRepositoryTest
    {
        protected readonly SqlConnectionFactory Connection;
        protected readonly IUnitOfWork UnitOfWork;

        public BaseRepositoryTest()
        {
            Connection = new SqlConnectionFactory(@"Server=localhost;Database=ClinicApp;Trusted_Connection=True;MultipleActiveResultSets=true");
            UnitOfWork = new DapperUnitOfWork(Connection);
        }
    }
}
