

import 'package:flutter/material.dart';
import 'package:bomapp/models/chatMessageModel.dart';
class ChatDetail extends StatefulWidget {
  const ChatDetail({ Key? key}) : super(key: key);

  @override
  State<ChatDetail> createState() => _ChatDetailState();
}

class _ChatDetailState extends State<ChatDetail> {

 
  List<ChatMessage> messages = [
  
  ];
  @override
  Widget build(BuildContext context) {
   return Scaffold(
    
    backgroundColor: Colors.green[100],
      appBar: AppBar(
        elevation: 0,
        automaticallyImplyLeading: false,
        backgroundColor: Colors.white,
        toolbarHeight: 65,
        flexibleSpace: SafeArea(
          child: Container(
            padding: EdgeInsets.only(right: 16),
            child: Row(
              children: <Widget>[
                IconButton(
                  onPressed: (){
                    Navigator.pop(context);
                  },
                  icon: Icon(Icons.arrow_back,color: Colors.black,),
                ),
                SizedBox(width: 2,),
                CircleAvatar(
                  backgroundImage: NetworkImage("<https://randomuser.me/api/portraits/men/5.jpg>"),
                  maxRadius: 20,
                ),
                SizedBox(width: 12,),
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: <Widget>[
                      Text("Kriss Benwat",style: TextStyle( fontSize: 16 ,fontWeight: FontWeight.w600),),
                      SizedBox(height: 6,),
                      Text("Online",style: TextStyle(color: Colors.grey.shade600, fontSize: 13),),
                    ],
                  ),
                ),
                Icon(Icons.more_horiz,color: Colors.black54,),
              ],
            ),
          ),
        ),
      ),
      body:Container(
         decoration: BoxDecoration(
          image: DecorationImage(
            image: AssetImage("images/wallpaper_chat.jpg"),
            fit: BoxFit.cover,
          ),
        ),
        child:  Stack(
         
        children: <Widget>[
          Padding(padding: EdgeInsets.only(bottom: 60),
       child:    SingleChildScrollView(
           child:   ListView.builder(
            
  itemCount: messages.length,
  shrinkWrap: true,
  padding: EdgeInsets.only(top: 10,bottom: 10),
  physics: NeverScrollableScrollPhysics(),
  itemBuilder: (context, index){
    return Container(

      padding: EdgeInsets.only(left: 14,right: 14,top: 10,bottom: 10),
      
      child: Align(
        alignment: (messages[index].messageType == "receiver"?Alignment.topLeft:Alignment.topRight),
        child: Container(
          width: 150,
        
          decoration: BoxDecoration(
            borderRadius:(messages[index].messageType  == "receiver"? BorderRadius.only(bottomLeft: Radius.circular(0),bottomRight: Radius.circular(15), topLeft: Radius.circular(15),topRight: Radius.circular(15)):BorderRadius.only(bottomLeft: Radius.circular(15), topLeft: Radius.circular(15),topRight: Radius.circular(15))),
            color: (messages[index].messageType  == "receiver"?Colors.grey.shade200:Colors.blue[200]),
            
          ),
          padding: EdgeInsets.all(2),
          child:Column(
          
            children: [ 
             Align(
              child: ClipRRect(
    borderRadius: BorderRadius.only(topLeft: Radius.circular(15),topRight: Radius.circular(15))
     ,child:  Image( image: Image.asset("images/profile-1.jpg").image,)) ,alignment: Alignment.centerLeft),
                Padding(padding: EdgeInsets.all(2),child:  Align(child: Text(messages[index].messageContent, style: TextStyle(fontSize: 15)),alignment: Alignment.centerLeft)),
        Row(
          crossAxisAlignment: CrossAxisAlignment.end,
          children: [

          ],
        )
        ]

        )),
      ),
    );
  },
          ))),
          Align(
            alignment: Alignment.bottomLeft,
            child: Container(
              padding: EdgeInsets.only(left: 5,bottom: 10,top: 10),
              height: 60,
              width: double.infinity,
              color: Colors.white,
              child: Row(
           
                children: <Widget>[
                  GestureDetector(
                    onTap: (){
                    },
                    child: Container(
                      height: 30,
                      width: 30,
                      decoration: BoxDecoration(
                        color: Colors.white,
                        borderRadius: BorderRadius.circular(30),
                      ),
                      child:Padding(child:  Icon(Icons.gif, color: Colors.black, size: 35, ),padding: EdgeInsets.only(bottom: 9),),
                    ),
                  ),
                  SizedBox(width: 15,),
                  Expanded(
                    child: TextField(
                        style: TextStyle(fontSize: 15),
                      decoration: InputDecoration(
                        hintText: "Write message...",
                        
                        hintStyle: TextStyle(color: Colors.black54),
                        border: InputBorder.none
                    
                      ),
                    ),
                  ),
                  SizedBox(width: 15,),
                  FloatingActionButton(
                    onPressed: (){},
                    child: Icon(Icons.file_present,color: Colors.black,size: 25,),
                    backgroundColor: Colors.white,
                    elevation: 0,
                    heroTag: "btn1",
                  ),
                  
                  FloatingActionButton(
                    onPressed: (){},
                    child: Icon(Icons.send,color: Colors.black,size: 25,),
                    backgroundColor: Colors.white,
                    elevation: 0,
                    heroTag: "btn2",
                    
                  ),
                ],
                
              ),
            ),
          ),
       
        ],
   ),));
  }
}

