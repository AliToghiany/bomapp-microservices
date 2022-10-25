import 'package:bomapp/screens/homePage.dart';
import 'package:bomapp/services/authService.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter/services.dart';
import 'package:pin_code_fields/pin_code_fields.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  State<LoginPage> createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  var autoService = AuthService();
  var phoneController = TextEditingController();
  var codeController = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
      appBar: AppBar(
        title: Text(
          "Login",
          style: TextStyle(color: Colors.white, fontFamily: "Vazir"),
        ),
        centerTitle: true,
        toolbarHeight: 70,
        backgroundColor: Color.fromRGBO(33, 32, 38, 0.9),
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.vertical(
            bottom: Radius.circular(30),
          ),
        ),
        elevation: 0,
      ),
      body: Padding(
          padding: EdgeInsets.all(15),
          child: Column(children: <Widget>[
            Padding(
              padding: EdgeInsets.all(15),
              child: TextField(
                inputFormatters: <TextInputFormatter>[
                  FilteringTextInputFormatter.allow(RegExp(r'[0-9]')),
                ],
                keyboardType: TextInputType.number,
                style: TextStyle(color: Colors.white),
                cursorColor: Color.fromARGB(255, 88, 94, 147),
                
                decoration: InputDecoration(
                  focusedBorder: OutlineInputBorder(
                    borderSide: BorderSide(
                        color: Color.fromARGB(255, 88, 94, 147), width: 2.0),
                  ),
                  labelText: 'Phone',
                  labelStyle:
                      TextStyle(color: Color.fromARGB(255, 88, 94, 147)),
                  hintText: 'Enter Your Phone',
                  hintStyle: TextStyle(color: Colors.grey[600]),
                ),
                controller: phoneController,
              ),
            ),
            Text(
              "Please select your country and then enter your number",
              style: TextStyle(color: Colors.white38),
            )
          ])),
      floatingActionButton: FloatingActionButton(
        onPressed: () async {
          var res = await autoService.SendConfirmCode(phoneController.text);

          if (res.isSuccess) {
            showModalBottomSheet<void>(
                context: context,
                builder: (BuildContext context) {
                  return Container(
                      height: 200,
                      color: Color.fromRGBO(38, 37, 44, 1.0),
                      child: Padding(
                        padding: EdgeInsets.only(right: 70, left: 70, top: 10),
                        child: Column(
                          mainAxisAlignment: MainAxisAlignment.start,
                          mainAxisSize: MainAxisSize.min,
                          children: <Widget>[
                            Text(
                              "Please enter the code that was sent to you ",
                              style: TextStyle(color: Colors.white38),
                            ),
                            SizedBox(
                              height: 20,
                            ),
                            PinCodeTextField(
                              appContext: context,
                              length: 6,
                              obscureText: false,
                              animationType: AnimationType.fade,
                              textStyle: TextStyle(color: Colors.white),
                              pinTheme: PinTheme(
                                shape: PinCodeFieldShape.box,
                                borderRadius: BorderRadius.circular(5),
                                fieldHeight: 40,
                                fieldWidth: 40,
                                inactiveFillColor:
                                    Color.fromRGBO(38, 37, 44, 1.0),
                                inactiveColor: Color.fromARGB(255, 88, 94, 147),
                                selectedColor: Color.fromARGB(255, 88, 94, 147),
                                activeFillColor: Colors.transparent,
                                selectedFillColor: Colors.transparent,
                                activeColor: Color.fromARGB(255, 88, 94, 147),
                              ),
                              animationDuration: Duration(milliseconds: 300),
                              backgroundColor: Colors.transparent,
                              enableActiveFill: true,
                              controller: codeController,
                              keyboardType: TextInputType.number,
                              inputFormatters: <TextInputFormatter>[
                                FilteringTextInputFormatter.allow(
                                    RegExp(r'[0-9]')),
                              ],
                              onCompleted: (v) {},
                              onChanged: (value) {
                                print(value);
                                setState(() {});
                              },
                              beforeTextPaste: (text) {
                                print("Allowing to paste $text");
                                //if you return true then it will show the paste confirmation dialog. Otherwise if false, then nothing will happen.
                                //but you can show anything you want here, like your pop up saying wrong paste format or etc
                                return true;
                              },
                            ),
                            TextButton(
                                onPressed: () async {
                                  var resConfirm =
                                      await autoService.ConfirmCode(
                                          res.data!, codeController.text);
                                  if (resConfirm.isSuccess) {
                                    Navigator.push(context,
                                        MaterialPageRoute(builder: (context) {
                                      return HomePage();
                                    }));
                                  }
                                },
                                child: Center(
                                    child: Text(
                                  "Next",
                                  style: TextStyle(color: Colors.white),
                                )),
                                style: ButtonStyle(
                                    backgroundColor: MaterialStateColor
                                        .resolveWith((states) =>
                                            Color.fromARGB(255, 88, 94, 147)),
                                    minimumSize: MaterialStateProperty.all(Size(
                                        MediaQuery.of(context).size.width,
                                        55))))
                          ],
                        ),
                      ));
                });
          }
        },
        backgroundColor: Color.fromARGB(255, 88, 94, 147),
        child: const Icon(Icons.arrow_forward),
      ),
    );
  }
}
