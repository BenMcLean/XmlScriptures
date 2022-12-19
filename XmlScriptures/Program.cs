using CsvHelper;
using System.Globalization;
using System.Xml.Linq;

namespace XmlScriptures
{
	public class Program
	{
		public const string path = @"..\..\..";
		public static void Main(string[] args)
		{
			IEnumerable<BookName> bookNames;
			using (StreamReader reader = new StreamReader(Path.Combine(path, "book_name.csv")))
			using (CsvReader csv = new CsvReader(
				reader: reader,
				culture: CultureInfo.InvariantCulture))
			{
				bookNames = csv.GetRecords<BookName>().ToList();
			}
			//foreach (BookName bookName in bookNames)
			//	Console.WriteLine(bookName.Name);
			IEnumerable<BookOfMormon> bookOfMormons;
			using (StreamReader reader = new StreamReader(Path.Combine(path, "bofm1908.csv")))
			using (CsvReader csv = new CsvReader(
				reader: reader,
				culture: CultureInfo.InvariantCulture))
			{
				bookOfMormons = csv.GetRecords<BookOfMormon>().ToList();
			}
			XElement xVolume = new XElement("Volume");
			foreach (IEnumerable<BookOfMormon> book in bookOfMormons.Books())
			{
				XElement xBook = new XElement("Book");
				foreach (IEnumerable<BookOfMormon> chapter in book.Chapters())
				{
					XElement xChapter = new XElement(
						name: "Chapter",
						content: string.Join(Environment.NewLine, chapter
							.Where(e => !e.IsVerse())
							.Select(e => e.Text)));
					foreach (BookOfMormon verse in chapter
						.Where(v => v.IsVerse()))
						xChapter.Add(new XElement("Verse", verse.Text));
					xBook.Add(xChapter);
				}
				xVolume.Add(xBook);
			}
			xVolume.Save("output.xml");
		}
	}
}
