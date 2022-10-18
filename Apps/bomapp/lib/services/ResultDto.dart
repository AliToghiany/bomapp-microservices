class ResultDto<T>{
T data;
int? statusCode;
String? content;
bool isSuccess;
ResultDto(this.data,this.statusCode,this.content,this.isSuccess);
}