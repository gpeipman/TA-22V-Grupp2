namespace KooliProjekt.Data.Repositories
{
    public class ReceiptRepository : BaseRepository<Receipts>, IReceiptRepository
    {
        public ReceiptRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Queriyes
    }
}
