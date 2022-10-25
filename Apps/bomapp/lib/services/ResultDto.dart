class ResultDto<T> {
  T? data;
  int? statusCode;
  String? content;
  bool isSuccess;
  ResultDto(this.statusCode, this.content, this.isSuccess, {this.data});
}
