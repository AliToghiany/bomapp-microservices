import 'package:bomapp/models/userForList.dart';
import 'package:bomapp/widgets/selectUserList.dart';
import 'package:bomapp/widgets/selected_member.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';

class AddingMember extends StatefulWidget {
  const AddingMember({Key? key}) : super(key: key);

  @override
  State<AddingMember> createState() => _AddingMemberState();
}

class _AddingMemberState extends State<AddingMember> {
  List<UserForList> users = [
    UserForList("Jane Russel", "online", "images/profile-1.jpg"),
    UserForList("Jane Russel", "online", "images/profile-1.jpg"),
    UserForList("Jane Russel", "online", "images/profile-1.jpg"),
    UserForList("Jane Russel", "online", "images/profile-1.jpg"),
    UserForList("Jane Russel", "online", "images/profile-1.jpg"),
    UserForList("Jane Russel", "online", "images/profile-1.jpg"),
    UserForList("Jane Russel", "online", "images/profile-1.jpg"),
    UserForList("Jane Russel", "online", "images/profile-1.jpg"),
    UserForList("Jane Russel", "online", "images/profile-1.jpg"),
  ];
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
        debugShowCheckedModeBanner: false,
        home: Scaffold(
            backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
            extendBodyBehindAppBar: true,
            appBar: AppBar(
              title: Text(
                "New Group",
                style: TextStyle(color: Colors.white, fontFamily: "Vazir"),
              ),
              centerTitle: true,
              toolbarHeight: 90,
              backgroundColor: Colors.transparent,
              leading: BackButton(
                color: Colors.white70,
                onPressed: () {
                  Navigator.pop(context);
                },
              ),
              elevation: 0,
            ),
            body: Stack(children: [
              Stack(alignment: Alignment.bottomCenter, children: [
                Center(
                    child: Image.network(
                  'https://s6.uupload.ir/files/wall_new_blue_bgm1.png',
                  width: MediaQuery.of(context).size.width,
                  height: MediaQuery.of(context).size.height,
                  fit: BoxFit.fill,
                )),
                Padding(
                  padding: EdgeInsets.only(top: 300),
                  child: Container(
                    width: kFinalWitdth,
                    height: kFinalHeight / 1.7,
                    decoration: BoxDecoration(
                      color: Color.fromRGBO(38, 37, 44, 1.0),
                      borderRadius: BorderRadius.only(
                        topLeft: Radius.circular(30),
                        topRight: Radius.circular(30),
                      ),
                    ),
                    child: ListView.builder(
                      itemCount: users.length,
                      shrinkWrap: true,
                      padding: EdgeInsets.only(top: 16),
                      itemBuilder: (context, index) {
                        return SelectUserList(
                          name: users[index].name,
                          online: users[index].online,
                          imageUrl: users[index].imageURL,
                        );
                      },
                    ),
                  ),
                )
              ]),
              Padding(
                padding: EdgeInsets.only(top: 90),
                child: Align(
                  child: searchBar(),
                  alignment: Alignment.topCenter,
                ),
              ),
            ])));
  }

  Widget searchBar() {
    return Container(
        width: kFinalWitdth,
        height: 200,
        child: Padding(
            padding: EdgeInsets.only(top: 16, left: 16, right: 16),
            child: Column(children: [
              TextField(
                style: TextStyle(color: Colors.white),
                decoration: InputDecoration(
                  hintText: "Search...",
                  hintStyle: TextStyle(color: Colors.grey.shade600),
                  prefixIcon: Icon(
                    Icons.search,
                    color: Colors.grey.shade600,
                    size: 20,
                  ),
                  border: OutlineInputBorder(
                      borderRadius: BorderRadius.circular(20),
                      borderSide: BorderSide(color: Colors.grey.shade100)),
                  filled: true,
                  fillColor: Color.fromRGBO(38, 37, 44, 1.0),
                  contentPadding: EdgeInsets.all(8),
                ),
              ),
              Expanded(
                child: ListView.builder(
                    itemCount: SampleJSON.user.length,
                    scrollDirection: Axis.horizontal,
                    physics: BouncingScrollPhysics(),
                    itemBuilder: (context, index) {
                      return CircleAvatar(
                        backgroundColor: Colors.red[400],
                        maxRadius: 27,
                      );
                    }),
              )
            ])));
  }
}

final kFinalWitdth = Get.width;
final kFinalHeight = Get.height;

class SampleJSON {
  static const user = [
    {
      "id": 0,
      "name": "Add Status",
      "view": true,
      "image":
          "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
    },
    {
      "name": "Osamaasdasdasdasd",
      "view": false,
      "image":
          "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
    },
    {
      "name": "Angel",
      "view": false,
      "image":
          "https://www.rd.com/wp-content/uploads/2017/09/01-shutterstock_476340928-Irina-Bg-1024x683.jpg"
    },
    {
      "name": "Osama",
      "view": false,
      "image":
          "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
    },
    {
      "name": "Angel",
      "image":
          "https://www.rd.com/wp-content/uploads/2017/09/01-shutterstock_476340928-Irina-Bg-1024x683.jpg"
    },
    {
      "name": "Osama",
      "view": true,
      "image":
          "https://images.pexels.com/photos/220453/pexels-photo-220453.jpeg?auto=compress&cs=tinysrgb&dpr=1&w=500"
    },
    {
      "name": "Angel",
      "view": true,
      "image":
          "https://www.rd.com/wp-content/uploads/2017/09/01-shutterstock_476340928-Irina-Bg-1024x683.jpg"
    },
  ];
}
