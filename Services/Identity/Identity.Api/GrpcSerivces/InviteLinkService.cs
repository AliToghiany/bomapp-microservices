using IniviteLink.Grpc.Protos;

namespace Identity.Api.GrpcSerivces
{
    public class InviteLinkService
    {
        private readonly ProtoIniviteLink.ProtoIniviteLinkClient _protoIniviteLinkBase;

        public InviteLinkService(ProtoIniviteLink.ProtoIniviteLinkClient protoIniviteLinkBase)
        {
            _protoIniviteLinkBase = protoIniviteLinkBase;
        }
        public async Task<InviteLinkResponse> CheckUserName(string invitelink)
        {
          var res= await _protoIniviteLinkBase.FindInviteLinkAsync(new FindInviteLinkRequest { InviteLinkName=invitelink});
            return res;
        }
       
        public async Task<SearchByInviteLinkNameResonse> SearchUserName(string searchKey)
        {
            try
            {
                return await _protoIniviteLinkBase.SearchByInviteLinkNameAsync(new SearchByInviteLinkNameRequest
                {
                    Searchkey = searchKey,
                    Service = "Identity"
                });
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<NewInviteLinkResponse> NewUserName(string UserName)
        {
           
                return await _protoIniviteLinkBase.NewInviteLinkAsync(new NewInviteLinkRequest
                {
                    Name = UserName,
                    Serivce = "Identity"
                });
            
        }
    }
}
