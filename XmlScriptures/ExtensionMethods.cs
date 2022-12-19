using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlScriptures
{
	public static class ExtensionMethods
	{
		public static IEnumerable<IEnumerable<BookOfMormon>> Books(this BookOfMormon[] bookOfMormon) => Books(bookOfMormon.AsEnumerable());
		public static IEnumerable<IEnumerable<BookOfMormon>> Books(this IEnumerable<BookOfMormon> bookOfMormon)
		{
			bool first = true;
			List<BookOfMormon> verses = new List<BookOfMormon>();
			foreach (BookOfMormon verse in bookOfMormon)
			{
				if (!first && verse.IsBook())
				{
					yield return verses;
					verses.Clear();
				}
				verses.Add(verse);
				first = false;
			}
			yield return verses;
		}
		public static IEnumerable<IEnumerable<BookOfMormon>> Chapters(this BookOfMormon[] bookOfMormon) => Chapters(bookOfMormon.AsEnumerable());
		public static IEnumerable<IEnumerable<BookOfMormon>> Chapters(this IEnumerable<BookOfMormon> bookOfMormon)
		{
			bool first = true;
			List<BookOfMormon> verses = new List<BookOfMormon>();
			foreach (BookOfMormon verse in bookOfMormon)
			{
				if (!first && verse.IsChapter())
				{
					yield return verses;
					verses.Clear();
				}
				verses.Add(verse);
				first = false;
			}
			yield return verses;
		}
	}
}
