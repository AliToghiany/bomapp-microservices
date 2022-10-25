import 'dart:convert';
import 'dart:js_util';

import 'package:bomapp/contracts/messageDao.dart';
import 'package:bomapp/entities/message.dart';
import 'package:bomapp/models/ResponseMessage.dart';
import 'package:signalr_netcore/signalr_client.dart';
import 'package:get/get.dart';

class ListenMessageController extends GetxController {
 final MessageDao messageDao;
 
  final serverUrl = "https://localhost:44374/recivehub";
  ListenMessageController(this.messageDao) {
    final hubConnection = HubConnectionBuilder().withUrl(serverUrl).build();
    
    hubConnection.start();
    
    hubConnection.on("ReciveMessage", handleReciveMessage);
    
  }
  void handleReciveMessage(List<Object?>? data)
  {
    var json=jsonDecode(data!.first.toString());
    var responseMessage=ResponseMessage.fromJson(json);
    var message=Message.fromResponseMessage(responseMessage);


  }


}

