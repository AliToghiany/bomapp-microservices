import 'package:bomapp/screens/gameDeail.dart';

import 'package:bomapp/screens/login.dart';
import 'package:bomapp/screens/welcomePage.dart';
import 'package:flutter/material.dart';
import 'package:bomapp/screens/homePage.dart';
import 'package:flutter/services.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_easyloading/flutter_easyloading.dart';
import 'package:flutter_local_notifications/flutter_local_notifications.dart';
import 'package:get/get.dart';
import 'package:workmanager/workmanager.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
   
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return GetMaterialApp(
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      debugShowCheckedModeBanner: false,
      home: HomePage(),
      builder: EasyLoading.init(),
    );
  }

  Widget firstPage() {
    return WellcomePage();
  }
}
