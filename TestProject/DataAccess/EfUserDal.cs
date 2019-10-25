using TestProject.Entities;

namespace TestProject.DataAccess
{
    public class EfUserDal : EfEntityRepositoryBase<User, TestContext>, IUserDal
    {
        
    }
}