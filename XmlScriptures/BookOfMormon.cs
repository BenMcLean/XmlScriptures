using CsvHelper.Configuration.Attributes;

namespace XmlScriptures
{
	public class BookOfMormon
	{
		[Name("Text-raw")]
		public string? TextRaw { get; set; }
		public string? IsAVerse { get; set; }
		public bool IsVerse() => int.TryParse(IsAVerse, out int @int) && @int > 0;
		[Name("Verse-temp")]
		public string? VerseTemp { get; set; }
		[Name("Chapter 1")]
		public string? Chapter1 { get; set; }
		public string? AnyChapter { get; set; }
		public bool IsChapter() => int.TryParse(AnyChapter, out int @int) && @int > 0;
		public string? IsABook { get; set; }
		public bool IsBook() => int.TryParse(IsABook, out int @int) && @int > 0;
		public string? Type { get; set; }
		public string? Chapter { get; set; }
		public string? Text { get; set; }
	}
}
