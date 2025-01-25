Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Reflection
Imports System.Configuration
Imports System.Runtime.Caching
Imports Microsoft.Practices.Unity.Configuration
Imports Microsoft.Practices.Unity

Public NotInheritable Class CacheFactory
	Private Sub New()
	End Sub
	Private Shared container As IUnityContainer

	Shared Sub New()
		container = New UnityContainer()
		Dim config = DirectCast(ConfigurationManager.GetSection("unity"), UnityConfigurationSection)
		config.Containers.Default.Configure(container)
	End Sub

	Public Shared ReadOnly Property Instance() As ObjectCache
		Get
			Return container.Resolve(Of ICacheBuilder)().GetInstance()
		End Get
	End Property
End Class