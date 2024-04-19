using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;
using KooliProjekt.Data.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

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
        public virtual async Task<List<Event_details>> GetEvent_details(string loggedInUsername)
        {
            return await _event_DetailsRepository.GetEvent_details(loggedInUsername);
        }
        public async Task Save(Event_details list)
        {
            await _unitOfWork.BeginTransaction();

            try
            {
                await _event_DetailsRepository.Save(list);

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
