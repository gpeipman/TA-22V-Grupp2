using System.Collections.Generic;
using KooliProjekt.Data;
using KooliProjekt.Data.Repositories;

namespace KooliProjekt.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _EventRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;

            _EventRepository = unitOfWork.EventRepository;
        }

        public async Task<PagedResult<Event>> List(int page, int pageSize)
        {
            var result = await _EventRepository.List(page, pageSize);

            return result;
        }

        public async Task<Event> GetById(int id)
        {
            var result = await _EventRepository.GetById(id);

            return result;
        }

        public async Task Save(Event list)
        {
            await _unitOfWork.BeginTransaction();

            try
            {
                await _EventRepository.Save(list);

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
                await _EventRepository.Delete(id);

                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                await _unitOfWork.Rollback();
            }
        }
    }
}