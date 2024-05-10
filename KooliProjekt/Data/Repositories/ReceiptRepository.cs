using KooliProjekt.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace KooliProjekt.Data.Repositories
{
    public class ReceiptRepository : BaseRepository<Receipts>, IReceiptRepository
    {
        public ReceiptRepository(ApplicationDbContext context) : base(context)
        {
        }

        public virtual async Task<PagedResult<Receipts>> List(int page, int pageSize)
        {
            var result = await Context.Receipts
            .Include(o => o.user)
            .Include(o => o.@event)
            .GetPagedAsync(page, pageSize);

            return result;
        }

        public virtual async Task<Receipts> GetById(int id)
        {
            var result = await Context.Receipts.FindAsync(id);

            return result;
        }


        public virtual async Task Save(Receipts entity)
        {
            if (entity.Id == 0)
            {
                await Context.AddAsync(entity);
            }
            else
            {
                Context.Update(entity);
            }
        }

        public virtual async Task Delete(int id)
        {
            var entity = await Context.Receipts.FindAsync(id);
            if (entity != null)
            {
                Context.Receipts.Remove(entity);
            }
        }
    }
}
