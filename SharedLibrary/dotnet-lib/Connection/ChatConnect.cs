using dotnet_lib.Utitlities;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_lib.Connection
{
    public class ChatConnect
    {
         HubConnection connection;
        public ChatConnect()
        {
            connection = new HubConnectionBuilder()
                .WithUrl($"{ServerUtilities.HUB}/ReciveHub")
                .Build();
            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }
        public async Task<bool> Start()
        {
            
            try
            {
                await connection.StartAsync();
                return true;    
               
            }
            catch 
            {
                return false;
            }
        }
        public async Task ReciveMessage(Action<string> action)
        {
            connection.On<string>("ReciveMessage", action);
        }
      
    }
}
