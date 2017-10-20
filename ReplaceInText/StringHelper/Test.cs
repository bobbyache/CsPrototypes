using System;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace StringHelperTest
{
	class Test
	{
		private static string ReplaceEx(string original, string pattern, string replacement)
		{
			int count, position0, position1;
			count = position0 = position1 = 0;
			string upperString = original.ToUpper();
			string upperPattern = pattern.ToUpper();
			int inc = (original.Length/pattern.Length)*(replacement.Length-pattern.Length);
			char [] chars = new char[original.Length + Math.Max(0, inc)];
			while( (position1 = upperString.IndexOf(upperPattern, position0)) != -1 )
			{
				for ( int i=position0 ; i < position1 ; ++i ) chars[count++] = original[i];
				for ( int i=0 ; i < replacement.Length ; ++i ) chars[count++] = replacement[i];
				position0 = position1+pattern.Length;
			}
			if ( position0 == 0 ) return original;
			for ( int i=position0 ; i < original.Length ; ++i ) chars[count++] = original[i];
			return new string(chars, 0, count);
		}

		[STAThread]
		static void Main(string[] args)
		{
			string segment = "ABCabcAbCaBcAbcabCABCAbcaBC";
			string source;
			string pattern = "AbC";
			string destination = "Some";
			string result = "";
			
			const long count = 1000;
			StringBuilder pressure = new StringBuilder();
			HiPerfTimer time;

			for (int i = 0; i < count; i++)
			{
				pressure.Append(segment);
			}
			source = pressure.ToString();
			GC.Collect();
	
			//regexp
			time = new HiPerfTimer();
			time.Start();
			for (int i = 0; i < count; i++)
			{
				result = Regex.Replace(source, pattern, destination, RegexOptions.IgnoreCase);
			}
			time.Stop();

			Console.WriteLine("regexp    = " + time.Duration + "s");
			GC.Collect();

			//vb
			time = new HiPerfTimer();
			time.Start();
			for (int i = 0; i < count; i++)
			{
				result = Strings.Replace(source, pattern, destination, 1, -1, CompareMethod.Text);
			}
			time.Stop();

			Console.WriteLine("vb        = " + time.Duration + "s");
			GC.Collect();


			//vbReplace
			time = new HiPerfTimer();
			time.Start();
			for (int i = 0; i < count; i++)
			{
				result = VBString.Replace(source, pattern, destination, 1, -1, StringCompareMethod.Text);
			}
			time.Stop();

			Console.WriteLine("vbReplace = " + time.Duration + "s");// + result);
			GC.Collect();


			// ReplaceEx
			time = new HiPerfTimer();
			time.Start();
			for (int i = 0; i < count; i++)
			{
				result = Test.ReplaceEx(source, pattern, destination);//, StringHelper.CompareMethods.Text);
			}
			time.Stop();

			Console.WriteLine("ReplaceEx = " + time.Duration + "s");
			GC.Collect();


			// Replace
			time = new HiPerfTimer();
			time.Start();
			for (int i = 0; i < count; i++)
			{
				result = source.Replace(pattern.ToLower(), destination);
			}
			time.Stop();

			Console.WriteLine("Replace   = " + time.Duration + "s");
			GC.Collect();


			//sorry, two slow :(
			/*//substring
			time = new HiPerfTimer();
			time.Start();
			for (int i = 0; i < count; i++)
			{
				result = StringHelper.ReplaceText(source, pattern, destination, StringHelper.CompareMethods.Text);
			}
			time.Stop();

			Console.WriteLine("substring =" + time.Duration + ":");
			GC.Collect();


			//substring with stringbuilder
			time = new HiPerfTimer();
			time.Start();
			for (int i = 0; i < count; i++)
			{
				result = StringHelper.ReplaceTextB(source, pattern, destination, StringHelper.CompareMethods.Text);
			}
			time.Stop();

			Console.WriteLine("substringB=" + time.Duration + ":");
			GC.Collect();
			*/

			Console.ReadLine();
		}
	}
}