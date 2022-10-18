import 'package:bomapp/screens/gameDeail.dart';
import 'package:flutter/cupertino.dart';

import 'package:flutter/material.dart';

class ModelGrid {
  final String title;
  final String subtitle;
  final String ratings;
  final String logo_path;
  final String image_path;

  ModelGrid( this.title, this.subtitle, this.ratings, this.logo_path, this.image_path);
}


class CardGrid extends StatelessWidget {

  final String title;
  final String rating;
  final String logo;
  final Function onPress;

  CardGrid( this.title,this.rating, this.logo, this.onPress);
  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: GestureDetector(
        onTap: ()
        {
 Navigator.push(context, MaterialPageRoute(builder: (context){
          return GameDetail();
        }
           )
           );
   },
        child: Container(
         
          
          decoration: BoxDecoration(
            image: DecorationImage(image: Image.network(logo,height: 50,).image,

            fit: BoxFit.cover,),

            borderRadius: BorderRadius.all(Radius.circular(8)),

          ),
          child:
          Stack(
            children: [
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
                child: Text(title, style: TextStyle(color: Colors.white,fontSize: 30,fontWeight: FontWeight.bold),),
              ),
                Padding(
                      padding: const EdgeInsets.only(left: 4.0,bottom: 4.0),
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
                              Icon(Icons.star_outline,color: Colors.yellow,),
                              SizedBox(width: 10,),
                              Text(rating, style:       TextStyle(fontSize: 15,color: Colors.white),),
                            ],
                          )),
                    )),

           )],
          ),
            
            ]
          )
        ),
      ),
    );
  }
}
class GameList extends StatefulWidget {
  const GameList({ Key? key }) : super(key: key);

  @override
  State<GameList> createState() => _GameListState();
}

class _GameListState extends State<GameList> {
  List<ModelGrid> home_items =[
  ModelGrid("Jumanji Grand Theft Auto V 2", "When Spencer goes back          into the fantastical world of Jumanji, pals Martha, Fridge and ", "6.0", 
 'https://upload.wikimedia.org/wikipedia/fa/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg', 
 'https://upload.wikimedia.org/wikipedia/fa/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg'),
  ModelGrid("Jumanji 2", "When Spencer goes back          into the fantastical world of Jumanji, pals Martha, Fridge and ", "6.0", 
 'https://upload.wikimedia.org/wikipedia/fa/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg', 
 'https://upload.wikimedia.org/wikipedia/fa/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg'),
  ModelGrid("Jumanji 2", "When Spencer goes back          into the fantastical world of Jumanji, pals Martha, Fridge and ", "6.0", 
 'https://upload.wikimedia.org/wikipedia/fa/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg', 
 'https://upload.wikimedia.org/wikipedia/fa/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg'),
  ModelGrid("Jumanji 2", "When Spencer goes back          into the fantastical world of Jumanji, pals Martha, Fridge and ", "6.0", 
 'https://upload.wikimedia.org/wikipedia/fa/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg', 
 'https://upload.wikimedia.org/wikipedia/fa/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg'),
  ModelGrid("Jumanji 2", "When Spencer goes back          into the fantastical world of Jumanji, pals Martha, Fridge and ", "6.0", 
 'https://upload.wikimedia.org/wikipedia/fa/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg', 
 'https://upload.wikimedia.org/wikipedia/fa/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg'),
];
  @override
  Widget build(BuildContext context) {
     var size = MediaQuery.of(context).size;

    /*24 is for notification bar on Android*/
    final double itemHeight = (size.height - kToolbarHeight - 90) / 2;
    final double itemWidth = size.width / 2;

    return Scaffold(
      backgroundColor: Color.fromRGBO(38,37,44,1.0),
      appBar:  AppBar(
        centerTitle: false,
        title: appBarTitle,
        iconTheme: IconThemeData(color:Colors.white54),
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
                        icon: Icon(Icons.search_outlined,color: Colors.white54,),
                        
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
      body: Container(
        height: double.infinity,
        child: GridView.builder(gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
            crossAxisCount: 2,
          childAspectRatio: (itemWidth / itemHeight),),
            
            itemCount: home_items.length,
            itemBuilder: (BuildContext context,int index){
                 return CardGrid(
                
                      home_items[index].title,
                     home_items[index].ratings,
                     home_items[index].logo_path,    
                    (){
                        
                     },);
                   }
               ),
));
    
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
   bool _IsSearching=false;
}
