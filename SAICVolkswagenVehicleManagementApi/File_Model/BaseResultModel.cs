namespace ResultTest
{
    public class BaseResultModel
    {
        public BaseResultModel(int? code = null, string message = null,
            object result = null, RetureStates retureStates = RetureStates.Success)
        {
            this.Code = code;
            this.Result = result;
            this.Message = message;
            this.RetureStates = retureStates;
        }
        public int? Code { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
        public RetureStates RetureStates { get; set; }
    }
    /// <summary>
    /// 返回的状态
    /// </summary>
    public enum RetureStates
    {
        Success = 1,
        Fail = 0,
        ConfirmIsContinue = 2,
        Error = 3
    }
}
