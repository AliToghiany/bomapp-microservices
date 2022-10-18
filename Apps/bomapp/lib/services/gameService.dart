import 'package:bomapp/models/ResponseGames.dart';
import 'package:bomapp/services/ResultDto.dart';
import 'package:get/get.dart';
import 'dart:convert';
import 'ApiSetting.dart';
class GameService extends GetConnect{
Future<ResultDto <ListGames?>> GetGames(int page) async {
var res=await get(ApiSetting.URL+"Game/GetGames");
if(res.isOk)
 return ResultDto<ListGames?>(ListGames.fromJson(res.body),200,res.statusText,true); 
else
 return ResultDto<ListGames?>(null,res.statusCode, res.statusText, true);
}
}