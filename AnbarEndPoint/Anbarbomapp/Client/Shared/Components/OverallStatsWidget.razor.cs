using Anbarbomapp.Client.Shared.Pages;
using Anbarbomapp.Shared.Dtos.Dashboard;

namespace Anbarbomapp.Client.Shared.Components
{
    public partial class OverallStatsWidget
    {
        public bool IsLoading { get; set; }
        public OverallAnalyticsStatsDataDto Data { get; set; } = new OverallAnalyticsStatsDataDto();

        protected override async Task OnInitAsync()
        {
            await GetData();
            await base.OnInitAsync();
        }

        private async Task GetData()
        {
            try
            {
                IsLoading = true;
                Data = await StateService.GetValue($"{nameof(HomePage)}-{nameof(OverallStatsWidget)}", async () => await HttpClient.GetFromJsonAsync($"Dashboard/GetOverallAnalyticsStatsData", AppJsonContext.Default.OverallAnalyticsStatsDataDto));
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}