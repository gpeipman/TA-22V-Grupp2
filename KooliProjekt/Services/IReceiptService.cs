using KooliProjekt.Data;
using System.Threading.Tasks;

namespace KooliProjekt.Services
{
    public interface IReceiptService
    {
        Task<PagedResult<Receipts>> List(int page, int pageSize);
        Task<Receipts> GetById(int id);
        Task Save(Receipts list);
        Task Delete(int id);
    }
}
