using Grpc.Core;
using IniviteLink.Grpc.Entites;
using IniviteLink.Grpc.Protos;
using InviteLink.Grpc.Data;
using Microsoft.Extensions.Logging.Configuration;
using MongoDB.Driver;

namespace IniviteLink.Grpc.Services
{

    public class InviteLinkService:ProtoIniviteLink.ProtoIniviteLinkBase
    {
        private readonly HubDbContext _dbContext;

        public InviteLinkService(HubDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<NewInviteLinkResponse> NewInviteLink(NewInviteLinkRequest request, ServerCallContext context)
        {
            var invite = new InviteLinkEntity
            {
                InviteLink_Name = request.Name,
                ServiceName = request.Serivce
            };
            await _dbContext.InviteLinks.InsertOneAsync(invite);
            return new NewInviteLinkResponse { InviteName= request.Name };
        }
        public override async Task<RemoveInviteLinkResponse> RemoveInviteLink(RemoveInviteLinkRequest request, ServerCallContext context)
        {

            await _dbContext.InviteLinks.DeleteOneAsync(p=>p.InviteLink_Name==request.InviteName);
            return new RemoveInviteLinkResponse{
                 IsSuccess=true
            };
        }
        public override async Task<InviteLinkResponse?> FindInviteLink(FindInviteLinkRequest request, ServerCallContext context)
        {
            var res = await (await _dbContext.InviteLinks.FindAsync(p => p.InviteLink_Name == request.InviteLinkName)).FirstOrDefaultAsync();
            if (res != null)
                return new InviteLinkResponse
                {
                    InviteLinkName = request.InviteLinkName,
                    Serivce = res.ServiceName

                };
            else return new InviteLinkResponse();
           
        }
       
        public override async Task<SearchByInviteLinkNameResonse> SearchByInviteLinkName(SearchByInviteLinkNameRequest request, ServerCallContext context)
        {
            var res = await _dbContext.InviteLinks.FindAsync(p => p.InviteLink_Name.Contains( request.Searchkey)&&p.ServiceName==request.Service);
         
            SearchByInviteLinkNameResonse search = new SearchByInviteLinkNameResonse();
            search.Listresponse.AddRange(res.ToList().Take(3).Select(p => new SearchInviteLinkResponse
            {
               
                InviteLinkName = p.InviteLink_Name,
               
            }));
            return search;
        }
       



    }
}
