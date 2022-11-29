
import 'package:bomapp/entities/user.dart';
import 'package:floor/floor.dart';

@Entity(
  tableName: 'contact',
  foreignKeys: [
    ForeignKey(
      childColumns: ['user_id'],
      parentColumns: ['id'],
      entity: User,
    )
  ],
)
@entity
class Contact {
  @PrimaryKey(autoGenerate: true)
   int? id;
  String? firstName;
  String? lastName;
  @ColumnInfo(name: 'user_id')
   int? userId;
  Contact();
  Contact.fill(this.userId,this.id,{ this.firstName, this.lastName});

}