import 'package:bomapp/entities/user.dart';
import 'package:floor/floor.dart';


@dao
abstract class UserDao {
   @Query('SELECT * FROM User WHERE id = :id')
  Future<User?> findUserById(int id);
  
   
  @Query('SELECT * FROM User')
  Future<List<User>> findAllUsers();

  @Query('SELECT * FROM User')
  Stream<List<User>> findAllUsersAsStream();

   @insert
  Future<void> insertUser(User user);

  @insert
  Future<void> insertUsers(List<User> Users);

  @update
  Future<void> updateUser(User User);

  @update
  Future<void> updateUsers(List<User> User);

  @delete
  Future<void> deleteUser(User User);

  @delete
  Future<void> deleteUsers(List<User> messages);

  }