import 'package:bomapp/controller/home_controller.dart';
import 'package:bomapp/screens/changeDescription.dart';
import 'package:bomapp/screens/changeName.dart';

import 'package:flutter/material.dart';
import 'package:flutter_image_slideshow/flutter_image_slideshow.dart';
import 'package:get/get.dart';


class SettingPage extends StatefulWidget {
  const SettingPage({Key? key}) : super(key: key);

  @override
  State<SettingPage> createState() => _SettingPageState();
}

class _SettingPageState extends State<SettingPage> {
  final Homecontroller _homecontroller = Get.find();
  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
    Dialog errorDialog = Dialog(
      elevation: 0,
    backgroundColor: Colors.transparent,
        shape: RoundedRectangleBorder(
          
            borderRadius: BorderRadius.circular(12.0)),
             //this right here
        child: ImageSlideshow(

          /// Width of the [ImageSlideshow].
          width: 300,

          /// Height of the [ImageSlideshow].
          height: 350,

          /// The page to show when first creating the [ImageSlideshow].
          initialPage: 0,

          /// The color to paint the indicator.
          indicatorColor: Color.fromARGB(255, 88, 94, 147),

          /// The color to paint behind th indicator.
          indicatorBackgroundColor: Colors.grey,

          /// The widgets to display in the [ImageSlideshow].
          /// Add the sample image file into the images folder
          children: [
            Image.asset(
              'images/profile-8.jpg',
              fit: BoxFit.cover,
               
              height: 300,
            ),
            Image.asset(
              'images/profile-8.jpg',
              fit: BoxFit.cover,
              
              height: 300,
            ),
            Image.asset(
              'images/profile-8.jpg',
              fit: BoxFit.cover,
               
              height: 300,
            ),
          ],

          /// Called whenever the page in the center of the viewport changes.
          onPageChanged: (value) {
            print('Page changed: $value');
          },

          /// Auto scroll interval.
          /// Do not auto scroll with null or 0.
          autoPlayInterval: 0,

          /// Loops back to first slide.
          isLoop: false,
        ),
      );
      
       
      
       
    return Scaffold(
        extendBodyBehindAppBar: true,
        backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
        appBar: AppBar(
          centerTitle: false,
          toolbarHeight: 60,
          backgroundColor: Colors.transparent,
          elevation: 0,
          leading: BackButton(color: Colors.white70),
          actions: <Widget>[
            IconButton(
              icon: Icon(
                Icons.more_vert,
                color: Colors.white54,
              ),
              onPressed: () {},
            )
          ],
        ),
        body: SingleChildScrollView(
            physics: AlwaysScrollableScrollPhysics(),
            child: Column(children: [
              Stack(children: [
                Container(
                  height: 200,
                  width: size.width,
                  decoration: BoxDecoration(
                    image: DecorationImage(
                      image: Image.network(
                        "https://s3.amazonaws.com/thumbnails.venngage.com/template/10d4dd8e-178e-44c0-b848-e7189399231a.png",
                      ).image,
                      fit: BoxFit.cover,
                    ),
                  ),
                ),
                Padding(
                    padding: EdgeInsets.only(top: 150, left: 20),
                    child: Obx(
                      () => GestureDetector(
                        onTap: () {
                          showDialog(
                              context: context,
                              builder: (BuildContext context) => errorDialog);
                        },
                        child: _homecontroller.pictureProfile.value !=
                                "undifind"
                            ? CircleAvatar(
                                backgroundImage: Image.network(
                                        _homecontroller.pictureProfile.value)
                                    .image,
                                backgroundColor: Colors.red[400],
                                maxRadius: 50,
                                child: Align(
                                    alignment: Alignment.bottomRight,
                                    child: Container(
                                      width: 30.0,
                                      height: 30.0,
                                      decoration: BoxDecoration(
                                        color: Color.fromARGB(255, 88, 94, 147),
                                        shape: BoxShape.circle,
                                      ),
                                      child: Icon(Icons.photo_camera),
                                    )),
                              )
                            : Container(
                                width: 100.0,
                                height: 100.0,
                                decoration: BoxDecoration(
                                  color: Colors.orange,
                                  shape: BoxShape.circle,
                                ),
                                child: Stack(children: [
                                  Center(
                                      child: Text(
                                    _homecontroller.firstName.value[0] +
                                        _homecontroller.lastName.value[0],
                                    style: TextStyle(
                                        fontSize: 26,
                                        fontWeight: FontWeight.bold),
                                  )),
                                  Align(
                                      alignment: Alignment.bottomRight,
                                      child: Container(
                                        width: 30.0,
                                        height: 30.0,
                                        decoration: BoxDecoration(
                                          color:
                                              Color.fromARGB(255, 88, 94, 147),
                                          shape: BoxShape.circle,
                                        ),
                                        child: IconButton(
                                            onPressed: () {},
                                            icon: Icon(
                                              Icons.photo_camera,
                                              size: 15,
                                            )),
                                      ))
                                ])),
                      ),

                      // Text(widget.time,style: TextStyle(fontSize: 12,fontWeight: widget.isMessageRead?FontWeight.bold:FontWeight.normal),),
                    ))
              ]),
              SizedBox(
                width: 20,
              ),
              Padding(
                padding: EdgeInsets.only(left: 10, top: 20),
                child: Align(
                    alignment: Alignment.topLeft,
                    child: Row(children: [
                      Container(
                        color: Colors.transparent,
                        child: Column(
                          crossAxisAlignment: CrossAxisAlignment.start,
                          children: <Widget>[
                            Obx(() => Text(
                                  _homecontroller.firstName.value +
                                      " " +
                                      _homecontroller.lastName.value,
                                  style: TextStyle(
                                      fontSize: 22,
                                      color: Colors.white,
                                      fontWeight: FontWeight.bold),
                                )),
                            SizedBox(
                              height: 6,
                            ),
                            Obx(() => Text(
                                  _homecontroller.username.value,
                                  style: TextStyle(
                                      fontSize: 13,
                                      color: Colors.grey.shade600),
                                )),
                          ],
                        ),
                      ),
                      SizedBox(
                        width: 10,
                      ),
                      IconButton(
                        onPressed: () {
                          Get.to(ChangeNamePage());
                        },
                        icon: Icon(
                          Icons.edit,
                          size: 15,
                          color: Colors.grey[700],
                        ),
                        iconSize: 15.0,
                      ),
                    ])),
              ),
              SizedBox(
                height: 10,
              ),
              getLine(),
              Obx(() => getInformationButton(
                  "Phone", _homecontroller.phone.value, () {})),
              getLine(),
              Obx(() => getInformationButton(
                      "About", _homecontroller.description.value, () {
                    Get.to(ChangeDesPage());
                  })),
              getHLine()
            ])));
  }

  Widget getLine() {
    return Padding(
      padding: EdgeInsets.only(left: 10, right: 10),
      child: Container(
        color: Colors.grey[850],
        height: 1,
      ),
    );
  }

  Widget getHLine() {
    return Container(
      color: Colors.black12,
      height: 20,
    );
  }

  Widget getInformationButton(String title, String des, VoidCallback onPress) {
    return InkWell(
      child: Padding(
        padding: EdgeInsets.only(left: 10, top: 10, bottom: 10),
        child: Column(children: [
          Align(
            alignment: Alignment.topLeft,
            child: Text(
              title,
              style: TextStyle(
                fontSize: 19,
                color: Colors.grey[350],
              ),
            ),
          ),
          SizedBox(
            height: 5,
          ),
          Align(
              alignment: Alignment.topLeft,
              child: Padding(
                padding: EdgeInsets.only(left: 10),
                child: Text(
                  des,
                  style: TextStyle(color: Colors.grey[700], fontSize: 14),
                ),
              )),
        ]),
      ),
      onTap: onPress,
    );
  }
}
