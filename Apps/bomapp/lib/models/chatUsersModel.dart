import 'package:flutter/cupertino.dart';

class ChatUsers{
  String _name;
  String _messageText;
  String _imageURL;
  String _time;
  ChatUsers(@required this._name,@required this._messageText,@required this._imageURL,@required this._time);
  String get name=>_name;
    String get messageText=>_messageText;
      String get imageURL=>_imageURL;
        String get time=>_time;
}