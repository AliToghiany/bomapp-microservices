import 'package:bomapp/controller/chat_controller.dart';
import 'package:bomapp/widgets/message.dart';
import 'package:flutter/material.dart';
import 'package:bomapp/models/chatMessageModel.dart';

class ChatDetail extends StatefulWidget {
  ChatDetail({Key? key, this.privateId, this.groupId}) : super(key: key);
  int? privateId;
  int? groupId;
  @override
  State<ChatDetail> createState() => _ChatDetailState();
}

class _ChatDetailState extends State<ChatDetail> {
  final ChatController _chatController=ChatController();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          elevation: 0,
          automaticallyImplyLeading: false,
          backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
          toolbarHeight: 65,
          flexibleSpace: SafeArea(
            child: Container(
              padding: EdgeInsets.only(right: 16),
              child: Row(
                children: <Widget>[
                  IconButton(
                    onPressed: () {
                      Navigator.pop(context);
                    },
                    icon: Icon(
                      Icons.arrow_back,
                      color: Colors.white54,
                    ),
                  ),
                  SizedBox(
                    width: 2,
                  ),
                  CircleAvatar(
                    backgroundImage: NetworkImage(
                        "<https://randomuser.me/api/portraits/men/5.jpg>"),
                    maxRadius: 20,
                  ),
                  SizedBox(
                    width: 12,
                  ),
                  Expanded(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: <Widget>[
                        Text(
                          "Kriss Benwat",
                          style: TextStyle(
                              color: Colors.white,
                              fontSize: 16,
                              fontWeight: FontWeight.w600),
                        ),
                        SizedBox(
                          height: 6,
                        ),
                        Text(
                          "Online",
                          style: TextStyle(
                              color: Colors.grey.shade600, fontSize: 13),
                        ),
                      ],
                    ),
                  ),
                  Icon(
                    Icons.more_horiz,
                    color: Colors.black54,
                  ),
                ],
              ),
            ),
          ),
        ),
        body: Container(
          decoration: BoxDecoration(
            image: DecorationImage(
              image: AssetImage("images/wallpaper_chat.jpg"),
              fit: BoxFit.cover,
            ),
          ),
          child: Stack(
            children: <Widget>[
              Padding(
                  padding: EdgeInsets.only(bottom: 60),
                  child: SingleChildScrollView(
                      child: ListView.builder(
                    itemCount: _chatController.messages.length,
                    shrinkWrap: true,
                    padding: EdgeInsets.only(top: 10, bottom: 10),
                    physics: NeverScrollableScrollPhysics(),
                    itemBuilder: (context, index) {
                     return MessageWidget(_chatController.messages[index]);
                    },
                  ))),
              Align(
                alignment: Alignment.bottomLeft,
                child: Container(
                  padding: EdgeInsets.only(left: 5, bottom: 10, top: 10),
                  height: 60,
                  width: double.infinity,
                  color: Color.fromRGBO(38, 37, 44, 1.0),
                  child: Row(
                    children: <Widget>[
                      GestureDetector(
                        onTap: () {},
                        child: Container(
                          height: 30,
                          width: 30,
                          decoration: BoxDecoration(
                            color: Color.fromRGBO(38, 37, 44, 1.0),
                            borderRadius: BorderRadius.circular(30),
                          ),
                          child: Padding(
                            child: Icon(
                              Icons.gif,
                              color: Colors.grey.shade600,
                              size: 35,
                            ),
                            padding: EdgeInsets.only(bottom: 9),
                          ),
                        ),
                      ),
                      SizedBox(
                        width: 15,
                      ),
                      Expanded(
                        child: TextField(
                          style: TextStyle(fontSize: 15),
                          decoration: InputDecoration(
                              hintText: "Write message...",
                              hintStyle: TextStyle(color: Colors.black),
                              border: InputBorder.none),
                        ),
                      ),
                      SizedBox(
                        width: 15,
                      ),
                      FloatingActionButton(
                        onPressed: () {},
                        child: Icon(
                          Icons.file_present,
                          color: Colors.grey.shade600,
                          size: 25,
                        ),
                        backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
                        elevation: 0,
                        heroTag: "btn1",
                      ),
                      FloatingActionButton(
                        onPressed: () {},
                        child: Icon(
                          Icons.send,
                          color: Colors.grey.shade600,
                          size: 25,
                        ),
                        backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
                        elevation: 0,
                        heroTag: "btn2",
                      ),
                    ],
                  ),
                ),
              ),
            ],
          ),
        ));
  }
}
