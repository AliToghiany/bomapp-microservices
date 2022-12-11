import 'package:bomapp/entities/message.dart';
import 'package:bomapp/services/ResultDto.dart';
import 'package:bomapp/services/chatService.dart';
import 'package:get/get.dart';

class ChatController extends RxController {

final messages=<Message>[].obs;


  final ChatService _chatService=ChatService();
  
  Future<ResultDto> newMessage(String message, int? replayId,int? groupId,int? toUserId) async {
    MessageRequest m = MessageRequest(
        groupId: groupId, toUserId: toUserId, replyToMessageId: replayId);
      var res=await _chatService.newMessage(m);
      return res;
    
  }
  Future loadMessage(int? groupId,int? toUserId,int lastMessageId,int startMessageId) async{

  }
}
