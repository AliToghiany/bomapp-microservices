import 'package:flutter/material.dart';
import 'package:bomapp/models/chatUsersModel.dart';

class SelectUserList extends StatefulWidget {
  SelectUserList(
      {Key? key,
      required this.name,
      required this.online,
      required this.imageUrl})
      : super(key: key);
  String name;
  String online;
  String imageUrl;

  @override
  State<SelectUserList> createState() => _SelectUserListState();
}

class _SelectUserListState extends State<SelectUserList> {
  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        Navigator.push(context, MaterialPageRoute(builder: (context) {
          return Text("");
        }));
      },
      child: Container(
        padding: EdgeInsets.only(left: 16, right: 16, top: 5, bottom: 5),
        child: Column(children: [
          Row(
            children: <Widget>[
              Expanded(
                child: Row(
                  children: <Widget>[
                    CircleAvatar(
                      backgroundImage: Image.asset(widget.imageUrl).image,
                      
                      backgroundColor: Colors.red[400],
                      maxRadius: 27,
                    ),
                    SizedBox(
                      width: 20,
                    ),
                    Expanded(
                      child: Container(
                        color: Colors.transparent,
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          
                          children: <Widget>[
                            Text(
                              widget.name,
                              style: TextStyle(fontSize: 16,color: Colors.white),
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
                    ),
                    Align(child: Icon(Icons.task_alt,color: Colors.green,),alignment: Alignment.topRight,),
                  ],
                ),
              ),
              // Text(widget.time,style: TextStyle(fontSize: 12,fontWeight: widget.isMessageRead?FontWeight.bold:FontWeight.normal),),
            ],
          ),
          SizedBox(
            height: 15,
          ),
          Padding(padding:EdgeInsets.only(left: 54), child: 
          Container(
            color: Colors.grey[850],
            height: 1,
          )),
          SizedBox(
            height: 15,
          ),
        ]),
      ),
    );
  }
}
