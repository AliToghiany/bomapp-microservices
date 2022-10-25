class RecentChat
{
DateTime dateOfSendMessage;
String text;
int? groupId;
int? userId;
bool seen;
RecentChat(this.text,this.dateOfSendMessage,this.seen,{this.userId,this.groupId});
}