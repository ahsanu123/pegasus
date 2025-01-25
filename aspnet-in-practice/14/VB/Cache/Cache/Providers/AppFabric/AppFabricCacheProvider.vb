Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Runtime.Caching
Imports Cache
Imports Microsoft.ApplicationServer.Caching

Namespace Providers.AppFabric
	Public Class AppFabricCacheProvider
		Inherits ObjectCache
		Implements ICacheBuilder

		Public Shared factory As DataCache = Nothing
		Public Shared syncObj As New Object()

		Public Overrides Function AddOrGetExisting(ByVal key As String, ByVal value As Object, ByVal policy As CacheItemPolicy, Optional ByVal regionName As String = Nothing) As Object
			Dim item As CacheItem = GetCacheItem(key, regionName)
			If item Is Nothing Then
				[Set](New CacheItem(key, value, regionName), policy)
				Return value
			End If

			Return item.Value
		End Function

		Public Overrides Function AddOrGetExisting(ByVal value As CacheItem, ByVal policy As CacheItemPolicy) As CacheItem
			Dim item As CacheItem = GetCacheItem(value.Key, value.RegionName)
			If item Is Nothing Then
				[Set](value, policy)
				Return value
			End If

			Return item
		End Function

		Public Overrides Function AddOrGetExisting(ByVal key As String, ByVal value As Object, ByVal absoluteExpiration As System.DateTimeOffset, Optional ByVal regionName As String = Nothing) As Object
			Dim item As New CacheItem(key, value, regionName)
			Dim policy As New CacheItemPolicy()
			policy.AbsoluteExpiration = absoluteExpiration

			Return AddOrGetExisting(item, policy)
		End Function

		Public Overrides Function Contains(ByVal key As String, Optional ByVal regionName As String = Nothing) As Boolean
			Return [Get](key, regionName) IsNot Nothing
		End Function

		Public Overrides Function CreateCacheEntryChangeMonitor(ByVal keys As System.Collections.Generic.IEnumerable(Of String), Optional ByVal regionName As String = Nothing) As CacheEntryChangeMonitor
			Throw New NotImplementedException()
		End Function

		Public Overrides ReadOnly Property DefaultCacheCapabilities() As DefaultCacheCapabilities
			Get
				Return DefaultCacheCapabilities.OutOfProcessProvider Or DefaultCacheCapabilities.AbsoluteExpirations Or DefaultCacheCapabilities.SlidingExpirations Or DefaultCacheCapabilities.CacheRegions
			End Get
		End Property

		Public Overrides Function [Get](ByVal key As String, Optional ByVal regionName As String = Nothing) As Object
			key = key.ToLower()
			CreateRegionIfNeeded()

			Return If((regionName Is Nothing), CacheFactory.[Get](key), CacheFactory.[Get](key, regionName))
		End Function

		Public Overrides Function GetCacheItem(ByVal key As String, Optional ByVal regionName As String = Nothing) As CacheItem
			Dim value As Object = [Get](key, regionName)
			If value IsNot Nothing Then
				Return New CacheItem(key, value, regionName)
			End If

			Return Nothing
		End Function

		Public Overrides Function GetCount(Optional ByVal regionName As String = Nothing) As Long
			If String.IsNullOrEmpty(regionName) Then
				Throw New NotSupportedException()
			End If

			Return CacheFactory.GetObjectsInRegion(regionName).LongCount()
		End Function

		Protected Overrides Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of System.Collections.Generic.KeyValuePair(Of String, Object))
			Throw New NotSupportedException()
		End Function

		Public Overrides Function GetValues(ByVal keys As System.Collections.Generic.IEnumerable(Of String), Optional ByVal regionName As String = Nothing) As System.Collections.Generic.IDictionary(Of String, Object)
			If String.IsNullOrEmpty(regionName) Then
				Throw New NotSupportedException()
			End If

			Return CacheFactory.GetObjectsInRegion(regionName).ToDictionary(Function(x) x.Key, Function(x) x.Value)
		End Function

		Public Overrides ReadOnly Property Name() As String
			Get
				Return "AppFabric"
			End Get
		End Property

		Public Overrides Function Remove(ByVal key As String, Optional ByVal regionName As String = Nothing) As Object
			key = key.ToLower()
			CreateRegionIfNeeded()

			Return If((regionName Is Nothing), CacheFactory.Remove(key), CacheFactory.Remove(key, regionName))
		End Function

		Public Overrides Sub [Set](ByVal key As String, ByVal value As Object, ByVal policy As CacheItemPolicy, Optional ByVal regionName As String = Nothing)
			[Set](New CacheItem(key, value, regionName), policy)
		End Sub

		Public Overrides Sub [Set](ByVal item As CacheItem, ByVal policy As CacheItemPolicy)
			If item Is Nothing OrElse item.Value Is Nothing Then
				Return
			End If

			If policy IsNot Nothing AndAlso policy.ChangeMonitors IsNot Nothing AndAlso policy.ChangeMonitors.Count > 0 Then
				Throw New NotSupportedException("Change monitors are not supported")
			End If

			item.Key = item.Key.ToLower()
			CreateRegionIfNeeded()

			Dim expire As TimeSpan = If((policy.AbsoluteExpiration.Equals(Nothing)), policy.SlidingExpiration, (policy.AbsoluteExpiration - DateTimeOffset.Now))

			If String.IsNullOrEmpty(item.RegionName) Then
				CacheFactory.Put(item.Key, item.Value, expire)
			Else
				CacheFactory.Put(item.Key, item.Value, expire, item.RegionName)
			End If
		End Sub

		Private Shared ReadOnly Property CacheFactory() As DataCache
			Get
				If factory Is Nothing Then
					SyncLock syncObj
						If factory Is Nothing Then
							Dim cacheFactory2 As New DataCacheFactory()
							factory = cacheFactory2.GetDefaultCache()
						End If
					End SyncLock
				End If

				Return factory
			End Get
		End Property

		Private Sub CreateRegionIfNeeded()
			' if the regione exists, an exception is thrown
			Try
				CacheFactory.CreateRegion(DefaultRegionName)
			Catch ex As DataCacheException
				If Not ex.ErrorCode.Equals(DataCacheErrorCode.RegionAlreadyExists) Then
					Throw ex
				End If
			End Try
		End Sub

		Public Overrides Sub [Set](ByVal key As String, ByVal value As Object, ByVal absoluteExpiration As System.DateTimeOffset, Optional ByVal regionName As String = Nothing)
			Dim item As New CacheItem(key, value, regionName)
			Dim policy As New CacheItemPolicy()
			policy.AbsoluteExpiration = absoluteExpiration

			[Set](item, policy)
		End Sub

		Default Public Overrides Property Item(ByVal key As String) As Object
			Get
				Return [Get](key, DefaultRegionName)
			End Get
			Set(ByVal value As Object)
				[Set](key, value, policy:=Nothing, regionName:=DefaultRegionName)
			End Set
		End Property

		Public Function GetInstance() As ObjectCache Implements ICacheBuilder.GetInstance
			Return Me
		End Function

		Public ReadOnly Property DefaultRegionName() As String Implements ICacheBuilder.DefaultRegionName
			Get
				' TODO: load from configuration
				Return "AppFabric"
			End Get
		End Property


	End Class
End Namespace