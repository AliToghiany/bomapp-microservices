import 'package:flutter/cupertino.dart';

class UserForList {
  String _name;
  String _lname;
  String _online;
  String _imageURL;

  UserForList(
      @required this._name,@required this._lname, @required this._online, @required this._imageURL);
  String get name => _name;
  String get online => _online;
  String get imageURL => _imageURL;
  String get lname=>_lname;
}
