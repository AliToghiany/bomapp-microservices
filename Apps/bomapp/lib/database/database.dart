import 'dart:async';

import 'package:bomapp/contracts/contactDao.dart';
import 'package:bomapp/contracts/messageDao.dart';
import 'package:bomapp/contracts/userDao.dart';
import 'package:bomapp/entities/contact.dart';
import 'package:bomapp/entities/message.dart';
import 'package:bomapp/entities/user.dart';

import 'package:floor/floor.dart';

import 'package:sqflite/sqflite.dart' as sqflite;



part 'database.g.dart';


@Database(version: 1, entities: [Message,User,Contact])
abstract class AppDatabase extends FloorDatabase 
{
  MessageDao get messageDao;
  UserDao get userDao;
  ContactDao get contactDao;
}