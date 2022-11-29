import 'package:bomapp/controller/home_controller.dart';
import 'package:bomapp/controller/member_controller.dart';
import 'package:bomapp/database/database.dart';
import 'package:bomapp/entities/user.dart';
import 'package:bomapp/screens/chatPage.dart';
import 'package:bomapp/screens/contactsPage.dart';
import 'package:bomapp/screens/settingProfile.dart';

import 'package:flutter/material.dart';

import 'package:ripple_navigation/ripple_navigation.dart';
import 'package:flutter_speed_dial/flutter_speed_dial.dart';
import 'package:get/get.dart';

import 'package:shrink_sidemenu/shrink_sidemenu.dart';
import 'newGroupPage.dart';

class HomePage extends StatefulWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  final Homecontroller _homecontroller = Get.put(Homecontroller());
  GlobalKey<RippleLocationState> rippleController = GlobalKey();
  @override
  void initState() {
    _homecontroller.setInformation();
    Get.put(MemberController());
    
    super.initState();
  }
  

  @override
  Widget build(BuildContext context) {
    final GlobalKey<SideMenuState> _sideMenuKey = GlobalKey<SideMenuState>();

    return SideMenu(
        key: _sideMenuKey,
        menu: buildMenu(),
        background: Color.fromARGB(255, 88, 94, 147),
        type: SideMenuType.slideNRotate, // check above images
        child: Scaffold(
          backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
          body: ChatPage(),
          bottomNavigationBar: BottomAppBar(
            color: Color.fromRGBO(31, 30, 36, 1.0),
            shape: CircularNotchedRectangle(),
            elevation: 5,
            notchMargin: 10.0,
            clipBehavior: Clip.antiAlias,
            child: Container(
              height: 60,
              child: Row(
                mainAxisAlignment: MainAxisAlignment.spaceBetween,
                children: <Widget>[
                  Container(
                    height: 50,
                    width: MediaQuery.of(context).size.width / 2 - 20,
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: <Widget>[
                        InkWell(
                          child: 
                            Obx(
                              () => _homecontroller.pictureProfile.value !=
                                      "undifind"
                                  ? CircleAvatar(
                                      backgroundImage: Image.network(
                                              _homecontroller
                                                  .pictureProfile.value)
                                          .image,
                                      backgroundColor: Colors.red[400],
                                      radius: 20,
                                    )
                                  : Container(
                                      height: 40,
                                      width: 40,
                                      decoration: BoxDecoration(
                                        color: Colors.orange,
                                        shape: BoxShape.circle,
                                      ),
                                      child: Center(
                                          child: Text(
                                        _homecontroller.firstName.value[0] +
                                            _homecontroller.lastName.value[0],
                                        style: TextStyle(
                                            fontSize: 15,
                                            fontWeight: FontWeight.bold),
                                      ))
                                      ),
                            ),
                           
                      
                          onTap: () {
                            final _state = _sideMenuKey.currentState;
                            if (_state!.isOpened)
                              _state.closeSideMenu(); // close side menu
                            else
                              _state.openSideMenu(); // open side menu
                          },
                        ),
                        Icon(
                          Icons.home,
                          color: Colors.white54,
                        )
                      ],
                    ),
                  ),
                  Container(
                    height: 50,
                    width: MediaQuery.of(context).size.width / 2 - 20,
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: <Widget>[
                        Icon(
                          Icons.search,
                          color: Colors.white54,
                        ),
                        Icon(
                          Icons.shopping_basket,
                          color: Colors.white54,
                        )
                      ],
                    ),
                  )
                ],
              ),
            ),
          ),
          floatingActionButton: SpeedDial(
            overlayColor: Color.fromRGBO(31, 30, 36, 1.0),
            backgroundColor: Color.fromARGB(255, 88, 94, 147),
            animatedIcon: AnimatedIcons.menu_close,
            children: [
              SpeedDialChild(
                backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
                foregroundColor: Colors.white54,
                labelBackgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
                labelStyle: TextStyle(color: Colors.white54),
                labelShadow: [BoxShadow(color: Colors.transparent)],
                child: Icon(Icons.group_add),
                label: "New Group",
                onTap: () {
                 Get.to(AddingMember());
                },
              ),
              SpeedDialChild(
                  backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
                  foregroundColor: Colors.white54,
                  labelBackgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
                  labelStyle: TextStyle(color: Colors.white54),
                  labelShadow: [BoxShadow(color: Colors.transparent)],
                  child: Icon(Icons.contact_page),
                  label: "Contacts",
                  onTap:() {
                    Get.to(ContactsPage());
                  }

                  ),
                  
            ],
          ),
          floatingActionButtonLocation:
              FloatingActionButtonLocation.centerDocked,
        ));
  }

  Widget buildMenu() {
    return SingleChildScrollView(
      padding: const EdgeInsets.symmetric(vertical: 50.0),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Padding(
            padding: const EdgeInsets.only(left: 16.0),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                GestureDetector(
                    onTap: () {
                      rippleController.currentState!.pushRippleTransitionPage(
                        context,
                        SettingPage(),
                      );
                    },
                    child: RippleLocation(
                        rippleController: rippleController,
                        child: CircleAvatar(
                          backgroundColor: Colors.white,
                          radius: 22.0,
                        ))),
                SizedBox(height: 16.0),
                Obx(() => Text(
                      "Hello, ${_homecontroller.firstName.value + " " + _homecontroller.lastName.value}",
                      style: TextStyle(color: Colors.white),
                    )),
                SizedBox(height: 20.0),
              ],
            ),
          ),
          ListTile(
            onTap: () {},
            leading: const Icon(Icons.home, size: 20.0, color: Colors.white),
            title: const Text("Home", style: TextStyle(color: Colors.white)),
            dense: true,
          ),
          ListTile(
            onTap: () {},
            leading: const Icon(Icons.verified_user,
                size: 20.0, color: Colors.white),
            title: const Text("Profile", style: TextStyle(color: Colors.white)),

            dense: true,

            // padding: EdgeInsets.zero,
          ),
          ListTile(
            onTap: () {},
            leading: const Icon(Icons.monetization_on,
                size: 20.0, color: Colors.white),
            title: const Text("Wallet", style: TextStyle(color: Colors.white)),

            dense: true,

            // padding: EdgeInsets.zero,
          ),
          ListTile(
            onTap: () {},
            leading: const Icon(Icons.shopping_cart,
                size: 20.0, color: Colors.white),
            title: const Text("Cart", style: TextStyle(color: Colors.white)),

            dense: true,

            // padding: EdgeInsets.zero,
          ),
          ListTile(
            onTap: () {},
            leading:
                const Icon(Icons.star_border, size: 20.0, color: Colors.white),
            title:
                const Text("Favorites", style: TextStyle(color: Colors.white)),

            dense: true,

            // padding: EdgeInsets.zero,
          ),
          ListTile(
            onTap: () {},
            leading:
                const Icon(Icons.settings, size: 20.0, color: Colors.white),
            title: const Text(
              "Settings",
              style: TextStyle(color: Colors.white),
            ),

            dense: true,

            // padding: EdgeInsets.zero,
          ),
        ],
      ),
    );
  }
}
