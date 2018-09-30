using System.Collections.Generic;

namespace Platform.DtoTool
{ 
    public class ResultModel
    {
        public object Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public List<ValidationModel> Errors { get; set; }
    }

    /// <summary>
    /// A model to hold validation result of an element
    /// </summary>
    public class ValidationModel
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
