import 'package:bomapp/controller/game_controller.dart';
import 'package:bomapp/models/ResponseGames.dart';
import 'package:bomapp/screens/gameDeail.dart';
import 'package:bomapp/services/gameService.dart';
import 'package:bomapp/widgets/shimmer_GameCard.dart';
import 'package:flutter/cupertino.dart';

import 'package:flutter/material.dart';
import 'package:get/get.dart';
import 'package:shimmer/shimmer.dart';

class CardGrid extends StatelessWidget {
  final String title;
  final String rating;
  final String logo;
  final VoidCallback onPress;

  CardGrid(this.title, this.rating, this.logo, this.onPress);
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: GestureDetector(
        onTap: this.onPress,
        child: Container(
            decoration: BoxDecoration(
              image: DecorationImage(
                image: Image.network(
                  logo,
                  height: 50,
                ).image,
                fit: BoxFit.cover,
              ),
              borderRadius: BorderRadius.all(Radius.circular(8)),
            ),
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
                      title,
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
                                rating,
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

class GameList extends StatefulWidget {
  const GameList({Key? key}) : super(key: key);

  @override
  State<GameList> createState() => _GameListState();
}

class _GameListState extends State<GameList> {
  final GameController gc = Get.put(GameController());

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    gc.FetchGames(0, "", null);
  }

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;

    /*24 is for notification bar on Android*/
    final double itemHeight = (size.height - kToolbarHeight - 90) / 2;
    final double itemWidth = size.width / 2;

    return Scaffold(
        backgroundColor: Color.fromRGBO(38, 37, 44, 1.0),
        appBar: AppBar(
            centerTitle: false,
            title: appBarTitle,
            iconTheme: IconThemeData(color: Colors.white54),
            backgroundColor: Colors.transparent,
            shape: RoundedRectangleBorder(
              borderRadius: BorderRadius.vertical(
                bottom: Radius.circular(30),
              ),
            ),
            elevation: 0,
            actions: <Widget>[
              IconButton(
                icon: actionIcon,
                onPressed: () {
                  setState(() {
                    if (this.actionIcon.icon == Icons.search) {
                      this.actionIcon = Icon(
                        Icons.close,
                        color: Colors.white54,
                      );
                      this.appBarTitle = TextField(
                        style: TextStyle(
                          color: Colors.white,
                        ),
                        decoration: InputDecoration(
                          border: InputBorder.none,
                          hintText: "Search here..",
                          hintStyle: TextStyle(color: Colors.white54),
                          icon: Icon(
                            Icons.search_outlined,
                            color: Colors.white54,
                          ),
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
        body: Obx(() => Container(
            height: double.infinity,
            child: (gc.gmaelist.length != 0)
                ? GridView.builder(
                    gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                      crossAxisCount: 2,
                      childAspectRatio: (itemWidth / itemHeight),
                    ),
                    itemCount: gc.gmaelist.length,
                    itemBuilder: (BuildContext context, int index) {
                      return CardGrid(
                        gc.gmaelist[index].name!,
                        gc.gmaelist[index].voet!.toString(),
                        gc.gmaelist[index].image!,
                        () {
                          Get.to(GameDetailPage(gc.gmaelist[index].id!));
                        },
                      );
                    })
                : Shimmer.fromColors(
                    child: GridView.builder(
                        gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                          crossAxisCount: 2,
                          childAspectRatio: (itemWidth / itemHeight),
                        ),
                        itemCount: 10,
                        itemBuilder: (BuildContext context, int index) {
                          return ShimmerCardGrid();
                        }),
                    baseColor: Colors.white54,
                    highlightColor: Colors.black26))));
  }

  void _handleSearchStart() {
    setState(() {
      _IsSearching = true;
    });
  }

  void _handleSearchEnd() {
    setState(() {
      this.actionIcon = Icon(
        Icons.search,
        color: Colors.white54,
      );
      this.appBarTitle = Text(
        "Games",
        style: TextStyle(color: Colors.white54),
      );
      _IsSearching = false;
    });
  }

  Widget appBarTitle = Text(
    "Games",
    style: TextStyle(color: Colors.white54),
  );
  Icon actionIcon = Icon(
    Icons.search,
    color: Colors.white54,
  );
  bool _IsSearching = false;
}
