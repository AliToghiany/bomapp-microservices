import 'package:bomapp/models/getContactResponse.dart';
import 'package:bomapp/models/profileResponse.dart';
import 'package:bomapp/models/responseCheckUser.dart';
import 'package:bomapp/models/responseUser.dart';
import 'package:bomapp/services/ResultDto.dart';
import 'package:bomapp/utils/tokentUtil.dart';
import 'package:http/http.dart';
import 'dart:convert';
import 'ApiSetting.dart';

class UserService {
  Future<ResultDto<GetContactResponse>> getContacts() async {
    var res = await get(Uri.parse(ApiSetting.URL + "/Contact/GetContacts"), headers: {"Authorization": TokenUtilities.GetToken()!});
    print(res.statusCode);
    if (res.statusCode == 200) {
      return ResultDto(200, "", true,
          data: GetContactResponse.fromJson(json.decode(res.body)));
    } else {
      return ResultDto(res.statusCode, res.body, false);
    }
  }

  Future<ResultDto<ProfileResponse>> getMyProfile() async {
    var res = await get(Uri.parse(ApiSetting.URL + "/User/GetMyProfile"),
        headers: {"Authorization": TokenUtilities.GetToken()!});

    if (res.statusCode == 200) {
      return ResultDto(200, "", true,
          data: ProfileResponse.fromJson(json.decode(res.body)));
    } else {
      return ResultDto(res.statusCode, res.body, false);
    }
  }

  Future<ResultDto<ResponseCheckUser>> checkUserName(String username) async {
    var res = await get(
        Uri.parse(ApiSetting.URL + "/User/CheckUserName/${username}"),
        headers: {"Authorization": TokenUtilities.GetToken()!});

    if (res.statusCode == 200) {
      return ResultDto(200, "", true,
          data: ResponseCheckUser.fromJson(json.decode(res.body)));
    } else {
      return ResultDto(res.statusCode, res.body, false);
    }
  }

  Future<ResultDto<ResponseCheckUser>> updateUser(
      String username, String firstname, String lastname) async {
    var body = jsonEncode(
        {"username": username, "firstname": firstname, "lastname": lastname});
    Map<String, String> header = ApiSetting.contenttype;
    header.addAll({"Authorization": TokenUtilities.GetToken()!});
    var res = await post(Uri.parse(ApiSetting.URL + "/User/UpdateUser"),
        body: body, headers: header);
    

    if (res.statusCode == 200) {
      return ResultDto(
        200,
        "",
        true,
      );
    } else {
      return ResultDto(res.statusCode, res.body, false);
    }
  }
  Future<ResultDto<ResponseCheckUser>> updateAboutUser(String description) async {
    var body = jsonEncode(
        description);
    Map<String, String> header = ApiSetting.contenttype;
    header.addAll({"Authorization": TokenUtilities.GetToken()!});
    var res = await post(Uri.parse(ApiSetting.URL + "/User/UpdateAboutUser"),
        body: body, headers: header);
   

    if (res.statusCode == 200) {
      return ResultDto(
        200,
        "",
        true,
      );
    } else {
      return ResultDto(res.statusCode, res.body, false);
    }
  }
  Future<ResultDto<ResponseUser>> newContact(String fname,String lname,String phone) async{
    var body = jsonEncode(
        {"phone": phone, "firstname": fname, "lastname": lname});
      Map<String, String> header = ApiSetting.contenttype;
    header.addAll({"Authorization": TokenUtilities.GetToken()!});  
    var res = await post(Uri.parse(ApiSetting.URL + "/Contact/NewContact"),
        body: body, headers: header);
        if (res.statusCode == 200) {
      return ResultDto<ResponseUser>(
        200,
        "",
        true,
        data: ResponseUser.fromJson(json.decode(res.body))
      );
    } else {
      return ResultDto<ResponseUser>(res.statusCode, res.body, false);
    }
  }
}
