using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data.Repositories;


namespace KooliProjekt.Services
{
    public class Event_detailsService : IEvent_detailsService
    {
        private readonly IEvent_DetailsRepository _event_DetailsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public Event_detailsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _event_DetailsRepository = unitOfWork.Event_DetailsRepository;
        }
        public async Task<PagedResult<Event_details>> List(int page, int pageSize)
        {
            var result = await _event_DetailsRepository.List(page, pageSize);
            return result;
        }
        public async Task<Event_details> GetById(int id)
        {
            var result = await _event_DetailsRepository.GetById(id);

            return result;
        }
        public async Task Save(Event_details list)
        {
            await _unitOfWork.BeginTransaction();

            try
            {
                await _event_DetailsRepository.Save(list);

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
                await _event_DetailsRepository.Delete(id);

                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
            }
        }
        }
}