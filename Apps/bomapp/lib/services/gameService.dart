import 'package:bomapp/models/ResponseGames.dart';
import 'package:bomapp/models/gameDetail.dart';
import 'package:bomapp/services/ResultDto.dart';
import 'package:flutter/cupertino.dart';
import 'package:get/get.dart';
import 'package:http/http.dart';
import 'dart:convert';
import 'ApiSetting.dart';

class GameService {
  Future<ResultDto<ListGames?>> GetGames(
      int ordring, String? searchkey, int? catid, int page) async {
    String param = "";
    if (catid != null) param += "&catid=${catid}";
    if (!(searchkey == null || searchkey == ""))
      param += "&searchkey=${searchkey}";

    var res = await get(Uri.parse(ApiSetting.URL +
        "/Game/GetGames?ordering=${ordring}&pagesize=20&page=${page}" +
        param));
    if (res.statusCode == 200) {
      return ResultDto<ListGames?>(200, "", true,
          data: ListGames.fromJson(json.decode(res.body)));
    } else {
      return ResultDto(res.statusCode, "", true);
    }
  }

  Future<ResultDto<GameDetail>> GetGame(int id) async {
    var res = await get(Uri.parse(ApiSetting.URL + "/Game/${id}"));
    if (res.statusCode == 200) {
      print(res.body+"dssd");
      return ResultDto<GameDetail>(200, "sucsses", true,
          data: GameDetail.fromJson(json.decode(res.body)));
    } else {
      return ResultDto(res.statusCode, res.body, false);
    }
  }
}
