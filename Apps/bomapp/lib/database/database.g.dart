// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'database.dart';

// **************************************************************************
// FloorGenerator
// **************************************************************************

// ignore: avoid_classes_with_only_static_members
class $FloorAppDatabase {
  /// Creates a database builder for a persistent database.
  /// Once a database is built, you should keep a reference to it and re-use it.
  static _$AppDatabaseBuilder databaseBuilder(String name) =>
      _$AppDatabaseBuilder(name);

  /// Creates a database builder for an in memory database.
  /// Information stored in an in memory database disappears when the process is killed.
  /// Once a database is built, you should keep a reference to it and re-use it.
  static _$AppDatabaseBuilder inMemoryDatabaseBuilder() =>
      _$AppDatabaseBuilder(null);
}

class _$AppDatabaseBuilder {
  _$AppDatabaseBuilder(this.name);

  final String? name;

  final List<Migration> _migrations = [];

  Callback? _callback;

  /// Adds migrations to the builder.
  _$AppDatabaseBuilder addMigrations(List<Migration> migrations) {
    _migrations.addAll(migrations);
    return this;
  }

  /// Adds a database [Callback] to the builder.
  _$AppDatabaseBuilder addCallback(Callback callback) {
    _callback = callback;
    return this;
  }

  /// Creates the database and initializes it.
  Future<AppDatabase> build() async {
    final path = name != null
        ? await sqfliteDatabaseFactory.getDatabasePath(name!)
        : ':memory:';
    final database = _$AppDatabase();
    database.database = await database.open(
      path,
      _migrations,
      _callback,
    );
    return database;
  }
}

class _$AppDatabase extends AppDatabase {
  _$AppDatabase([StreamController<String>? listener]) {
    changeListener = listener ?? StreamController<String>.broadcast();
  }

  MessageDao? _messageDaoInstance;

  UserDao? _userDaoInstance;

  ContactDao? _contactDaoInstance;

  Future<sqflite.Database> open(String path, List<Migration> migrations,
      [Callback? callback]) async {
    final databaseOptions = sqflite.OpenDatabaseOptions(
      version: 1,
      onConfigure: (database) async {
        await database.execute('PRAGMA foreign_keys = ON');
        await callback?.onConfigure?.call(database);
      },
      onOpen: (database) async {
        await callback?.onOpen?.call(database);
      },
      onUpgrade: (database, startVersion, endVersion) async {
        await MigrationAdapter.runMigrations(
            database, startVersion, endVersion, migrations);

        await callback?.onUpgrade?.call(database, startVersion, endVersion);
      },
      onCreate: (database, version) async {
        await database.execute(
            'CREATE TABLE IF NOT EXISTS `Message` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `orginalId` INTEGER, `messageId` TEXT, `userId` INTEGER, `groupId` INTEGER, `privateId` INTEGER, `replyMessageId` INTEGER, `text` TEXT, `stickerId` INTEGER, `gifId` INTEGER)');
        await database.execute(
            'CREATE TABLE IF NOT EXISTS `User` (`id` INTEGER NOT NULL, `firstName` TEXT, `lastName` TEXT, `userName` TEXT, `phone` TEXT, PRIMARY KEY (`id`))');
        await database.execute(
            'CREATE TABLE IF NOT EXISTS `contact` (`id` INTEGER PRIMARY KEY AUTOINCREMENT, `firstName` TEXT, `lastName` TEXT, `user_id` INTEGER, FOREIGN KEY (`user_id`) REFERENCES `User` (`id`) ON UPDATE NO ACTION ON DELETE NO ACTION)');

        await callback?.onCreate?.call(database, version);
      },
    );
    return sqfliteDatabaseFactory.openDatabase(path, options: databaseOptions);
  }

  @override
  MessageDao get messageDao {
    return _messageDaoInstance ??= _$MessageDao(database, changeListener);
  }

  @override
  UserDao get userDao {
    return _userDaoInstance ??= _$UserDao(database, changeListener);
  }

  @override
  ContactDao get contactDao {
    return _contactDaoInstance ??= _$ContactDao(database, changeListener);
  }
}

class _$MessageDao extends MessageDao {
  _$MessageDao(this.database, this.changeListener)
      : _queryAdapter = QueryAdapter(database, changeListener),
        _messageInsertionAdapter = InsertionAdapter(
            database,
            'Message',
            (Message item) => <String, Object?>{
                  'id': item.id,
                  'orginalId': item.orginalId,
                  'messageId': item.messageId,
                  'userId': item.userId,
                  'groupId': item.groupId,
                  'privateId': item.privateId,
                  'replyMessageId': item.replyMessageId,
                  'text': item.text,
                  'stickerId': item.stickerId,
                  'gifId': item.gifId
                },
            changeListener),
        _messageUpdateAdapter = UpdateAdapter(
            database,
            'Message',
            ['id'],
            (Message item) => <String, Object?>{
                  'id': item.id,
                  'orginalId': item.orginalId,
                  'messageId': item.messageId,
                  'userId': item.userId,
                  'groupId': item.groupId,
                  'privateId': item.privateId,
                  'replyMessageId': item.replyMessageId,
                  'text': item.text,
                  'stickerId': item.stickerId,
                  'gifId': item.gifId
                },
            changeListener),
        _messageDeletionAdapter = DeletionAdapter(
            database,
            'Message',
            ['id'],
            (Message item) => <String, Object?>{
                  'id': item.id,
                  'orginalId': item.orginalId,
                  'messageId': item.messageId,
                  'userId': item.userId,
                  'groupId': item.groupId,
                  'privateId': item.privateId,
                  'replyMessageId': item.replyMessageId,
                  'text': item.text,
                  'stickerId': item.stickerId,
                  'gifId': item.gifId
                },
            changeListener);

  final sqflite.DatabaseExecutor database;

  final StreamController<String> changeListener;

  final QueryAdapter _queryAdapter;

  final InsertionAdapter<Message> _messageInsertionAdapter;

  final UpdateAdapter<Message> _messageUpdateAdapter;

  final DeletionAdapter<Message> _messageDeletionAdapter;

  @override
  Future<Message?> findMessageById(int id) async {
    return _queryAdapter.query('SELECT * FROM Message WHERE id = ?1',
        mapper: (Map<String, Object?> row) => Message(), arguments: [id]);
  }

  @override
  Future<List<Message>> findAllMessages() async {
    return _queryAdapter.queryList('SELECT * FROM Message',
        mapper: (Map<String, Object?> row) => Message());
  }

  @override
  Stream<List<Message>> findAllMessagesAsStream() {
    return _queryAdapter.queryListStream('SELECT * FROM Message',
        mapper: (Map<String, Object?> row) => Message(),
        queryableName: 'Message',
        isView: false);
  }

  @override
  Future<void> insertMessage(Message message) async {
    await _messageInsertionAdapter.insert(message, OnConflictStrategy.abort);
  }

  @override
  Future<void> insertMessages(List<Message> messages) async {
    await _messageInsertionAdapter.insertList(
        messages, OnConflictStrategy.abort);
  }

  @override
  Future<void> updateMessage(Message message) async {
    await _messageUpdateAdapter.update(message, OnConflictStrategy.abort);
  }

  @override
  Future<void> updateMessages(List<Message> message) async {
    await _messageUpdateAdapter.updateList(message, OnConflictStrategy.abort);
  }

  @override
  Future<void> deleteMessage(Message message) async {
    await _messageDeletionAdapter.delete(message);
  }

  @override
  Future<void> deleteMessages(List<Message> messages) async {
    await _messageDeletionAdapter.deleteList(messages);
  }
}

class _$UserDao extends UserDao {
  _$UserDao(this.database, this.changeListener)
      : _queryAdapter = QueryAdapter(database, changeListener),
        _userInsertionAdapter = InsertionAdapter(
            database,
            'User',
            (User item) => <String, Object?>{
                  'id': item.id,
                  'firstName': item.firstName,
                  'lastName': item.lastName,
                  'userName': item.userName,
                  'phone': item.phone
                },
            changeListener),
        _userUpdateAdapter = UpdateAdapter(
            database,
            'User',
            ['id'],
            (User item) => <String, Object?>{
                  'id': item.id,
                  'firstName': item.firstName,
                  'lastName': item.lastName,
                  'userName': item.userName,
                  'phone': item.phone
                },
            changeListener),
        _userDeletionAdapter = DeletionAdapter(
            database,
            'User',
            ['id'],
            (User item) => <String, Object?>{
                  'id': item.id,
                  'firstName': item.firstName,
                  'lastName': item.lastName,
                  'userName': item.userName,
                  'phone': item.phone
                },
            changeListener);

  final sqflite.DatabaseExecutor database;

  final StreamController<String> changeListener;

  final QueryAdapter _queryAdapter;

  final InsertionAdapter<User> _userInsertionAdapter;

  final UpdateAdapter<User> _userUpdateAdapter;

  final DeletionAdapter<User> _userDeletionAdapter;

  @override
  Future<User?> findUserById(int id) async {
    return _queryAdapter.query('SELECT * FROM User WHERE id = ?1',
        mapper: (Map<String, Object?> row) => User(row['id'] as int,
            firstName: row['firstName'] as String?,
            lastName: row['lastName'] as String?,
            userName: row['userName'] as String?,
            phone: row['phone'] as String?),
        arguments: [id]);
  }

  @override
  Future<List<User>> findAllUsers() async {
    return _queryAdapter.queryList('SELECT * FROM User',
        mapper: (Map<String, Object?> row) => User(row['id'] as int,
            firstName: row['firstName'] as String?,
            lastName: row['lastName'] as String?,
            userName: row['userName'] as String?,
            phone: row['phone'] as String?));
  }

  @override
  Stream<List<User>> findAllUsersAsStream() {
    return _queryAdapter.queryListStream('SELECT * FROM User',
        mapper: (Map<String, Object?> row) => User(row['id'] as int,
            firstName: row['firstName'] as String?,
            lastName: row['lastName'] as String?,
            userName: row['userName'] as String?,
            phone: row['phone'] as String?),
        queryableName: 'User',
        isView: false);
  }

  @override
  Future<void> insertUser(User user) async {
    await _userInsertionAdapter.insert(user, OnConflictStrategy.abort);
  }

  @override
  Future<void> insertUsers(List<User> Users) async {
    await _userInsertionAdapter.insertList(Users, OnConflictStrategy.abort);
  }

  @override
  Future<void> updateUser(User User) async {
    await _userUpdateAdapter.update(User, OnConflictStrategy.abort);
  }

  @override
  Future<void> updateUsers(List<User> User) async {
    await _userUpdateAdapter.updateList(User, OnConflictStrategy.abort);
  }

  @override
  Future<void> deleteUser(User User) async {
    await _userDeletionAdapter.delete(User);
  }

  @override
  Future<void> deleteUsers(List<User> messages) async {
    await _userDeletionAdapter.deleteList(messages);
  }
}

class _$ContactDao extends ContactDao {
  _$ContactDao(this.database, this.changeListener)
      : _queryAdapter = QueryAdapter(database, changeListener),
        _contactInsertionAdapter = InsertionAdapter(
            database,
            'contact',
            (Contact item) => <String, Object?>{
                  'id': item.id,
                  'firstName': item.firstName,
                  'lastName': item.lastName,
                  'user_id': item.userId
                },
            changeListener),
        _contactUpdateAdapter = UpdateAdapter(
            database,
            'contact',
            ['id'],
            (Contact item) => <String, Object?>{
                  'id': item.id,
                  'firstName': item.firstName,
                  'lastName': item.lastName,
                  'user_id': item.userId
                },
            changeListener),
        _contactDeletionAdapter = DeletionAdapter(
            database,
            'contact',
            ['id'],
            (Contact item) => <String, Object?>{
                  'id': item.id,
                  'firstName': item.firstName,
                  'lastName': item.lastName,
                  'user_id': item.userId
                },
            changeListener);

  final sqflite.DatabaseExecutor database;

  final StreamController<String> changeListener;

  final QueryAdapter _queryAdapter;

  final InsertionAdapter<Contact> _contactInsertionAdapter;

  final UpdateAdapter<Contact> _contactUpdateAdapter;

  final DeletionAdapter<Contact> _contactDeletionAdapter;

  @override
  Future<Contact?> findContactById(int id) async {
    return _queryAdapter.query('SELECT * FROM Contact WHERE id = ?1',
        mapper: (Map<String, Object?> row) => Contact(), arguments: [id]);
  }

  @override
  Future<List<Contact>> findAllContacts() async {
    return _queryAdapter.queryList('SELECT * FROM Contact',
        mapper: (Map<String, Object?> row) => Contact());
  }

  @override
  Stream<List<Contact>> findAllContactsAsStream() {
    return _queryAdapter.queryListStream('SELECT * FROM Contact',
        mapper: (Map<String, Object?> row) => Contact(),
        queryableName: 'contact',
        isView: false);
  }

  @override
  Future<void> insertContact(Contact contact) async {
    await _contactInsertionAdapter.insert(contact, OnConflictStrategy.abort);
  }

  @override
  Future<void> insertContacts(List<Contact> Contacts) async {
    await _contactInsertionAdapter.insertList(
        Contacts, OnConflictStrategy.abort);
  }

  @override
  Future<void> updateContact(Contact Contact) async {
    await _contactUpdateAdapter.update(Contact, OnConflictStrategy.abort);
  }

  @override
  Future<void> updateContacts(List<Contact> Contact) async {
    await _contactUpdateAdapter.updateList(Contact, OnConflictStrategy.abort);
  }

  @override
  Future<void> deleteContact(Contact Contact) async {
    await _contactDeletionAdapter.delete(Contact);
  }

  @override
  Future<void> deleteContacts(List<Contact> Contacts) async {
    await _contactDeletionAdapter.deleteList(Contacts);
  }
}
