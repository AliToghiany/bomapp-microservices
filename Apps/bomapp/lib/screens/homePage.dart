import 'package:bomapp/screens/GameListPage.dart';
import 'package:bomapp/screens/chatPage.dart';
import 'package:bomapp/screens/gameDeail.dart';

import 'package:flutter/material.dart';
import 'package:bomapp/widgets/NavBar.dart';
import 'package:flutter/services.dart';
import 'package:flutter_speed_dial/flutter_speed_dial.dart';
import 'newGroupPage.dart';
class HomePage extends StatelessWidget {
  const HomePage({ Key? key }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    
    return Scaffold( 
      backgroundColor: Color.fromRGBO(38,37,44,1.0),
      body: GameDetail(),
        bottomNavigationBar: NavBar(),
          floatingActionButton: SpeedDial(
          
            overlayColor: Color.fromRGBO(31,30,36,1.0),
            
            backgroundColor: Color.fromARGB(255, 88, 94, 147),
            animatedIcon: AnimatedIcons.menu_close,
            children:[
SpeedDialChild(
  backgroundColor: Color.fromRGBO(38,37,44,1.0),
  foregroundColor: Colors.white54,
  labelBackgroundColor:Color.fromRGBO(38,37,44,1.0),
  labelStyle: TextStyle(color: Colors.white54),
  labelShadow: [BoxShadow(color: Colors.transparent)],
  child: Icon(Icons.group_add),
  label: "New Group",
  onTap: () {
     Navigator.push(context, MaterialPageRoute(builder: (context){
        return AddingMember();
  }));
      
  },
),
SpeedDialChild(
  backgroundColor: Color.fromRGBO(38,37,44,1.0),
  foregroundColor: Colors.white54,
  labelBackgroundColor:Color.fromRGBO(38,37,44,1.0),
  labelStyle: TextStyle(color: Colors.white54),
  labelShadow: [BoxShadow(color: Colors.transparent)],
  child: Icon(Icons.contact_page),
  label: "New Contact"
 
)
            ] ,
            ),
      floatingActionButtonLocation: FloatingActionButtonLocation.centerDocked,
    );
  }
}