using EF.Core.Repository.Interface.Repository;
using EF.Core.Repository.Manager;
using JWT_Authentication.DatabaseContext;
using JWT_Authentication.InterFace.Manager;
using JWT_Authentication.Models;
using JWT_Authentication.Repository;

namespace JWT_Authentication.Manager
{
    public class CustomerManager : CommonManager<TblCustomer>, ICustomerManager
    {
        public CustomerManager(ApplicationDbContext dbContext) : base(new CustomerRepository(dbContext))
        {
        }
    }
}
