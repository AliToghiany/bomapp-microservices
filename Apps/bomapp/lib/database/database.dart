import 'dart:async';

import 'package:bomapp/contracts/messageDao.dart';
import 'package:bomapp/entities/message.dart';
import 'package:floor/floor.dart';
import 'package:sqflite/sqflite.dart' as sqflite;






@Database(version: 1, entities: [Message])
abstract class AppDatabase extends FloorDatabase 
{
  MessageDao get messageDao;
}