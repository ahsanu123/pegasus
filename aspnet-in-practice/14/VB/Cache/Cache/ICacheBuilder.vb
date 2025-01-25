Imports System
Imports System.Runtime.Caching

Public Interface ICacheBuilder
	Function GetInstance() As ObjectCache
	ReadOnly Property DefaultRegionName() As String
End Interface