import 'package:bomapp/services/ResultDto.dart';
import 'package:get/get.dart';
import 'dart:convert';
import 'ApiSetting.dart';

class AuthService extends GetConnect {
//String confirmId;
  Future<ResultDto<String>> SendConfirmCode(String phone) async {
    var res = await post(ApiSetting.URL + "/Auth/SendCode", {"phone": phone});
    if (res.isOk) {
      return ResultDto<String>(res.statusCode, res.statusText, true,
          data: res.body["code"]);
    } else {
      return ResultDto<String>(res.statusCode, res.statusText, false);
    }
  }
  // Post request

  Future<ResultDto<SignUserResponse>> ConfirmCode(
      String id, String Code) async {
    var res = await post(
        ApiSetting.URL + "/Auth/ConfirmCode", {"id": id, "Code": Code});
    if (res.isOk) {
      final Map parsed = res.body;
      var suresponse = SignUserResponse.fromJson(parsed);

      return ResultDto<SignUserResponse>(res.statusCode, res.statusText, true,
          data: suresponse);
    } else {
      return ResultDto<SignUserResponse>(res.statusCode, res.statusText, false);
    }
  }
  // Post request

}

class SignUserResponse {
  int? userId;
  bool? isNew;
  String? token;

  SignUserResponse();
  SignUserResponse.fromJson(Map<dynamic, dynamic> json) {
    userId = json['userId'];
    isNew = json['isNew'];
    token = json['token'];
  }
}
