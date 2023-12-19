namespace KooliProjekt.Data.Repositories
{
    public interface IEvent_DetailsRepository
    {
        Task<PagedResult<Event_details>> List(int page, int pageSize);
        Task<Event_details> GetById(int id);
        Task Save(Event_details list);
        Task Delete(int id);
    }
}