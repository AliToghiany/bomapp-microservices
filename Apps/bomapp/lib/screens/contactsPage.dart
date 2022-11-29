import 'package:bomapp/controller/member_controller.dart';
import 'package:bomapp/models/userForList.dart';
import 'package:bomapp/widgets/profileAvata.dart';
import 'package:bomapp/widgets/userlist.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:get/get.dart';
import 'package:lottie/lottie.dart';
import 'package:top_snackbar_flutter/custom_snack_bar.dart';
import 'package:top_snackbar_flutter/top_snack_bar.dart';

class ContactsPage extends StatefulWidget {
  const ContactsPage({Key? key}) : super(key: key);

  @override
  State<ContactsPage> createState() => _ContactsPageState();
}

class _ContactsPageState extends State<ContactsPage> {
  final memberController = Get.find<MemberController>();
  final newOrEditContact=Get.put(NewOrEditContact());
  final phoneController = TextEditingController();
  @override
  void initState() {
    super.initState();
    memberController.setContact();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
      appBar: AppBar(
          centerTitle: false,
          title: appBarTitle,
          iconTheme: IconThemeData(color: Colors.white54),
          backgroundColor: Color.fromRGBO(31, 30, 36, 1.0),
          elevation: 0,
          actions: <Widget>[
            IconButton(
              icon: actionIcon,
              onPressed: () {
                setState(() {
                  if (actionIcon.icon == Icons.search) {
                    actionIcon = Icon(
                      Icons.close,
                      color: Colors.white54,
                    );
                    appBarTitle = TextField(
                      style: TextStyle(
                        color: Colors.white,
                      ),
                      decoration: InputDecoration(
                        border: InputBorder.none,
                        hintText: "Search here..",
                        hintStyle: TextStyle(color: Colors.white54),
                      ),
                    );
                    _handleSearchStart();
                  } else {
                    _handleSearchEnd();
                  }
                });
              },
            ),
          ]),
      body: Obx(() => ListView.builder(
            itemCount: memberController.users.length,
            shrinkWrap: true,
            
            itemBuilder: (context, index) {
              return UserList(
                name: memberController.users[index].name,
                lname: memberController.users[index].lname,
                online: "online",
                imageUrl: memberController.users[index].imageURL,
              );
            },
          )),
      floatingActionButton: FloatingActionButton(
        onPressed: () async {
          showDialog(
              context: context,
              builder: (BuildContext context) => Dialog(
      elevation: 0,
      backgroundColor: Colors.transparent, //Color.fromRGBO(38, 37, 44, 1.0),
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(12.0)),
      //this right here
      child: Center(
          child: Stack(children: [
        Align(
          alignment: Alignment.topCenter,
          child: Container(
            margin: EdgeInsets.only(top: 48),
            width: 400,
            height: 300,
            decoration: BoxDecoration(
              color: Color.fromRGBO(38, 37, 44, 1.0),
              borderRadius: BorderRadius.circular(16.0),
            ),
            child: Padding(
              padding: EdgeInsets.only(right: 20, left: 20, top: 80,bottom: 20),
              child: Column(mainAxisAlignment: MainAxisAlignment.start,
                children: [
TextField(
            onChanged: (value) {
               if (value.isEmpty){
                   value=" ";
                  }
                newOrEditContact.changedName(value);
            },
                style: TextStyle(color: Colors.white),
                cursorColor: Color.fromARGB(255, 88, 94, 147),
                decoration: InputDecoration(
                  focusedBorder: UnderlineInputBorder(
                    borderSide: BorderSide(
                        color: Color.fromARGB(255, 88, 94, 147), width: 2.0),
                  ),
                  labelText: 'First Name',
                  labelStyle:
                      TextStyle(color: Color.fromARGB(255, 88, 94, 147),fontSize: 14),
                  hintText: 'Enter FirstName',
                  hintStyle: TextStyle(color: Colors.grey[600]),
                ),
                controller: firstNameController,
              ),
            
            TextField(
                onChanged: (value) {
                  if (value.isEmpty){
                   value=" ";
                  }
                newOrEditContact.changeLName(value);
                },
                style: TextStyle(color: Colors.white),
                cursorColor: Color.fromARGB(255, 88, 94, 147),
                decoration: InputDecoration(
                  focusedBorder: UnderlineInputBorder(
                    borderSide: BorderSide(
                        color: Color.fromARGB(255, 88, 94, 147), width: 2.0),
                  ),
                  labelText: 'Last Name',
                  labelStyle:
                      TextStyle(color: Color.fromARGB(255, 88, 94, 147),fontSize: 14),
                  hintText: 'Enter LastName',
                  hintStyle: TextStyle(color: Colors.grey[600]),
                ),
                controller: lastNameController,
              ),
              TextField(
                inputFormatters: <TextInputFormatter>[
                  FilteringTextInputFormatter.allow(RegExp(r'[0-9]')),
                ],
                
                keyboardType: TextInputType.number,
                style: TextStyle(color: Colors.white),
                cursorColor: Color.fromARGB(255, 88, 94, 147),
                
                decoration: InputDecoration(
                  focusedBorder: UnderlineInputBorder(
                    borderSide: BorderSide(
                        color: Color.fromARGB(255, 88, 94, 147), width: 2.0),
                  ),
                  labelText: 'Phone',
                
                  labelStyle:
                      TextStyle(color: Color.fromARGB(255, 88, 94, 147),fontSize: 14),
                  hintText: 'Enter Phone',
                  hintStyle: TextStyle(color: Colors.grey[600]),
                ),
                controller: phoneController,
              ),
              SizedBox(height: 15,),
            Row(

              mainAxisAlignment: MainAxisAlignment.spaceAround,
             
             children: [ InkWell(
                onTap: () {
                  Navigator.of(context, rootNavigator: true).pop();
                },
                
                child: Container(
                  width: 50,
                  height: 30,
                  child:Center(child: Text("Cancle",style: TextStyle(color: Color.fromARGB(255, 88, 94, 147)),),) ,
                ),
              ),
             InkWell(
                onTap: () async{
             var res=  await memberController.newContact(firstNameController.text,lastNameController.text,phoneController.text);
if(res.isSuccess){
  showTopSnackBar(
   Overlay.of( context)!,
    CustomSnackBar.success(
      message:
          "Good,Contact added successfully",
    ),
);
}
if(res.statusCode==400||res.statusCode==404){
 showTopSnackBar(
   Overlay.of( context)!,
    CustomSnackBar.error(
      message:
          res.content!,
    ),
);
}

                },
                
                child: Container(
                  width: 30,
                  height: 30,
                  child:Center(child: Text("Save",style: TextStyle(color: Color.fromARGB(255, 88, 94, 147)),),) ,
                ),
              ),
            ], 
            )
                ],
              ),
            ),
          ),
        ),
        Align(
          alignment: Alignment.topCenter,
          child: SizedBox(
              child: 
           Obx(()=>  ProfileViewer(newOrEditContact.fname.value,newOrEditContact.lname.value,"undefined",60,20,(){}))
              
        ))  ]))));
  
        },
        backgroundColor: Color.fromARGB(255, 88, 94, 147),
        child: const Icon(Icons.add),
      ),
    );
  }

  void _handleSearchStart() {
    setState(() {
      _IsSearching = true;
    });
  }

  void _handleSearchEnd() {
    setState(() {
      actionIcon = Icon(
        Icons.search,
        color: Colors.white54,
      );
      appBarTitle = Text(
        "Contacts",
        style: TextStyle(color: Colors.white54),
      );
      _IsSearching = false;
    });
  }

  Widget appBarTitle = Text(
    "Contacs",
    style: TextStyle(color: Colors.white54),
  );
  Icon actionIcon = Icon(
    Icons.search,
    color: Colors.white54,
  );
  bool _IsSearching = false;
final firstNameController = TextEditingController();
final lastNameController = TextEditingController();
  
}
class NewOrEditContact extends RxController{
var fname=" ".obs;
var lname=" ".obs;
void changedName(String name){
  fname.value=name;
}
void changeLName(String name){
  lname.value=name;
}
}
