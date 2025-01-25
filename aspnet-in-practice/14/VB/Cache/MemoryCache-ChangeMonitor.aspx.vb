Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Runtime.Caching

Partial Public Class MemoryCache_ChangeMonitor
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

		Dim policy As New CacheItemPolicy() With {
		 .AbsoluteExpiration = DateTime.Now.AddHours(1),
		 .SlidingExpiration = ObjectCache.NoSlidingExpiration,
		 .Priority = CacheItemPriority.Default
		}

		policy.ChangeMonitors.Add(New HostFileChangeMonitor(New List(Of [String])() From {
		  Server.MapPath("file.txt")
		  }))

		MemoryCache.Default.Add("cacheKey", DateTime.Now, policy, Nothing)

		Value.Text = MemoryCache.Default("cacheKey").ToString()

	End Sub
End Class
