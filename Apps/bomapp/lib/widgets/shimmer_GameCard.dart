import 'package:flutter/material.dart';

class ShimmerCardGrid extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: GestureDetector(
        child: Container(
            height: 50,
            child: Stack(children: [
              Container(
                height: 350.0,
                decoration: BoxDecoration(
                    borderRadius: BorderRadius.all(Radius.circular(8)),
                    color: Colors.white,
                    gradient: LinearGradient(
                        begin: FractionalOffset.topCenter,
                        end: FractionalOffset.bottomCenter,
                        colors: [
                          Colors.grey.withOpacity(0.0),
                          Colors.black,
                        ],
                        stops: [
                          0.0,
                          1.0
                        ])),
              ),
              Column(
                mainAxisAlignment: MainAxisAlignment.start,
                crossAxisAlignment: CrossAxisAlignment.start,
                children: <Widget>[
                  Expanded(child: SizedBox()),
                  Padding(
                    padding: const EdgeInsets.only(left: 4.0),
                    child: Text(
                      "",
                      style: TextStyle(
                          color: Colors.white,
                          fontSize: 30,
                          fontWeight: FontWeight.bold),
                    ),
                  ),
                  Padding(
                    padding: const EdgeInsets.only(left: 4.0, bottom: 4.0),
                    child: Container(
                        height: 40,
                        width: 80,
                        decoration: BoxDecoration(
                          color: Color.fromARGB(255, 88, 94, 147),
                          borderRadius: BorderRadius.all(Radius.circular(20)),
                        ),
                        child: Padding(
                          padding: const EdgeInsets.all(8.0),
                          child: Center(
                              child: Row(
                            children: <Widget>[
                              Icon(
                                Icons.star_outline,
                                color: Colors.yellow,
                              ),
                              SizedBox(
                                width: 10,
                              ),
                              Text(
                                "",
                                style: TextStyle(
                                    fontSize: 15, color: Colors.white),
                              ),
                            ],
                          )),
                        )),
                  )
                ],
              ),
            ])),
      ),
    );
  }
}
