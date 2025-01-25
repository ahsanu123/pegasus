Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Runtime.Caching

Namespace Providers.InMemory
	Public Class MemoryCacheBuilder
		Implements ICacheBuilder
		Public Sub New()
		End Sub

		Public Function GetInstance() As ObjectCache Implements ICacheBuilder.GetInstance
			Return MemoryCache.Default
		End Function

		Public ReadOnly Property DefaultRegionName() As String Implements ICacheBuilder.DefaultRegionName
			Get
				Throw New NotSupportedException()
			End Get
		End Property
	End Class
End Namespace
