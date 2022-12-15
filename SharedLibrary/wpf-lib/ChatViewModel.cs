using dotnet_lib.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_lib
{
    public class ChatViewModel
    {
        private readonly ChatConnect _chatConnect;

        public ChatViewModel(ChatConnect chatConnect)
        {
            _chatConnect = chatConnect;
            _chatConnect.ReciveMessage(ReciveMessage);
        }
        void ReciveMessage(string data)
        {

        }
    }
}
