class ResponseCheckUser {
  bool? checked;
  String? message;

  ResponseCheckUser({this.checked, this.message});

  ResponseCheckUser.fromJson(Map<String, dynamic> json) {
    checked = json['checked'];
    message = json['message'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['checked'] = checked;
    data['message'] = message;
    return data;
  }
}