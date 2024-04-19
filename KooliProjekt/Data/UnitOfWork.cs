using KooliProjekt.Data.Repositories;
using KooliProjekt.Data;
using System.Threading.Tasks;

namespace KooliProjekt.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IEventRepository EventRepository { get; }

        public IEvent_DetailsRepository Event_DetailsRepository { get; }

        public IReceiptRepository ReceiptRepository { get; }

        // Pluss kõik teised repositoryd

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context, IEventRepository eventRepository, IEvent_DetailsRepository event_DetailsRepository, IReceiptRepository receiptRepository)
        {
            _context = context;

            EventRepository = eventRepository;
            
            Event_DetailsRepository = event_DetailsRepository;

            ReceiptRepository = receiptRepository;
        }

        public async Task BeginTransaction()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
            await _context.Database.CommitTransactionAsync();
        }

        public async Task Rollback()
        {
            await _context.Database.RollbackTransactionAsync();
        }
    }
}
