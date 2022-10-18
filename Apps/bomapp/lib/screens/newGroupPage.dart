import 'package:bomapp/models/userForList.dart';
import 'package:bomapp/widgets/selectUserList.dart';
import 'package:bomapp/widgets/selected_member.dart';
import 'package:flutter/material.dart';
import 'package:get/get.dart';
class AddingMember extends StatefulWidget {
  const AddingMember({ Key? key }) : super(key: key);

  @override
  State<AddingMember> createState() => _AddingMemberState();
}

class _AddingMemberState extends State<AddingMember> {
   List<UserForList> users = [
    UserForList("Jane Russel",  "online", "images/profile-1.jpg"),
     UserForList("Jane Russel",  "online", "images/profile-1.jpg"),
      UserForList("Jane Russel",  "online", "images/profile-1.jpg"),
       UserForList("Jane Russel",  "online", "images/profile-1.jpg"),
        UserForList("Jane Russel",  "online", "images/profile-1.jpg"),
         UserForList("Jane Russel",  "online", "images/profile-1.jpg"),
          UserForList("Jane Russel",  "online", "images/profile-1.jpg"),
           UserForList("Jane Russel",  "online", "images/profile-1.jpg"),
            UserForList("Jane Russel",  "online", "images/profile-1.jpg"),
   ];
  @override
  Widget build(BuildContext context) {
     return 
     Scaffold(
      backgroundColor: Color.fromRGBO(86, 96, 242, 1),
    appBar: AppBar(
        
        title: Text(
          "Conversations",
          style: TextStyle(color: Colors.white, fontFamily: "Vazir"),
        ),
        centerTitle: true,
    toolbarHeight: 90,
        backgroundColor: Colors.transparent,
        
        elevation: 0,
      
         
       
      ),
     
      body: Stack(
      
        alignment: Alignment.bottomCenter,

        children: [
          
        
      searchBar(),
      /*
       Column(
         children: [ 
          
SingleChildScrollView(
  physics: const BouncingScrollPhysics(),
                    scrollDirection: Axis.horizontal,

                    child:
                    Row(
                    
                      crossAxisAlignment: CrossAxisAlignment.start,
                      mainAxisAlignment: MainAxisAlignment.spaceBetween,
                      children: [
                        CircleAvatar(
                    backgroundImage:Image.asset("images/profile-1.jpg").image,
                    child:  Align( alignment: Alignment.bottomRight, child:  Icon(Icons.remove_circle,color: Colors.red,)),
                    backgroundColor: Colors.red[400],
                    maxRadius: 27,
                        ),CircleAvatar(
                    backgroundImage:Image.asset("images/profile-1.jpg").image,
                    child:  Align( alignment: Alignment.bottomRight, child:  Icon(Icons.remove_circle,color: Colors.red,)),
                    backgroundColor: Colors.red[400],
                    maxRadius: 27,
                        )
                    ],) ,

)
,
*/
Container(
   width: kFinalWitdth,
        height: kFinalHeight / 1.7,
        decoration: BoxDecoration(
          color: Colors.white,
          borderRadius: BorderRadius.only(
            topLeft: Radius.circular(30),
            topRight: Radius.circular(30),
          ),
        ),
  child: 
ListView.builder(
  itemCount: users.length,
  shrinkWrap: true,
  padding: EdgeInsets.only(top: 16),
  
  itemBuilder: (context, index){
    return SelectUserList(
      name: users[index].name,
      online: users[index].online,
      imageUrl: users[index].imageURL,
    
    );
  },
), )  ,  
   
])
      
     
     );
  
  }
  
Widget searchBar(){
  return  Container(
      width: kFinalWitdth,
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          

   Padding(
  padding: EdgeInsets.only(top: 16,left: 16,right: 16),
  child: TextField(
    decoration: InputDecoration(
      hintText: "Search...",
      hintStyle: TextStyle(color: Colors.grey.shade600),
      prefixIcon: Icon(Icons.search,color: Colors.grey.shade600, size: 20,),
       border: InputBorder.none,
      filled: true,
      fillColor: Colors.grey.shade100,
      contentPadding: EdgeInsets.all(8),
      enabledBorder: OutlineInputBorder(
          borderRadius: BorderRadius.circular(20),
          borderSide: BorderSide(
              color: Colors.grey.shade100
          )
      ),
    ),
  ),
),
ListView.builder(
  itemCount: users.length,
  shrinkWrap: true,
  padding: EdgeInsets.only(top: 16),
  scrollDirection: Axis.horizontal,
  itemBuilder: (context, index){
    return SelectedMember(
      name: users[index].name,
     
      imageUrl: users[index].imageURL,
    
    );
  },
)
]));
}
}
final kFinalWitdth = Get.width;
final kFinalHeight = Get.height;