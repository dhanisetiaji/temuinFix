using SQLite;

namespace temuinFix.Models
{
    public class DataModel
    {
        
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
