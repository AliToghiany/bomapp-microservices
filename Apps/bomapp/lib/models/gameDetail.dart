class GameDetail  {
  String? name;
  List<String>? images;
  int? price;
  String? categoryName;
  int? categoryId;
  int? voet;
  String? decription;


  GameDetail(
      {this.name,
      this.images,
      this.price,
      this.categoryName,
      this.categoryId,
      this.voet,
      this.decription});
      
  GameDetail.fromJson(Map<String, dynamic> json) {
    name = json['name'];
    images = json['images'].cast<String>();
    price = json['price'];
    categoryName = json['categoryName'];
    categoryId = json['categoryId'];
    voet = json['voet'];
    decription = json['decription'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['name'] = this.name;
    data['images'] = this.images;
    data['price'] = this.price;
    data['categoryName'] = this.categoryName;
    data['categoryId'] = this.categoryId;
    data['voet'] = this.voet;
    data['decription'] = this.decription;
    return data;
  }
}
