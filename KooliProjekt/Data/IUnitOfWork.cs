using KooliProjekt.Data.Repositories;

namespace KooliProjekt.Data
{
    public interface IUnitOfWork
    {
        public IEventRepository EventRepository { get; }
        public IEvent_DetailsRepository Event_DetailsRepository { get; }
        public IReceiptRepository ReceiptRepository { get; }
        // Pluss kõik teised repositoryd

        Task BeginTransaction();
        Task Commit();
        Task Rollback();
    }
}
