import 'package:signalr_netcore/signalr_client.dart';
import 'package:get/get.dart';

class ListenMessageController extends GetxController{

final serverUrl = "http://localhost:5050/recivehub";
ListenMessageController()
{
final hubConnection = HubConnectionBuilder().withUrl(serverUrl).build();
hubConnection.start();
//hubConnection.on("ReciveMessage",handleReciveMessage);
}
void handleReciveMessage(List<Object>? data){

}
}