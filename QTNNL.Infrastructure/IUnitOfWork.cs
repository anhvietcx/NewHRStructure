using System;
using System.Collections.Generic;
using System.Text;

namespace QTNNL.Infrastructure.Services
{
    public interface IUnitOfWork
    {
        // ICustomerRepository Customers { get; }
     
        int SaveChanges();
    }
}
