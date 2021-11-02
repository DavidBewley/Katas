using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApiClient.Models;
using Newtonsoft.Json;

namespace ApiClient.Repositories
{
    public class EmployeeApi : IEmployeeApi
    {
        private readonly HttpClient _httpClient;

        public EmployeeApi(string baseAddress)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAddress),
            };
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var response = await _httpClient.GetAsync("employee");
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<List<Employee>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Employee> GetEmployee(Guid id)
        {
            var response = await _httpClient.GetAsync($"employee/{id}");
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<Employee>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Employee> CreateEmployee(Employee employee)
        {
            var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("employee", content);

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<Employee>(await response.Content.ReadAsStringAsync());
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("employee", content);

            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<Employee>(await response.Content.ReadAsStringAsync());
        }

        public async Task DeleteEmployee(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"employee/{id}");

            response.EnsureSuccessStatusCode();
        }
    }
}
