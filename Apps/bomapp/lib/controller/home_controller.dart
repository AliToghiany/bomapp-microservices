import 'package:bomapp/services/ApiSetting.dart';
import 'package:bomapp/services/userService.dart';

import 'package:get/get.dart';

class Homecontroller extends GetxController {
  final UserService _userService = UserService();

  var pictureProfile = "undifind".obs;
  var firstName = "user".obs;
  var lastName = "".obs;
  var phone = "".obs;
  var description = "".obs;
  var username = "".obs;
  var validuserName = "empty".obs;
  var validmessage = "".obs;
  void setInformation() async {
    var res = await _userService.getMyProfile();
//add to db
    if (res.isSuccess) {
      firstName.value = res.data!.firstName??" ";
      lastName.value = res.data!.lastName??" ";
      phone.value = res.data!.phoneNumber!;
      description.value = res.data!.description!;
      
      username.value = res.data!.userName ?? "non username";
      if (res.data!.imagesProfileResponses!.isNotEmpty) {
        pictureProfile.value = ApiSetting.AVATARURL +
            res.data!.imagesProfileResponses!.first.path!;
      }
    }
  }

 Future<bool> checkUserName(String userName) async {

    if(userName.isEmpty){
      validuserName.value="false";
      validmessage.value="Username not be empty";
      return true;
    }
    if(userName.length<4){
      validuserName.value="false";
      validmessage.value=" Username must be more than 4 characters";
      return true;
    }
    final alphanumeric = RegExp(r'^(?=.{4,32}$)(?!.*__)(?!^(bomapp|admin|support))[a-z][a-z0-9_]*[a-z0-9]$');
    if(!alphanumeric.hasMatch(userName) ){
      validuserName.value="false";
      validmessage.value="Do not enter illegal characters";
      return true;
    }
    validuserName.value="checking";
    validmessage.value="Checking Username ...";
    var res=await _userService.checkUserName(userName);
    if(res.isSuccess){
       validuserName.value=res.data!.checked==true?"true":"false";
       validmessage.value=res.data!.message!;
    }
return true;
     
  }
 Future<bool> updateAboutUser(String description) async{
  var res=await _userService.updateAboutUser(description);
  if(res.isSuccess){
  this.description.value=description;

  }
    return res.isSuccess;
  }
  
  
  Future<bool> updateUser(String userName,String firstName,String lastName) async{
var res=await _userService.updateUser(userName, firstName, lastName);
if(res.isSuccess){
  username.value=userName;
  this.firstName.value=firstName;
  this.lastName.value=lastName;
  
}
return res.isSuccess;
  }
  
}
