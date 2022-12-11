using dotnet_lib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace dotnet_lib.Services
{
    public static class ToResultDto
    {
        public static async Task<ResultDto<T>> ToResultdto<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                return new ResultDto<T>
                {
                    IsSuccess = false,
                    Message = await response.Content.ReadAsStringAsync(),
                    StatusCode = (int)response.StatusCode
                };
            }
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return
                new ResultDto<T> { 
                    Data = JsonConvert.DeserializeObject<T>(dataAsString)!,
                    IsSuccess = true

                };
        }
    }
}
