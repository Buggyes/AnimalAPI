namespace AnimalAPI.Models
{
    public class DiseaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
		public string Agent { get; set; } = string.Empty;
		public List<string> Symptoms { get; set; } = new List<string>();
		public List<string> Treatment { get; set; } = new List<string>();
		public string Frequency { get; set; } = string.Empty;
		public bool IsContagious { get; set; }
	}
}
