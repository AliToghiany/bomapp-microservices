import 'package:bomapp/controller/home_controller.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class ChangeDesPage extends StatelessWidget {
  ChangeDesPage({Key? key}) : super(key: key);
  final Homecontroller _homecontroller = Get.find();
  final aboutController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    aboutController.text = _homecontroller.description.value;

    return Scaffold(
      backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
      appBar: AppBar(
        title: Text(
          "Change About",
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
              child: TextField(
                maxLength: 100,
                minLines: 1,
                maxLines: 5,
                keyboardType: TextInputType.multiline,
                style: TextStyle(color: Colors.white),
                cursorColor: Color.fromARGB(255, 88, 94, 147),
                decoration: InputDecoration(
                  counterStyle:
                      TextStyle(color: Color.fromARGB(255, 88, 94, 147)),
                  focusedBorder: UnderlineInputBorder(
                    borderSide: BorderSide(
                        color: Color.fromARGB(255, 88, 94, 147), width: 2.0),
                  ),
                  labelText: 'About',
                  labelStyle:
                      TextStyle(color: Color.fromARGB(255, 88, 94, 147)),
                  hintText: 'Write something about yourself!',
                  hintStyle: TextStyle(color: Colors.grey[600]),
                ),
                controller: aboutController,
              ),
            ),
          ])),
      floatingActionButton: FloatingActionButton(
        onPressed: () async {
          var res = await _homecontroller.updateAboutUser(aboutController.text);

          if (res) {
            Get.back();
          }
        },
        backgroundColor: Color.fromARGB(255, 88, 94, 147),
        child: const Icon(Icons.check),
      ),
    );
  }
}
