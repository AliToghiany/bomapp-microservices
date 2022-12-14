using CommunityToolkit.Mvvm.ComponentModel;
using dotnet_lib.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_lib.Interface;

namespace wpf_lib.ViewModels
{
    public class SearchChatViewModel:ObservableObject
    {
        private readonly ISearchService _searchService;
        private readonly ISearchRepository _searchRepository;

        public SearchChatViewModel(ISearchService searchService, ISearchRepository searchRepository)
        {
            _searchService = searchService;
            _searchRepository = searchRepository;
        }

        private List<SearchChatModel> _searchChatModels;

        public List<SearchChatModel> SearchChatModels
        {
            get { return _searchChatModels; }
            set => SetProperty(ref _searchChatModels, value); 
        }

        public async Task InvokSearch(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                var res = await _searchRepository.GetLastSearch();
            }
        } 

    }
    public class SearchChatModel
    {
        public string Name { get; set; }
        public string InviteName { get; set; }
        public long ID { get; set; }
        public Type Type { get; set; }
    }
    public enum Type
    {
        Group,
        PrivateId
    }
}
