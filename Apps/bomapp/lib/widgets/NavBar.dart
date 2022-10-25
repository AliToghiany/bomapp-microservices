import 'package:flutter/material.dart';

class NavBar extends StatelessWidget {
  const NavBar({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return BottomAppBar(
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
                  Icon(
                    Icons.home,
                    color: Colors.white54,
                  ),
                  Icon(
                    Icons.person_outline,
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
    );
    //
  }
}
