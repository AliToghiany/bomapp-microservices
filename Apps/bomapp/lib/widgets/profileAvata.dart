import 'package:flutter/material.dart';

class ProfileViewer extends StatelessWidget {
  ProfileViewer(
      this.name, this.lname, this.pathimg, this.r, this.fontsize, this.onPress,
      {Key? key})
      : super(key: key);
  String name;
  String lname;
  String pathimg;
  double r;
  double fontsize;
  final VoidCallback onPress;

  @override
  Widget build(BuildContext context) {
  
    return GestureDetector(
        onTap: onPress,
        child: pathimg != "undefined"
            ? CircleAvatar(
                backgroundImage: Image.network(pathimg).image,
                radius: r,
              )
            : Container(
                height: r * 2,
                width: r * 2,
                decoration: BoxDecoration(
                  color: Colors.orange,
                  shape: BoxShape.circle,
                ),
                child: Center(
                    child: Text(
                  name[0] + (lname.isNotEmpty?lname[0]:""),
                  style: TextStyle(
                      fontSize: fontsize, fontWeight: FontWeight.bold),
                ))));
  }
}
