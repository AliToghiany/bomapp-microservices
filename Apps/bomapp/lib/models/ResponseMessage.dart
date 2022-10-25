class ResponseMessage {
  int? id;
  int? userId;
  int? groupId;
  int? toUserId;
  int? replyToMessageId;
  String? text;
  int? stickerId;
  int? gifId;
  List<String>? files;
  String? messageId;

  ResponseMessage(
      {this.userId,
      this.groupId,
      this.toUserId,
      this.replyToMessageId,
      this.text,
      this.stickerId,
      this.gifId,
      this.files});

  ResponseMessage.fromJson(Map<String, dynamic> json) {
    userId = json['user_Id'];
    groupId = json['groupId'];
    toUserId = json['toUser_Id'];
    replyToMessageId = json['replyToMessageId'];
    text = json['text'];
    stickerId = json['stickerId'];
    gifId = json['gifId'];
    files = json['files'].cast<String>();
    messageId=json['message_Id'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['user_Id'] = this.userId;
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