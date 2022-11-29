
import 'package:floor/floor.dart';
@entity
class User {
  @PrimaryKey()
  final int id;
  
  String? firstName;
  String? lastName;
  String? userName;
  String? phone;
  User(this.id,{ this.firstName, this.lastName, this.userName, this.phone});
}