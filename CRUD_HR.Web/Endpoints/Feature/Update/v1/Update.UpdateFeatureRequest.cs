namespace CRUD_HR.Web.Endpoints.Feature.Update.v1
{
    public class UpdateFeatureRequest
    {
        public string Name { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
    }
}
