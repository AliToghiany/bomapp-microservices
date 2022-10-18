import 'package:bomapp/screens/gameDeail.dart';

import 'package:bomapp/screens/login.dart';
import 'package:bomapp/screens/welcomePage.dart';
import 'package:flutter/material.dart';
import 'package:bomapp/screens/homePage.dart';
import 'package:flutter/services.dart';
import 'package:flutter/widgets.dart';


void main() {
 
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
   
    return MaterialApp(
   
      title: 'Flutter Demo',
      theme: ThemeData(
    
        primarySwatch: Colors.blue,
      ),
      debugShowCheckedModeBanner: false,
      home: GameDetail(),
    );
  }
  Widget firstPage(){

 return WellcomePage();
  
  }
}
