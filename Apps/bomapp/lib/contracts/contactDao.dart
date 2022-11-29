
import 'package:bomapp/entities/contact.dart';
import 'package:floor/floor.dart';


@dao
abstract class ContactDao {

  @insert
  Future<void> insertContact(Contact contact);
    @Query('SELECT * FROM Contact WHERE id = :id')
  Future<Contact?> findContactById(int id);

  @Query('SELECT * FROM Contact')
  Future<List<Contact>> findAllContacts();

  @Query('SELECT * FROM Contact')
  Stream<List<Contact>> findAllContactsAsStream();
  @insert
  Future<void> insertContacts(List<Contact> Contacts);

  @update
  Future<void> updateContact(Contact Contact);

  @update
  Future<void> updateContacts(List<Contact> Contact);

  @delete
  Future<void> deleteContact(Contact Contact);

  @delete
  Future<void> deleteContacts(List<Contact> Contacts);
  }