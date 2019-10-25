using TestProject.Entities;

namespace TestProject.DataAccess
{
    public class EfProductDal : EfEntityRepositoryBase<Product, TestContext>,IProductDal
    {
        
    }
}