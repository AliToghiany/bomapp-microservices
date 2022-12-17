using CommunityToolkit.Mvvm.Input;
using dotnet_lib.Connection;
using dotnet_lib.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_lib.Entity;
using wpf_lib.Interface;

namespace wpf_lib.ViewModels
{
    public class ChatViewModel
    {
        private readonly ChatConnect _chatConnect;
        private readonly IMessageRepository _messageRepository;
        public event EventHandler? ChangeChatDetail;
        public Type ChatType { get; set; }
        public long Id { get; set; }
        public ChatViewModel(ChatConnect chatConnect, IMessageRepository messageRepository)
        {
            _chatConnect = chatConnect;
            _messageRepository = messageRepository;
            _chatConnect.ReciveMessage(ReciveMessage);

        }
        public async Task StartConnect()
        {
            await _chatConnect.Start();

        }
        public async Task LoadMessage(long? firstMessage, long? lastMessage, long? groupId, long? toUserId)
        {
            await _chatConnect.LoadMessage(firstMessage, lastMessage, groupId, toUserId);
        }
        void ReciveMessage(string data)
        {
            var responseMessage = JsonConvert.DeserializeObject<ResponseMessage>(data);
            _messageRepository.UpdateMessage(responseMessage!);
            switch (ChatType)
            {
                case Type.Group:
                    if (responseMessage!.GroupId == Id)
                    {
                        if (ChangeChatDetail!=null)
                        {
                         ChangeChatDetail(responseMessage,EventArgs.Empty);
                        }
                    
                    }
                    break;
                case Type.PrivateRomm:
                    if (responseMessage!.User_Id==Id|| responseMessage!.ToUser_Id == Id)
                    {
                        if (ChangeChatDetail != null)
                        {
                            ChangeChatDetail(responseMessage, EventArgs.Empty);
                        }

                    }
                    break;
                default:
                    break;
            }

        }





    }

}
