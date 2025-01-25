Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Reflection

' wrapping class for System.Web.Util.HashCodeCombiner
Namespace ASPNET4InPractice

	Public Class HashCodeCombiner
		Private internalCombiner As Object
		Private Shared constructor As ConstructorInfo
		Private Shared addObjectMethod As MethodInfo
		Private Shared resultProperty As PropertyInfo

		Private Const flags As BindingFlags = BindingFlags.NonPublic Or BindingFlags.[Public] Or BindingFlags.Instance

		Shared Sub New()
			Dim asm As Assembly = Assembly.GetAssembly(GetType(System.Web.UI.Page))
			Dim hashCodeCombinerType As Type = asm.[GetType]("System.Web.Util.HashCodeCombiner")
			constructor = hashCodeCombinerType.GetConstructor(flags, Nothing, Type.EmptyTypes, Nothing)
			addObjectMethod = hashCodeCombinerType.GetMethod("AddObject", flags, Nothing, New Type() {GetType(Object)}, Nothing)
			resultProperty = hashCodeCombinerType.GetProperty("CombinedHashString", flags)
		End Sub

		Public Sub New()
			internalCombiner = constructor.Invoke(Nothing)
		End Sub

		Public Sub AddObject(ByVal value As Object)
			addObjectMethod.Invoke(internalCombiner, New Object() {value})
		End Sub

		Public ReadOnly Property CombinedHashString() As String
			Get
				Return DirectCast(resultProperty.GetValue(internalCombiner, Nothing), String)
			End Get
		End Property
	End Class
End Namespace