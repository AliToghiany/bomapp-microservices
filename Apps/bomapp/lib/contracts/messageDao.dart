import 'package:floor/floor.dart';
import 'package:bomapp/entities/message.dart';

@dao
abstract class MessageDao {

  @Query('SELECT * FROM Message WHERE id = :id')
  Future<Message?> findMessageById(int id);

  @Query('SELECT * FROM Message')
  Future<List<Message>> findAllMessages();

  @Query('SELECT * FROM Message')
  Stream<List<Message>> findAllMessagesAsStream();

  @insert
  Future<void> insertMessage(Message message);

  @insert
  Future<void> insertMessages(List<Message> messages);

  @update
  Future<void> updateMessage(Message message);

  @update
  Future<void> updateMessages(List<Message> message);

  @delete
  Future<void> deleteMessage(Message message);

  @delete
  Future<void> deleteMessages(List<Message> messages);
}
