Imports System
Imports System.Web
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

Namespace ASPNET4InPractice.Chapter14
    Public Class ResponseFilter
        Inherits Stream
        Private responseStream As Stream
        Private markup As StringBuilder
        Private resultingHtml As String

        Public Sub New(ByVal inputStream As Stream)
            If inputStream Is Nothing Then
                Throw New ArgumentNullException("Input stream")
            End If

            markup = New StringBuilder()
            resultingHtml = [String].Empty
            responseStream = inputStream
        End Sub

        Public Overloads Overrides Sub Write(ByVal byteBuffer As Byte(), ByVal offset As Integer, ByVal count As Integer)
            ' this method is called everytime ASP.NET write a piece of
            ' the buffer, so we need to compose a buffer
            Dim buffer As String = System.Text.Encoding.[Default].GetString(byteBuffer, offset, count)
            markup.Append(buffer)
        End Sub

        Public Overloads Overrides Sub Flush()
            resultingHtml = markup.ToString()

            ' modify only valid html content
            If resultingHtml.IndexOf("</html>", StringComparison.InvariantCultureIgnoreCase) > -1 Then
                ' in this example, we will remove tab and \r\n from markup
                resultingHtml = Regex.Replace(resultingHtml, vbTab, String.Empty)
                resultingHtml = Regex.Replace(resultingHtml, vbCr & vbLf, " ")
                resultingHtml = Regex.Replace(resultingHtml, vbCr, " ")
                resultingHtml = Regex.Replace(resultingHtml, vbLf, " ")

                ' trim to remove unuseful chars
                resultingHtml = resultingHtml.Trim()
            End If

            ' send data out to response buffer
            Dim data As Byte() = System.Text.Encoding.[Default].GetBytes(resultingHtml)
            responseStream.Write(data, 0, data.Length)

            responseStream.Flush()
        End Sub

        Public Overloads Overrides ReadOnly Property CanRead() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overloads Overrides ReadOnly Property CanSeek() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overloads Overrides ReadOnly Property CanWrite() As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overloads Overrides Sub Close()
            responseStream.Close()
        End Sub

        Public Overloads Overrides ReadOnly Property Length() As Long
            Get
                Return 0
            End Get
        End Property

        Private _Position As Long
        Public Overloads Overrides Property Position() As Long
            Get
                Return _Position
            End Get
            Set(ByVal value As Long)
                _Position = value
            End Set
        End Property

        Public Overloads Overrides Function Seek(ByVal offset As Long, ByVal direction As System.IO.SeekOrigin) As Long
            Return responseStream.Seek(offset, direction)
        End Function

        Public Overloads Overrides Sub SetLength(ByVal length As Long)
            responseStream.SetLength(length)
        End Sub

        Public Overloads Overrides Function Read(ByVal buffer As Byte(), ByVal offset As Integer, ByVal count As Integer) As Integer
            Return responseStream.Read(buffer, offset, count)
        End Function
    End Class
End Namespace