

import 'package:bomapp/contracts/messageDao.dart';
import 'package:bomapp/controller/listen_message.dart';
import 'package:flutter/material.dart';
import 'package:bomapp/models/chatUsersModel.dart';
import 'package:bomapp/widgets/conversationList.dart';
import 'package:get/get.dart';

class ChatPage extends StatefulWidget {
  const ChatPage({Key? key}) : super(key: key);

  @override
  State<ChatPage> createState() => _ChatPageState();
}

class _ChatPageState extends State<ChatPage> {
  
  List<ChatUsers> chatUsers = [
    ChatUsers("Jane Russel", "Awesome Setup", "images/profile-1.jpg", "Now"),
    ChatUsers(
        "Glady's Murphy", "That's Great", "images/profile-2.jpg", "Yesterday"),
    ChatUsers(
        "Jorge Henry", "Hey where are you?", "images/profile-3.jpg", "31 Mar"),
    ChatUsers("Philip Fox", "Busy! Call me in 20 mins", "images/profile-4.jpg",
        "28 Mar"),
    ChatUsers("Debra Hawkins", "Thankyou, It's awesome", "images/profile-5.jpg",
        "23 Mar"),
    ChatUsers("Jacob Pena", "will update you in evening",
        "images/profile-6.jpg", "17 Mar"),
    ChatUsers("Andrey Jones", "Can you please share the file?",
        "images/profile-7.jpg", "24 Feb"),
    ChatUsers("John Wick", "How are you?", "images/profile-8.jpg", "18 Feb"),
  ];
   final ListenMessageController gc = Get.put(ListenMessageController());
  @override
  Widget build(BuildContext context) {
    return Scaffold(
       backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
        appBar: AppBar(
          title: Text(
            "Conversations",
            style: TextStyle(color: Colors.white54, fontFamily: "Vazir"),
          ),
          centerTitle: false,
          toolbarHeight: 60,
          backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
          elevation: 0,
          actions: <Widget>[
            IconButton(
              icon: Icon(
                Icons.camera_alt,
                color: Colors.white54,
              ),
              onPressed: () {},
            ),
            IconButton(
              icon: Icon(
                Icons.edit,
                color: Colors.white54,
              ),
              onPressed: () {},
            )
          ],
        ),
        body: SingleChildScrollView(
          physics: BouncingScrollPhysics(),
          child: Container(
              color: Color.fromRGBO(38, 37, 44, 1.0),
              child: Column(children: [
                Padding(
                  padding: EdgeInsets.only(top: 16, left: 16, right: 16),
                  child: TextField(
                    style: TextStyle(color: Colors.white),
                    decoration: InputDecoration(
                      hintText: "Search...",
                      hintStyle: TextStyle(color: Colors.grey.shade600),
                      prefixIcon: Icon(
                        Icons.search,
                        color: Colors.grey.shade600,
                        size: 20,
                      ),
                      border: InputBorder.none,
                      filled: true,
                      fillColor: Color.fromRGBO(33, 32, 38, 0.9),
                      contentPadding: EdgeInsets.all(8),
                      enabledBorder: OutlineInputBorder(
                          borderRadius: BorderRadius.circular(20),
                          borderSide: BorderSide(color: Colors.grey.shade700)),
                    ),
                  ),
                ),
                ListView.builder(
                  itemCount: chatUsers.length,
                  shrinkWrap: true,
                  padding: EdgeInsets.only(top: 16),
                  physics: NeverScrollableScrollPhysics(),
                  itemBuilder: (context, index) {
                    return ConversationList(
                      name: chatUsers[index].name,
                      messageText: chatUsers[index].messageText,
                      imageUrl: chatUsers[index].imageURL,
                      time: chatUsers[index].time,
                      isMessageRead: (index == 0 || index == 3) ? true : false,
                    );
                  },
                ),
              ])),
        ));
  }
}
