using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace KooliProjektMVVM.shared.ApiClient
{
    public class EventApiClient : IEventApiClient, IDisposable
    {
        private static HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7136/api/") };

        public IList<EventModel> List()
        {
            var task = Task.Run(async () => await ListAsync());
            task.Wait();

            return task.Result;
        }

        public async Task<IList<EventModel>> ListAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<EventModel>>("EventAPI");
        }

        public EventModel Get(int id)
        {
            var task = Task.Run(async () => await GetAsync(id));
            task.Wait();

            return task.Result;
        }

        public async Task<EventModel> GetAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<EventModel>("EventAPI/" + id);
        }

        public void Save(EventModel list)
        {
            var task = Task.Run(async () => await SaveAsync(list));
            task.Wait();
        }

        public async Task SaveAsync(EventModel list)
        {
            var url = "EventAPI/";

            if (list.Id == 0)
            {
                await _httpClient.PostAsJsonAsync(url, list);
            }
            else
            {
                using var response = await _httpClient.PutAsJsonAsync(url + list.Id, list);
            }
        }

        public void Delete(int id)
        {
            var task = Task.Run(async () => await DeleteAsync(id));
            task.Wait();
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync("EventAPI/" + id);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
