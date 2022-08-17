using Blazored.LocalStorage;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.WASM.Services
{
   public class HubConnect
    {
        HubConnection hubconncetion;
        private readonly Blazored.LocalStorage.ILocalStorageService _localStore;

        public HubConnect(ILocalStorageService localStore)
        {
            _localStore = localStore;
        }

        public async Task BuildConnect()
        {
            
            hubconncetion = new HubConnectionBuilder().WithAutomaticReconnect()
              .WithUrl($"https://localhost:44374/recivehub?access_token={await _localStore.GetItemAsync<string>("token")}", option =>
              {
                  option.Headers.Add("app-search", "true");
                  option.Headers.Add("clientId", Guid.NewGuid().ToString());
                
              })
              .Build();
        }


        public async Task Connect()
       {
                await hubconncetion.StartAsync();
       }
       public async Task DisConnect()
       {
            await hubconncetion.StopAsync();
       }
     
        public void ReciveMessage(Action<string> recive)
        {
          hubconncetion.On<string>("ReciveMessage", recive);
        }

        public async Task Dispose()
        {
           await hubconncetion.DisposeAsync();
      
        }
      
       
    } 
    public class ResultMessage
        {
            public ResultMessageForDetail Message { get; set; }
            public List<string> Src { get; set; }
            public DateTime SendMessage { get; set; }
            public long GroupId { get; set; }
            public long AccountID { get; set; }
        }
        public class ResultMessageForDetail
        {
            public long Id { get; set; }
            public string Message { get; set; }
        public bool Seen { get; set; }
    }
}
