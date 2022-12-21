namespace BackendData.Domain.Services.Communication
{
    public class RecordResponse: BaseResponse<Model.Record>
    {
        public RecordResponse(string message) : base(message) { }

        public RecordResponse(Model.Record record) : base(record) { }
    }
}