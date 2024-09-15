using Cms.Shared.Dtos.ResponseModel;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Cms.Shared.Middleware.GlobalExceptions
{
    public class ExceptionModel
    {
        public ResponseDto<ExceptionModel> Response { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
    public class LogDetailConsume
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        public LogDetailConsume(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }
    }
}
