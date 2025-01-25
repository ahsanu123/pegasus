using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

public static class SecurityUtility
{
	public static string RemoveHtml(string text)
	{
		return Regex.Replace(text, "<[^>]*>", String.Empty);
	}

	public static string BBCode(string text)
	{
		text = text.Replace("[b]", "<b>").Replace("[/b]", "</b>");
		text = text.Replace("[i]", "<i>").Replace("[/i]", "</i>");
		text = text.Replace("[u]", "<u>").Replace("[/u]", "</u>");
		return text;
	}
}

