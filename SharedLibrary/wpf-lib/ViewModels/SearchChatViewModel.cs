using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using dotnet_lib.Services.Interface;
using dotnet_lib.Utitlities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

        private IEnumerable<SearchChatModel> _searchChatModels=new SearchChatModel[] {};
       
        
        public IEnumerable<SearchChatModel> SearchChatModels
        {
            get { return _searchChatModels; }
            set => SetProperty(ref _searchChatModels, value); 
        }
        private string isVisable= "Hidden";

        public string IsVisable
        {
            get { return isVisable; }
            set { SetProperty(ref isVisable, value); }
        }

        public async Task InvokSearch(string search)
        {

            //if (string.IsNullOrEmpty(search))
            //{
            //    var res = await _searchRepository.GetLastSearch();
            //}
            if (ServerUtilities.CheckForInternetConnection())
            {
                IsVisable = "Visible";
           
                var res = await _searchService.SearchChatAsync(search);
                if (res.IsSuccess)
                {
                    var serchModel = res.Data!.ResponseUsers.Select(p => new SearchChatModel
                    {
                        ID = p.Id,
                        InviteName = p.UserName,
                        Name = p.FirstName + p.LastName,
                        Type = Type.PrivateRomm
                    });

                    SearchChatModels = serchModel;
                }
                IsVisable = "Hidden";
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
        PrivateRomm
    }
}
