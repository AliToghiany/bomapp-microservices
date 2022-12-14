using dotnet_lib.Services.Interface;

namespace bomapp
{
    public class SearchViewModel
    {
        private readonly ISearchService _searchService;

        public SearchViewModel(ISearchService searchService)
        {
            _searchService = searchService;
        }
    }
}