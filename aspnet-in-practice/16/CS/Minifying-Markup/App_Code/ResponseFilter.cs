using System;
using System.Web;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ASPNET4InPractice.Chapter14
{
	public class ResponseFilter : Stream
	{
		private Stream responseStream;
		private StringBuilder markup;
		private string resultingHtml;

		public ResponseFilter(Stream inputStream)
		{
			if (inputStream == null)
				throw new ArgumentNullException("Input stream");

			markup = new StringBuilder();
			resultingHtml = String.Empty;
			responseStream = inputStream;
		}

		public override void Write(byte[] byteBuffer, int offset, int count)
		{
			// this method is called everytime ASP.NET write a piece of
			// the buffer, so we need to compose a buffer
			string buffer = System.Text.Encoding.Default.GetString(byteBuffer, offset, count);
			markup.Append(buffer);
		}

		public override void Flush()
		{
			resultingHtml = markup.ToString();

			// modify only valid html content
			if (resultingHtml.IndexOf("</html>", StringComparison.InvariantCultureIgnoreCase) > -1)
			{
				// in this example, we will remove tab and \r\n from markup
				resultingHtml = Regex.Replace(resultingHtml, "\t", string.Empty);
				resultingHtml = Regex.Replace(resultingHtml, "\r\n", " ");
				resultingHtml = Regex.Replace(resultingHtml, "\r", " ");
				resultingHtml = Regex.Replace(resultingHtml, "\n", " ");

				resultingHtml = Regex.Replace(resultingHtml, "<!--", "<!--\r\n");
				resultingHtml = Regex.Replace(resultingHtml, "//-->", "\r\n//-->");

				// trim to remove unuseful chars
				resultingHtml = resultingHtml.Trim();
			}

			// send data out to response buffer
			byte[] data = System.Text.Encoding.Default.GetBytes(resultingHtml);
			responseStream.Write(data, 0, data.Length);

			responseStream.Flush();
		}

		public override bool CanRead
		{
			get { return true; }
		}

		public override bool CanSeek
		{
			get { return true; }
		}

		public override bool CanWrite
		{
			get { return true; }
		}

		public override void Close()
		{
			responseStream.Close();
		}

		public override long Length
		{
			get { return 0; }
		}

		public override long Position
		{
			get;
			set;
		}

		public override long Seek(long offset, System.IO.SeekOrigin direction)
		{
			return responseStream.Seek(offset, direction);
		}

		public override void SetLength(long length)
		{
			responseStream.SetLength(length);
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return responseStream.Read(buffer, offset, count);
		}
	}
}