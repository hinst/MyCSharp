using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MyCSharp
{

	public static class TextIdentHelper
	{

		public static string Ident(this string text, string ident, int startIndex = 0)
		{
			var lines = 
				text.Split(
					new string[] 
					{
						Environment.NewLine
					}, 
					StringSplitOptions.None
				);
			int count = lines.Length;
			for (int i = startIndex; i < count; ++i)
			{
				lines[i] = ident + lines[i];
			}
			return string.Join(Environment.NewLine, lines);
		}

		public static string Unident(this string text, int startIndex = 0)
		{
			Regex regex;
			regex = new Regex(@"^\s+");
			text = regex.Replace(text, "");
			regex = new Regex(@"[^\S\n]\s+");
			text = regex.Replace(text, Environment.NewLine);
			return text;
		}

	}

}
