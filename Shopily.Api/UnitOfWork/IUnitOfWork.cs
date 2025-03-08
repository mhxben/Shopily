namespace Shopily.Api.UnitOfWork
{
    public interface IUnitOfWork
    {
        //Repositories
        Task<int> SaveChangesAsync();
    }
}
