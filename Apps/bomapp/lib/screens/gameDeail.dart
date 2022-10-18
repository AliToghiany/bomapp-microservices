import 'package:flutter/material.dart';
class GameDetail extends StatelessWidget {
  const GameDetail({ Key? key }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    var size = MediaQuery.of(context).size;
  return MaterialApp(
      
      debugShowCheckedModeBanner: false,
      title: 'Flutter Demo',
      theme: ThemeData(
        primarySwatch: Colors.blue,
        visualDensity: VisualDensity.adaptivePlatformDensity,
      ),

      home: Scaffold(
        extendBodyBehindAppBar: true,
appBar: AppBar(
        title: Text('PUBG', style: TextStyle(
            color: Colors.white,
            fontSize: 22
        ),) ,
        elevation: 0,
        backgroundColor: Color.fromRGBO(0, 0, 0, 0.2),
        centerTitle: true,
       leading:  BackButton(
     color: Colors.white70
   ),  
        actions: <Widget>[
          IconButton(
            icon: Icon(
              Icons.more_vert,
              color: Colors.white70,
            ),
            onPressed: () {
             
            },
          ),
        ]
      ),

        bottomNavigationBar: Padding(
        padding: EdgeInsets.only(left: 25,right: 25,bottom: 25),
        child:Container(
                      decoration: BoxDecoration(
                          color: Colors.green,
                          borderRadius: BorderRadius.all(Radius.circular(10))),
                      child:
                       Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [ 
                          Icon(Icons.download,color: Colors.white,size: 30,),
                          Text(
                          "Download",
                          style: TextStyle(
                              color: Colors.white,
                              fontFamily: "Vazir",
                              fontSize: 18),
                        ),
                       ]) ,
                      width: MediaQuery.of(context).size.width - 50,
                      height: size.height*7/100,
                    )),
      backgroundColor: Color.fromRGBO(38,37,44,1.0),
      body:
       SingleChildScrollView(
        
        physics: AlwaysScrollableScrollPhysics(),

        child:
       Builder(

        builder:(context)=>
       
         Column(

          children: <Widget>[
            Stack(
        
        children: <Widget>[
          
          Container(
           child: Column(
            children: <Widget>[
            
                Container(
         height: size.height*75/100,
          
          decoration: BoxDecoration(
            image: DecorationImage(image: Image.network("https://cdn.zoomg.ir/2018/5/91ada99b-f276-480b-b2e2-7fb841a313a6.jpg",).image,

            fit: BoxFit.cover,),

            borderRadius: BorderRadius.all(Radius.circular(8)),

          ),
          child:
          Stack(
            children: [
Container(
          height: size.height*75/100,
          decoration: BoxDecoration(
            borderRadius: BorderRadius.all(Radius.circular(8)),
              color: Colors.white,
              gradient: LinearGradient(
                  begin: FractionalOffset.topCenter,
                  end: FractionalOffset.bottomCenter,
                  colors: [
                    Colors.grey.withOpacity(0.0),
                    
                    Color.fromRGBO(38,37,44,1.0),
                  ],
                  stops: [
                    0.0,
                    1.0
                  ])),
        ),
                
            

            ],
          ),
        ),
        ]),
          ),
      
      Padding(padding: EdgeInsets.only(left: 10,right: 10) ,child:  Column(
        children: [
        SizedBox(height: size.height*75/100-50,),
     Row(mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [  
        Container(
        
     
                  height: 40,
                  width: 40,
                  decoration: BoxDecoration(
                    color: Color.fromARGB(255, 88, 94, 147),
                    borderRadius: BorderRadius.all(Radius.circular(50)),
                  ),
                    child: Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: Center(
                          child: 
                              Icon(Icons.description,color: Colors.white,),
                             
                          
                    )),  
        ),
     Container(
        
     
                  height: 40,
                  width: 140,
                  decoration: BoxDecoration(
                    color: Color.fromARGB(255, 88, 94, 147),
                    borderRadius: BorderRadius.all(Radius.circular(20)),
                  ),
                    child: Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: Center(
                          child: Row(
                            
                            children: <Widget>[
                              Icon(Icons.play_arrow,color: Colors.white,),
                              SizedBox(width: 10,),
                              Text("Play Trailer", style:       TextStyle(fontSize: 15,color: Colors.white),),
                            ],
                          )),
                    )),
                     Container(
        
     
                  height: 40,
                  width: 40,
                  decoration: BoxDecoration(
                    color: Color.fromARGB(255, 88, 94, 147),
                    borderRadius: BorderRadius.all(Radius.circular(50)),
                  ),
                    child: Padding(
                      padding: const EdgeInsets.all(8.0),
                      child: Center(
                          child: 
                              Icon(Icons.comment,color: Colors.white,),
                             
                          
                    )),  
        ), 
                   
        ])])
         )]),

Padding(
  padding: EdgeInsets.only(top: 20,left: 20,right: 20),
  child: Container(
            padding: EdgeInsets.all(10),
            width: size.width,
           
           
            
        child: Column
        (

        
          children: [
           Row(
mainAxisAlignment: MainAxisAlignment.spaceBetween,

children: [
  Column(
  
    children: [
       Text("4M",style: TextStyle(color: Colors.white70,fontSize: 16),),
       SizedBox(height: 5,),
    RichText(
  text: TextSpan(
    style: TextStyle(color: Colors.white70,fontSize: 16),
    children: [
      TextSpan(
        text: " Downloads ",
      ),
      WidgetSpan(
        child: Icon(Icons.download, size: 14,color: Colors.white70,),
      ),
     
    ],
  ),
)
      
     
    ],
  ),Column(
  
    children: [
       Text("4.5",style: TextStyle(color: Colors.white70,fontSize: 16),),
       SizedBox(height: 5,),
    RichText(
  text: TextSpan(
    style: TextStyle(color: Colors.white70,fontSize: 16),
    children: [
      TextSpan(
        text: "  Rating ",
      ),
      WidgetSpan(
        child: Icon(Icons.star, size: 14,color: Colors.white70,),
      ),
     
    ],
  ),
)
      
     
    ],
  ),
  Column(
  
    children: [
       Text("327K",style: TextStyle(color: Colors.white70,fontSize: 16),),
       SizedBox(height: 5,),
    RichText(
  text: TextSpan(
    style: TextStyle(color: Colors.white70,fontSize: 16),
    children: [
      TextSpan(
        text: "  Community ",
      ),
      WidgetSpan(
        child: Icon(Icons.group, size: 14,color: Colors.white70,),
      ),
     
    ],
  ),
)
      
     
    ],
  ),
  
],
        ),
          
          
          ]),
),

         ),
        Padding(padding: EdgeInsets.only(top: 10,left: 25,right: 25),
        child: Column(children: [

        ],),
        )
         ]
)
)
)
)
);
  }
}