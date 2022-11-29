import 'package:shared_preferences/shared_preferences.dart';
import 'package:signalr_netcore/long_polling_transport.dart';

//import 'package:shared_preferences/shared_preferences.dart';


class TokenUtilities{
  
  static String? GetToken(){
    return 
    "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEwMDAyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQ29zdHVtZXIifQ.b-Fz1S5Ql5uK1t-uzcLHBwJbfL8H9RyLg7nYNW6RJ3A";
  }
  static Future<int> GetMyId() async{
   // final prefs = await SharedPreferences.getInstance();
   // return prefs.getInt('id')!;
    return 10002;
    
  }
  static void SetMyId(int Id) async{
final prefs = await SharedPreferences.getInstance();

// Save an integer value to 'counter' key.
await prefs.setInt('id', Id);
  }
  //ali-eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEwMDAyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQ29zdHVtZXIifQ.b-Fz1S5Ql5uK1t-uzcLHBwJbfL8H9RyLg7nYNW6RJ3A
  //hassan-eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjIwMDAyIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQ29zdHVtZXIifQ.7e6XR3Ad7ZsquoJe7QQNelwEi0Z9bvxjvZ-D-Zf0zEk
}