using CsvHelper.Configuration.Attributes;

namespace XmlScriptures
{
	public class BookName
	{
		public string? Type { get; set; }
		public string? Order { get; set; }
		[Name("name")]
		public string? Name { get; set; }
		[Name("abbrev")]
		public string? Abbrev { get; set; }
		[Name("file")]
		public string? File { get; set; }
		[Name("audio")]
		public string? Audio { get; set; }
	}
}
