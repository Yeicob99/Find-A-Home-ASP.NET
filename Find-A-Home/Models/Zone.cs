namespace Find_A_Home.Models
{
    public class Zone
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int ProvinceId { get; set; }
        public Province Province { get; set; } = null!;
    }
}
