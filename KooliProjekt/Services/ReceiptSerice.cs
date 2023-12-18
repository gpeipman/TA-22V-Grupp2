using KooliProjekt.Data;
using KooliProjekt.Data.Repositories;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IUnitOfWork _unitOfWork;
       public ReceiptService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;

            _receiptRepository = unitOfWork.ReceiptRepository;
        }

        public async Task<PagedResult<Receipts>> List(int page, int pageSize)
        {
            var result = await _receiptRepository.List(page, pageSize);
            return result;
        }
        public async Task<Receipts> GetById(int id)
        {
            var result = await _receiptRepository.GetById(id);
            return result;
        }
        public async Task Save(Receipts list)
        {
            await _unitOfWork.BeginTransaction();

            try
            {
                await _receiptRepository.Save(list);

                await _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                await _unitOfWork.Rollback();
            }
        }
        public async Task Delete(int id)
        {
           await _unitOfWork.BeginTransaction();

            try
            {
                await _receiptRepository.Delete(id);

                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
            }
        }
    }
}