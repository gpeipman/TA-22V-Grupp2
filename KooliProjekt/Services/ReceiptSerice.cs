using KooliProjekt.Data;
using KooliProjekt.Data.Repositories;
using Microsoft.EntityFrameworkCore;


namespace KooliProjekt.Services
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository _receiptRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEvent_DetailsRepository _event_DetailsRepository;
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

        public async Task Pay1(int? id)
        {
            var @event = await _event_DetailsRepository.GetById(id.Value);
            @event.is_payed = true;
            await _event_DetailsRepository.Save(@event);
        }

        public async Task Pay2(int? id)
        {
            var @event = await _event_DetailsRepository.GetById(id.Value);
            @event.is_payed = true;
            await _event_DetailsRepository.Save(@event);
        }

        public async Task Save(Receipts list)
        {
            await _unitOfWork.BeginTransaction();

            try
            {
                await _receiptRepository.Save(list);

                await _unitOfWork.Commit();
            }
            catch (Exception ex)
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

        public int Pay(int? id)
        {
            return id.Value;
        }
    }
}