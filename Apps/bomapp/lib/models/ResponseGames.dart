class ListGames {
  List<Games>? games;
  int? row;

  ListGames({this.games, this.row});

  ListGames.fromJson(Map<String, dynamic> json) {
    if (json['games'] != null) {
      games = <Games>[];
      json['games'].forEach((v) {
        games!.add(new Games.fromJson(v));
      });
    }
    row = json['row'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    if (this.games != null) {
      data['games'] = this.games!.map((v) => v.toJson()).toList();
    }
    data['row'] = this.row;
    return data;
  }
}

class Games {
  String? name;
  String? image;
  int? price;
  String? categoryName;
  int? categoryId;
  int? voet;

  Games(
      {this.name,
      this.image,
      this.price,
      this.categoryName,
      this.categoryId,
      this.voet});

  Games.fromJson(Map<String, dynamic> json) {
    name = json['name'];
    image = json['image'];
    price = json['price'];
    categoryName = json['categoryName'];
    categoryId = json['categoryId'];
    voet = json['voet'];
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['name'] = this.name;
    data['image'] = this.image;
    data['price'] = this.price;
    data['categoryName'] = this.categoryName;
    data['categoryId'] = this.categoryId;
    data['voet'] = this.voet;
    return data;
  }
}
