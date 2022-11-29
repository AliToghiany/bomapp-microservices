import 'dart:convert';

import 'package:bomapp/models/ResponseMessage.dart';
import 'package:bomapp/services/ResultDto.dart';
import 'package:bomapp/utils/tokentUtil.dart';
import 'package:http/http.dart';
import 'ApiSetting.dart';

class ChatService{
  Future<ResultDto<ResponseMessage>> newMessage(MessageRequest messageRequest) async{
   
    var body = jsonEncode(
        messageRequest.toJson());
    Map<String, String> header = ApiSetting.contenttype;
    header.addAll({"Authorization": TokenUtilities.GetToken()!});
    var res = await post(Uri.parse(ApiSetting.URL + "/Message/NewMessage"),
        body: body, headers: header);
    

    if (res.statusCode == 200) {
      return ResultDto<ResponseMessage>(
        200,
        "",
        true,
        data: ResponseMessage.fromJson(jsonDecode(res.body))
      );
    } else {
      return ResultDto<ResponseMessage>(res.statusCode, res.body, false);
    }
  }
}
class MessageRequest {

  int? groupId;
  int? toUserId;
  int? replyToMessageId;
  String? text;
  int? stickerId;
  int? gifId;
  List<String>? files;

  MessageRequest(
      {
      this.groupId,
      this.toUserId,
      this.replyToMessageId,
      this.text,
      this.stickerId,
      this.gifId,
      this.files});

  MessageRequest.fromJson(Map<String, dynamic> json) {
   
    groupId = json['group_Id'];
    toUserId = json['toUser_Id'];
    replyToMessageId = json['reply_To_MessageId'];
    text = json['text'];
    stickerId = json['sticker_Id'];
    gifId = json['gif_Id'];
    files = json['files'].cast<String>();
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['group_Id'] = this.groupId;
    data['toUser_Id'] = this.toUserId;
    data['reply_To_MessageId'] = this.replyToMessageId;
    data['text'] = this.text;
    data['sticker_Id'] = this.stickerId;
    data['gif_Id'] = this.gifId;
    data['files'] = this.files;
    return data;
  }
}