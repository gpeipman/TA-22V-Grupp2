using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Services
{
    public class ReceiptService
    {
        private readonly ApplicationDbContext _context;

        public ReceiptService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PagedResult<Receipts>> List(int page, int pageSize)
        {
            var result = await _context.Receipts.GetPagedAsync(page, pageSize);
            return result;
        }
        public async Task<Receipts> GetById(int id)
        {
            var result = await _context.Receipts.FirstOrDefaultAsync(m => m.Id == id);

            return result;
        }
        public async Task Save(Receipts list)
        {
            if (list.Id == 0)
            {
                _context.Add(list);
            }
            else
            {
                _context.Update(list);
            }

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var receipt = await _context.Receipts.FindAsync(id);
            if (receipt != null)
            {
                _context.Receipts.Remove(receipt);
            }

            await _context.SaveChangesAsync();
        }
    }
}