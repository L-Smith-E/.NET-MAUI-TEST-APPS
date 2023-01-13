//using Android.OS;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoMAUIClient.Models;

namespace ToDoMAUIClient.DataServices
{
    //Dependecy Injection example using a singlton
    public class RestDataService : IRestDataService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public RestDataService()
        {
            _httpClient = new HttpClient();
            //Android does not like using localhost and has a development ip address specifically made for it, use https in production code 
            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5309" : "https://localhost:7209";
            //string interpolation
            _url = $"{_baseAddress}/api";

            //Json serialisation 
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }



        public Task AddToDoAsync(ToDo toDo)
        {
            throw new NotImplementedException();
        }

        public Task DeleteToDoAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ToDo>> GetAllToDosAsync()
        {
            List<ToDo> todos = new List<ToDo>();

            //If no internet connection dont bother with request
            if(Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                System.Diagnostics.Debug.WriteLine("---> No Internet access...");
                return todos;
            }

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_url}/todo");
                
                if(response.IsSuccessStatusCode ) 
                {
                    string content = await response.Content.ReadAsStringAsync();      
                    todos  = JsonSerializer.Deserialize<List<ToDo>>(content, _jsonSerializerOptions);
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("---> Non Http 2xx response");
                }
            }

            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Whoops exception: {ex.Message}");
            }

            return todos;
        }

        public Task UpdateToDoAsync(ToDo toDo)
        {
            throw new NotImplementedException();
        }
    }
}
