import 'package:bomapp/screens/chatDetail.dart';
import 'package:bomapp/widgets/profileAvata.dart';
import 'package:flutter/material.dart';
import 'package:bomapp/models/chatUsersModel.dart';
import 'package:get/get.dart';

class UserList extends StatefulWidget {
  UserList(
      {Key? key,
      required this.name,
      required this.lname,
      required this.online,
      required this.imageUrl,

      
      })
      : super(key: key);
  String name;
  String lname;
  String online;
  String imageUrl;

  @override
  State<UserList> createState() => _UserListState();
}

class _UserListState extends State<UserList> {
  @override
  Widget build(BuildContext context) {
    return InkWell(
      onTap: () {
     Get.to(ChatDetail());
      },
      child: Container(
        padding: EdgeInsets.only(left: 16, right: 16,top: 5,bottom: 5),
        child: Column(children: [
          Row(
            children: <Widget>[
              Expanded(
                child: Row(
                  children: <Widget>[
                    ProfileViewer(widget.name, widget.lname, widget.imageUrl, 20, 14,() {}),
                    SizedBox(
                      width: 10,
                    ),
                   Container(
                        color: Colors.transparent,
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          
                          children: <Widget>[
                            Text(
                              widget.name+" "+widget.lname,
                              style: TextStyle(fontSize: 14,color: Colors.white),
                            ),
                            SizedBox(
                              height: 6,
                            ),
                            Text(
                              widget.online,
                              style: TextStyle(
                                  fontSize: 13, color: Colors.grey.shade600),
                            ),
                            
                  
                          ],
                        ),
                      ),
                   
                  
                  ],
                ),
              ),
              // Text(widget.time,style: TextStyle(fontSize: 12,fontWeight: widget.isMessageRead?FontWeight.bold:FontWeight.normal),),
            ],
          ),
       
            SizedBox(
            height: 5,
          ),
       
          
        ]),
      ),
    );
  }
}
