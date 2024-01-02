namespace WebApp_KetNoiViecLam.Models
{
    public class ServiceViewModel
    {
        public IEnumerable<Category>? Categories { get; set; }
        public IEnumerable<Review>? Reviews { get; set; }
        public IEnumerable<Service>? Services { get; set; }
        public IEnumerable<User>? Users { get; set; }
    }
}
