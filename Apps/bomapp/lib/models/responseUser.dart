
class ResponseUser {
  int? id;
  String? firstName;
  String? lastName;
  String? userName;
  String? phoneNumber;
  List<ImagesProfileResponses>? imagesProfileResponses;
  

  ResponseUser(
      {this.id,
      this.firstName,
      this.lastName,
      this.userName,
      this.phoneNumber,
      this.imagesProfileResponses,
      });

  ResponseUser.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    firstName = json['firstName'];
    lastName = json['lastName'];
    userName = json['userName'];
    phoneNumber = json['phoneNumber'];
    if (json['imagesProfileResponses'] != null) {
      imagesProfileResponses = <ImagesProfileResponses>[];
      json['imagesProfileResponses'].forEach((v) {
        imagesProfileResponses!.add(new ImagesProfileResponses.fromJson(v));
      });
    }
    
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['firstName'] = this.firstName;
    data['lastName'] = this.lastName;
    data['userName'] = this.userName;
    data['phone'] = this.phoneNumber;
    if (this.imagesProfileResponses != null) {
      data['imagesProfileResponses'] =
          this.imagesProfileResponses!.map((v) => v.toJson()).toList();
    }
    
    return data;
  }
}

class ImagesProfileResponses {
  String? name;
  String? path;

  ImagesProfileResponses({this.name, this.path});

  ImagesProfileResponses.fromJson(Map<String, dynamic> json) {
    name = json['name'];
    path = json['path'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['name'] = this.name;
    data['path'] = this.path;
    return data;
  }
}