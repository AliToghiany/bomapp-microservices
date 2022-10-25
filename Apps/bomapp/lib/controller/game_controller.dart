import 'package:bomapp/models/ResponseGames.dart';
import 'package:bomapp/models/gameDetail.dart';
import 'package:bomapp/services/gameService.dart';
import 'package:flutter/cupertino.dart';
import 'package:get/get.dart';
import 'package:get/get_connect/http/src/utils/utils.dart';

class GameController extends GetxController {
  GameService gameService = GameService();
  RxList<Games> gmaelist = <Games>[].obs;
  var selectedGame=GameDetail(name: "",categoryName: "",categoryId: 0,decription: "",images: [],price: 0,voet: 0).obs;
  var name="String".obs;
  var page = 1;
  void FetchGames(int ordring, String searchkey, int? catid) async {
    gmaelist.addAll(
        (await gameService.GetGames(ordring, searchkey, catid, page))
            .data!
            .games!);
  }
void FetchDetailGame(int gameId) async{
var res=await gameService.GetGame(gameId);
print(res.data!.name);
selectedGame.update((val) {
  val!.name=res.data!.name;
  val.images=res.data!.images;
  val.categoryId=res.data!.categoryId;
  val.categoryName=res.data!.categoryName;
  val.decription=res.data!.decription;
  val.price=res.data!.price;
  val.voet=res.data!.voet;
  
  
});
name.value=res.data!.name!;

}
}
/*class RxGameDetail extends GetxController{
  var name=RxString;
  List<String>? images;
  int? price;
  String? categoryName;
  int? categoryId;
  int? voet;
  String? decription;


  RxGameDetail(
      {this.name,
      this.images,
      this.price,
      this.categoryName,
      this.categoryId,
      this.voet,
      this.decription});

}*/
