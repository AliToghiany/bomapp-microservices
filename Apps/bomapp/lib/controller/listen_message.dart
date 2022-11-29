import 'dart:convert';
import 'dart:js_util';

import 'package:bomapp/contracts/messageDao.dart';
import 'package:bomapp/entities/message.dart';
import 'package:bomapp/models/ResponseMessage.dart';
import 'package:signalr_netcore/signalr_client.dart';
import 'package:get/get.dart';

class ListenMessageController extends GetxController {


  final serverUrl = "https://localhost:44374/recivehub";
  ListenMessageController() {
    final httpConnectionOptions = new HttpConnectionOptions(
         
          accessTokenFactory: () => Future.value('AAAAAAAAAAAAAAAAAAAAANRILgAAAAAAnNwIzUejRCOuH5E6I8xnZz4puTs%3D1Zv7ttfk8LF81IUq16cHjhLTvJu4FA33AGWWjCpTnA'),
        
          logMessageContent: true,
       );
    final hubConnection = HubConnectionBuilder().withUrl(serverUrl,options: httpConnectionOptions).build();
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

