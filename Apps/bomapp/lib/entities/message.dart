import 'dart:ffi';

import 'package:bomapp/models/ResponseMessage.dart';
import 'package:floor/floor.dart';

@entity
class Message {
  @PrimaryKey(autoGenerate: true)
  int? id;
  int? orginalId;
  String? messageId;
  int? userId;
  int? groupId;
  int? privateId;
  int? replyMessageId;
  String? text;
  int? stickerId;
  int? gifId;

 
  Message.fromResponseMessage(ResponseMessage responseMessage) {
orginalId=responseMessage.id;
messageId=responseMessage.messageId;
userId=responseMessage.userId;
gifId=responseMessage.gifId;
groupId=responseMessage.groupId;
replyMessageId=responseMessage.replyToMessageId;
text=responseMessage.text;
stickerId=responseMessage.stickerId;
gifId=responseMessage.gifId;

  }
}
