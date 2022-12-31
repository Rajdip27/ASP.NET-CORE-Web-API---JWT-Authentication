using EF.Core.Repository.Repository;
using JWT_Authentication.InterFace.Repository;
using JWT_Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace JWT_Authentication.Repository
{
    public class CustomerRepository : CommonRepository<TblCustomer>, ICustomersRepository
    {
        public CustomerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
