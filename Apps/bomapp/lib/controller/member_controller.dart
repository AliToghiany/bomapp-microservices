import 'dart:js_util';

import 'package:bomapp/models/userForList.dart';
import 'package:bomapp/services/ResultDto.dart';
import 'package:bomapp/services/userService.dart';
import 'package:bomapp/widgets/selectUserList.dart';
import 'package:get/get.dart';


class MemberController extends GetxController {
  RxList<UserForList> users = <UserForList>[].obs;
  RxList selectedMember = [].obs;

  final UserService _userService = UserService();

  MemberController() {
    users.value = [];
  }
  void filterBySearch(String searchKey) {}
  Future setContact() async {
//List<Contact> contacts = await ContactsService.getContacts();
if(users.isBlank!){
    var res = await _userService.getContacts();
    if (res.isSuccess){ 
   
      for (var i in res.data!.contact!){
 String profile="undefined";
    if( !i.imagesProfileResponses.isBlank!){
profile=i.imagesProfileResponses!.first.path!;
    }
        users.add(UserForList(i.firstName!,i.lastName??" ", "on",
            profile));
      }
     
    }


    }
  }
  Future<ResultDto> newContact(String fname,String lname,String phone) async{
var res=await _userService.newContact(fname, lname, phone);
if(res.isSuccess){

}
return res;

  }
}

