namespace Find_A_Home.Models
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Zone> Zones { get; set; } = new List<Zone>();
    }
}
