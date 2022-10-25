import 'dart:js_util';

import 'package:flutter_background_service/flutter_background_service.dart';
import 'package:flutter_local_notifications/flutter_local_notifications.dart';
class Noti{
  static Future initialize(FlutterLocalNotificationsPlugin flutterLocalNotificationsPlugin) async{
    var androidinitialze=new AndroidInitializationSettings('mipmap/ic_launcher');
    var iOSInitialaze=new IOSInitializationSettings();
    var initialzionsSettings=new InitializationSettings(android: androidinitialze,iOS: iOSInitialaze);
    await flutterLocalNotificationsPlugin.initialize(initialzionsSettings);
  }
}