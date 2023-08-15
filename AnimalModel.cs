namespace AnimalAPI
{
	public class AnimalModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Species { get; set; } = string.Empty;
		public int Age { get; set; }
		public string Color { get; set; } = string.Empty;
		public bool IsDomestic { get; set; }
	}
}