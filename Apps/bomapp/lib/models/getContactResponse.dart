class GetContactResponse {
  List<Contact>? contact;

  GetContactResponse({this.contact});

  GetContactResponse.fromJson(Map<String, dynamic> json) {
    if (json['contact'] != null) {
      contact = <Contact>[];
      json['contact'].forEach((v) {
        contact!.add(new Contact.fromJson(v));
      });
    }
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    if (this.contact != null) {
      data['contact'] = this.contact!.map((v) => v.toJson()).toList();
    }
    return data;
  }
}

class Contact {
  int? id;
  String? firstName;
    String? lastName;
  String? userName;
  String? phone;
  List<ImagesProfileResponses>? imagesProfileResponses;

  Contact(
      {this.id,
      this.firstName,
      this.lastName,
      this.userName,
      this.phone,
      this.imagesProfileResponses});

  Contact.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    firstName = json['firstName'];
    lastName=json['lastName'];
    userName = json['userName'];
    phone = json['phone'];
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
    
    data['userName'] = this.userName;
    data['phone'] = this.phone;
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