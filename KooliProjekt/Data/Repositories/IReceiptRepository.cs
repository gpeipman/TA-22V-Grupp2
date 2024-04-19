using System.Threading.Tasks;

namespace KooliProjekt.Data.Repositories
{
    public interface IReceiptRepository
    {
        Task<PagedResult<Receipts>> List(int page, int pageSize);
        Task<Receipts> GetById(int id);
        Task Save(Receipts list);
        Task Delete(int id);
    }
}