namespace CRUD_HR.Web.Endpoints.FeatureValue.Get.v1
{
    public class GetFeatureValueResponse
    {
        public int Id { get; set; }
        public string value { get; set; }
        public int FeatureId { get; set; }
        public string FeatureName { get; set; }
    }
}
