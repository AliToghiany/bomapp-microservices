import 'package:bomapp/controller/home_controller.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class ChangeNamePage extends StatelessWidget {
  ChangeNamePage({Key? key}) : super(key: key);
  final Homecontroller _homecontroller = Get.find();
   final userNameController = TextEditingController();
   final firstNameController = TextEditingController();
    final lastNameController = TextEditingController();
  @override
  Widget build(BuildContext context) {
   
    userNameController.text = _homecontroller.username.value == "non username"
        ? ""
        : _homecontroller.username.value;
    
    firstNameController.text = _homecontroller.firstName.value;
   
    lastNameController.text = _homecontroller.lastName.value;
    return Scaffold(
      backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
      appBar: AppBar(
        title: Text(
          "Change Names",
          style: TextStyle(
            color: Colors.white70,
          ),
        ),
        centerTitle: true,
        toolbarHeight: 70,
        leading: BackButton(color: Colors.white70),
        backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
        elevation: 0,
      ),
      body: Padding(
          padding: EdgeInsets.all(15),
          child: Column(children: <Widget>[
            Padding(
                padding: EdgeInsets.all(15),
                child:  Obx(()=>inputUsername(_homecontroller.validuserName.value,_homecontroller.validmessage.value))
                ),
            Text(
              "Username must be at least more than 4 characters long and enter characters like '+'. , | ! \" £ \$ % & / ( ) = ? ^ * ç ° § ; : _ > ] [ @ ); is not allowed\n" +
                  "When registering UserName, you can only use English letters (a to z), numbers (0 to 9).",
              style: TextStyle(color: Colors.white38),
            ),
            Padding(
              padding: EdgeInsets.all(15),
              child: TextField(
             
                style: TextStyle(color: Colors.white),
                cursorColor: Color.fromARGB(255, 88, 94, 147),
                decoration: InputDecoration(
                  focusedBorder: OutlineInputBorder(
                    borderSide: BorderSide(
                        color: Color.fromARGB(255, 88, 94, 147), width: 2.0),
                  ),
                  labelText: 'First Name',
                  labelStyle:
                      TextStyle(color: Color.fromARGB(255, 88, 94, 147)),
                  hintText: 'Enter Your FirstName',
                  hintStyle: TextStyle(color: Colors.grey[600]),
                ),
                controller: firstNameController,
              ),
            ),
            Padding(
              padding: EdgeInsets.all(15),
              child: TextField(
                
                style: TextStyle(color: Colors.white),
                cursorColor: Color.fromARGB(255, 88, 94, 147),
                decoration: InputDecoration(
                  focusedBorder: OutlineInputBorder(
                    borderSide: BorderSide(
                        color: Color.fromARGB(255, 88, 94, 147), width: 2.0),
                  ),
                  labelText: 'Last Name',
                  labelStyle:
                      TextStyle(color: Color.fromARGB(255, 88, 94, 147)),
                  hintText: 'Enter Your LastName',
                  hintStyle: TextStyle(color: Colors.grey[600]),
                ),
                controller: lastNameController,
              ),
            ),
          ])),
      floatingActionButton: FloatingActionButton(
        onPressed: () async {
          var res=await _homecontroller.updateUser(userNameController.text, firstNameController.text, lastNameController.text);
          
          if (res){
          Get.back();
          }
        },
        backgroundColor: Color.fromARGB(255, 88, 94, 147),
        child: const Icon(Icons.check),
      ),
    );
  }
  Widget inputUsername(String validuserName,String validmessage){
    Color se=Color.fromARGB(255, 88, 94, 147);
    String er="";
    if(validuserName=="true"){
    se=Colors.green;
    er="You can choose this Username";

    }
     if(validuserName=="false"){
    se=Colors.red;
    er=validmessage;
    }
     if(validuserName=="checking"){
    se=Colors.blue[900]!;
    er=validmessage;
    }
    
    
    return TextField(
                   
                    style: TextStyle(color: Colors.white),
                    cursorColor: Color.fromARGB(255, 88, 94, 147),
                    onChanged: (value) async{
                      await _homecontroller.checkUserName(value);
                    },
                    decoration: InputDecoration(
                      errorText: er,
                              errorStyle: TextStyle(color: se),
                              focusedErrorBorder:OutlineInputBorder(
                        borderSide: BorderSide(
                            color:se,
                            width: 2.0),
                      ), 
                      
                      prefixText: "@ ",
                     
                  errorBorder:    UnderlineInputBorder(      
                      borderSide: BorderSide(color: se),   
                      ),  
                      labelText: 'User Name',
                      labelStyle:
                          TextStyle(color: Color.fromARGB(255, 88, 94, 147)),
                      hintText: 'Enter Your UserName',
                      hintStyle: TextStyle(color: Colors.grey[600]),
                    ),
                    controller: userNameController,
                  );
  }
}
