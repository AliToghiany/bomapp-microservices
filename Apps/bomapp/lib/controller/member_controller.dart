import 'package:bomapp/models/userForList.dart';
import 'package:bomapp/widgets/selectUserList.dart';
import 'package:get/get.dart';
class MemberController extends GetxController{
  RxList<UserForList> users= [UserForList("","","")].obs;
  RxList selectedMember=[].obs;
  MemberController(){
    users.value=[];
  }
  void filterBySearch(String searchKey){

  }
}