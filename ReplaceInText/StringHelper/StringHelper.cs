using System;
using System.Text;

namespace StringHelperTest
{
	public class StringHelper
	{

		public enum CompareMethods
		{
			Text,
			Binary
		}

		public static string ReplaceText(string Expression,
			string SearchText,
			string ReplaceText,
			CompareMethods Method)
		{
			string result;
			int position;
			string temp;

			if(Method == CompareMethods.Text) 
			{
				result = "";
				SearchText = SearchText.ToUpper();
				temp = Expression.ToUpper();
				position = temp.IndexOf(SearchText);
				while(position >= 0)
				{
					result = result + Expression.Substring(0,position) + ReplaceText;
					Expression = Expression.Substring(position + SearchText.Length);
					temp = temp.Substring(position+SearchText.Length);
					position = temp.IndexOf(SearchText);
				}
				result = result + Expression;
			} 
			else 
			{
				result = Expression.Replace(SearchText,ReplaceText);
			}

			return result;
		}

		public static string ReplaceTextB(string Expression,
			string SearchText,
			string ReplaceText,
			CompareMethods Method)
		{
			StringBuilder result;
			int position;
			string temp;

			if(Method == CompareMethods.Text) 
			{
				result = new StringBuilder();
				SearchText = SearchText.ToUpper();
				temp = Expression.ToUpper();
				position = temp.IndexOf(SearchText);
				while(position >= 0)
				{
					result.Append(Expression.Substring(0,position) + ReplaceText);
					Expression = Expression.Substring(position + SearchText.Length);
					temp = temp.Substring(position+SearchText.Length);
					position = temp.IndexOf(SearchText);
				}
				result.Append(Expression);
				return result.ToString();
			} 
			else 
			{
				return Expression.Replace(SearchText,ReplaceText);
			}
		}
	}
}
