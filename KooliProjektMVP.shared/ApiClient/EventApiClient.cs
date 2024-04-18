using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjektMVP.shared.ApiClient
{
    internal class EventApiClient : IEventApiClient, IDisposable
    {
        private static HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7038/api/") };

        public IList<EventModel> List()
        {
            var task = Task.Run(async () => await ListAsync());
            task.Wait();

            return task.Result;
        }

        public async Task<IList<EventModel>> ListAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<EventModel>>("lists");
        }

        public EventModel Get(int id)
        {
            var task = Task.Run(async () => await GetAsync(id));
            task.Wait();

            return task.Result;
        }

        public async Task<EventModel> GetAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<EventModel>("lists/" + id);
        }

        public void Save(EventModel list)
        {
            var task = Task.Run(async () => await SaveAsync(list));
            task.Wait();
        }

        public async Task SaveAsync(EventModel list)
        {
            var url = "lists/";

            if (list.Id == 0)
            {
                await _httpClient.PostAsJsonAsync(url, list);
            }
            else
            {
                await _httpClient.PutAsJsonAsync(url + list.Id, list);
            }
        }

        public void Delete(int id)
        {
            var task = Task.Run(async () => await DeleteAsync(id));
            task.Wait();
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync("lists/" + id);
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
