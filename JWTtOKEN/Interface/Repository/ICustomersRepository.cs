using EF.Core.Repository.Interface.Repository;
using JWT_Authentication.Models;

namespace JWT_Authentication.InterFace.Repository
{
    public interface ICustomersRepository:ICommonRepository<TblCustomer>
    {

    }
}
