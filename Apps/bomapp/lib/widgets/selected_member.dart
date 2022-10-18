import 'package:flutter/material.dart';
class SelectedMember extends StatefulWidget {
  SelectedMember({ Key? key,required this.name,required this.imageUrl}) : super(key: key);
  String name;
  String imageUrl;

  @override
  State<SelectedMember> createState() => _SelectedMemberState();
}

class _SelectedMemberState extends State<SelectedMember> {
  @override
  Widget build(BuildContext context) {
    return CircleAvatar(
                    backgroundImage:Image.asset(widget.imageUrl).image,
                    child:  Align( alignment: Alignment.bottomRight, child:  Icon(Icons.remove_circle,color: Colors.green,)),
                    backgroundColor: Colors.red[400],
                    maxRadius: 27,
                  );
  }
}