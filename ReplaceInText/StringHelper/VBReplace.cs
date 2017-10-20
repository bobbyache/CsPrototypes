using System;
using System.Threading;
using System.Globalization;

namespace StringHelperTest
{
	public enum StringCompareMethod
	{
		Binary = 0,
		Text = 1
	}
 
	public sealed class VBString
	{
		internal static readonly CompareInfo m_InvariantCompareInfo = CultureInfo.InvariantCulture.CompareInfo;

		public static string Replace(string Expression, string Find, string Replacement, int Start /* = 1 */, int Count /* = -1 */, StringCompareMethod Compare /* = 0 */)
		{
			string text1;
			try
			{
				if (Count < -1)
				{
					throw new ArgumentException("Count 0", "Replace");
				}
				if (Start <= 0)
				{
					throw new ArgumentException("Start 0", "Replace");
				}
				if ((Expression == null) || (Start > Expression.Length))
				{
					return null;
				}
				if (Start != 1)
				{
					Expression = Expression.Substring(Start - 1);
				}
				if (((Find == null) || (Find.Length == 0)) || (Count == 0))
				{
					return Expression;
				}
				if (Count == -1)
				{
					Count = Expression.Length;
				}
				text1 = Join(Split(Expression, Find, Count + 1, Compare), Replacement);
			}
			catch (Exception exception1)
			{
				throw exception1;
			}
			return text1;
		}


		public static string Join(string[] SourceArray, string Delimiter /* = " " */)
		{
			string text1;
			try
			{
				if (IsArrayEmpty(SourceArray))
				{
					return null;
				}
				if (SourceArray.Rank != 1)
				{
					throw new ArgumentException("Rank not 1");
				}
				text1 = string.Join(Delimiter, SourceArray);
			}
			catch (Exception exception1)
			{
				throw exception1;
			}
			return text1;
		}

		private static bool IsArrayEmpty(Array ary)
		{
			if (ary == null)
			{
				return true;
			}
			return (ary.Length == 0);
		}


		public static string[] Split(string Expression, string Delimiter /* = " " */, int Limit /* = -1 */, StringCompareMethod Compare /* = 0 */)
		{
			string[] textArray1;
			try
			{
				int num2;
				if ((Expression == null) || (Expression.Length == 0))
				{
					return new string[1] { "" } ;
				}
				if (Limit == -1)
				{
					Limit = Expression.Length + 1;
				}
				if (Delimiter == null)
				{
					num2 = 0;
				}
				else
				{
					num2 = Delimiter.Length;
				}
				if (num2 == 0)
				{
					return new string[1] { Expression } ;
				}
				textArray1 = SplitHelper(Expression, Delimiter, Limit, (int) Compare);
			}
			catch (Exception exception1)
			{
				throw exception1;
			}
			return textArray1;
		}

		private static string[] SplitHelper(string sSrc, string sFind, int cMaxSubStrings, int Compare)
		{
			CompareInfo info1;
			int num2 = 0;
			CompareOptions options1;
			int num3;
			int num5 = 0;
			int num6 = 0;
			if (sFind == null)
			{
				num3 = 0;
			}
			else
			{
				num3 = sFind.Length;
			}
			if (sSrc == null)
			{
				num6 = 0;
			}
			else
			{
				num6 = sSrc.Length;
			}
			if (num3 == 0)
			{
				return new string[1] { sSrc } ;
			}
			if (num6 == 0)
			{
				return new string[1] { sSrc } ;
			}
			int num1 = 20;
			if (num1 > cMaxSubStrings)
			{
				num1 = cMaxSubStrings;
			}
			string[] textArray1 = new string[num1 + 1];
			if (Compare == 0)
			{
				options1 = CompareOptions.Ordinal;
				info1 = m_InvariantCompareInfo;
			}
			else
			{
				info1 = Thread.CurrentThread.CurrentCulture.CompareInfo;
				options1 = CompareOptions.IgnoreWidth | (CompareOptions.IgnoreKanaType | CompareOptions.IgnoreCase);
			}
			while (num5 < num6)
			{
				string text1;
				int num4 = info1.IndexOf(sSrc, sFind, num5, (int) (num6 - num5), options1);
				if ((num4 == -1) || ((num2 + 1) == cMaxSubStrings))
				{
					text1 = sSrc.Substring(num5);
					if (text1 == null)
					{
						text1 = "";
					}
					textArray1[num2] = text1;
					break;
				}
				text1 = sSrc.Substring(num5, num4 - num5);
				if (text1 == null)
				{
					text1 = "";
				}
				textArray1[num2] = text1;
				num5 = num4 + num3;
				num2++;
				if (num2 > num1)
				{
					num1 += 20;
					if (num1 > cMaxSubStrings)
					{
						num1 = cMaxSubStrings + 1;
					}
					textArray1 = (string[]) CopyArray((Array) textArray1, new string[num1 + 1]);
				}
				textArray1[num2] = "";
				if (num2 == cMaxSubStrings)
				{
					text1 = sSrc.Substring(num5);
					if (text1 == null)
					{
						text1 = "";
					}
					textArray1[num2] = text1;
					break;
				}
			}
			if ((num2 + 1) == textArray1.Length)
			{
				return textArray1;
			}
			return (string[]) CopyArray((Array) textArray1, new string[num2 + 1]);
		}

		public static Array CopyArray(Array arySrc, Array aryDest)
		{
			if (arySrc != null)
			{
				int num2 = arySrc.Length;
				if (num2 == 0)
				{
					return aryDest;
				}
				if (aryDest.Rank != arySrc.Rank)
				{
					throw new InvalidCastException("");
				}
				int num9 = aryDest.Rank - 2;
				for (int num1 = 0; num1 <= num9; num1++)
				{
					if (aryDest.GetUpperBound(num1) != arySrc.GetUpperBound(num1))
					{
						throw new ArrayTypeMismatchException("");
					}
				}
				if (num2 > aryDest.Length)
				{
					num2 = aryDest.Length;
				}
				if (arySrc.Rank > 1)
				{
					int num4 = arySrc.Rank;
					int num7 = arySrc.GetLength(num4 - 1);
					int num6 = aryDest.GetLength(num4 - 1);
					if (num6 != 0)
					{
						int num5 = Math.Min(num7, num6);
						int num8 = (arySrc.Length / num7) - 1;
						for (int num3 = 0; num3 <= num8; num3++)
						{
							Array.Copy(arySrc, (int) (num3 * num7), aryDest, (int) (num3 * num6), num5);
						}
					}
					return aryDest;
				}
				Array.Copy(arySrc, aryDest, num2);
			}
			return aryDest;
		}
 

	}
}
