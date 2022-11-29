import 'package:bomapp/entities/message.dart';
import 'package:bomapp/utils/tokentUtil.dart';
import 'package:flutter/material.dart';
class MessageWidget extends StatefulWidget {
  const MessageWidget(this.message,{ Key? key }) : super(key: key);
final Message message;
  @override
  State<MessageWidget> createState() => _MessageWidgetState();
}

class _MessageWidgetState extends State<MessageWidget> {
  @override
  Widget build(BuildContext context) {
    
      return Container(
                        padding: EdgeInsets.only(
                            left: 14, right: 14, top: 10, bottom: 10),
                        child: Align(
                          alignment: (widget.message.userId != TokenUtilities.GetMyId()
                              ? Alignment.topLeft
                              : Alignment.topRight),
                          child: Container(
                              width: 125,
                              decoration: BoxDecoration(
                                borderRadius:
                                    (widget.message.userId != TokenUtilities.GetMyId()
                                        ? BorderRadius.only(
                                            bottomLeft: Radius.circular(0),
                                            bottomRight: Radius.circular(15),
                                            topLeft: Radius.circular(15),
                                            topRight: Radius.circular(15))
                                        : BorderRadius.only(
                                            bottomLeft: Radius.circular(15),
                                            topLeft: Radius.circular(15),
                                            topRight: Radius.circular(15))),
                                color:
                                    (widget.message.userId != TokenUtilities.GetMyId()
                                        ? Colors.grey.shade200
                                        : Colors.blue[200]),
                              ),
                              padding: EdgeInsets.all(2),
                              child: Column(children: [
                                Align(
                                    child: ClipRRect(
                                        borderRadius: BorderRadius.only(
                                            topLeft: Radius.circular(15),
                                            topRight: Radius.circular(15)),
                                        child: Image(
                                          image: Image.asset(
                                            "images/profile-1.jpg",
                                            width: 150,
                                            fit: BoxFit.cover,
                                          ).image,
                                        )),
                                    alignment: Alignment.centerLeft),
                                Padding(
                                    padding: EdgeInsets.all(2),
                                    child: Align(
                                        child: Text(
                                            widget.message.text!,
                                            style: TextStyle(fontSize: 15)),
                                        alignment: Alignment.centerLeft)),
                                Row(
                                  crossAxisAlignment: CrossAxisAlignment.end,
                                  children: [],
                                )
                              ])),
                        ),
                      );
   
  }
}