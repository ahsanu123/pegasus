Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Runtime.Caching
Imports Cache
Imports Microsoft.ApplicationServer.Caching
Imports System.Web.Caching

Namespace Providers.AppFabric
	Public Class AppFabricOutputCacheProvider
		Inherits OutputCacheProvider
		Shared provider As New AppFabricCacheProvider()

		Public Overrides Function Add(ByVal key As String, ByVal entry As Object, ByVal utcExpiry As DateTime) As Object
			[Set](key, entry, utcExpiry)
			Return entry
		End Function

		Public Overrides Function [Get](ByVal key As String) As Object
			Return provider.[Get](key)
		End Function

		Public Overrides Sub Remove(ByVal key As String)
			provider.Remove(key)
		End Sub

		Public Overrides Sub [Set](ByVal key As String, ByVal entry As Object, ByVal utcExpiry As DateTime)
			provider.[Set](key, entry, New CacheItemPolicy() With {
			 .AbsoluteExpiration = utcExpiry.ToLocalTime()
			})
		End Sub
	End Class
End Namespace