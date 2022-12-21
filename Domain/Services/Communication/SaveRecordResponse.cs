

namespace BackendData.Domain.Services.Communication
{
    public class SaveRecordResponse : BaseResponse<Model.Record>
    {
        public Model.Record item {get; private set;}
        public SaveRecordResponse(Model.Record resource) : base(resource) { }
        public SaveRecordResponse(string message = null) : base(message) { }

    }
}