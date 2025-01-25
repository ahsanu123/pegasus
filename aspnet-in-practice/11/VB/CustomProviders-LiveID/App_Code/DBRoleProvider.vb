Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports ObjectModel

Public Class DBRoleProvider
    Inherits RoleProvider
    Public Overloads Overrides Property ApplicationName() As String
        Get
            Return "/"
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Overloads Overrides Sub AddUsersToRoles(ByVal usernames As String(), ByVal roleNames As String())
        Using ctx As New UsersEntities()
            Dim username As String, roleName As String
            For i As Integer = 0 To usernames.Length - 1
                username = usernames(i)
                Dim u As User = ctx.UserSet.FirstOrDefault(Function(user) user.Username.Equals(username))

                If u IsNot Nothing Then
                    For j As Integer = 0 To roleNames.Length - 1
                        roleName = roleNames(i)
                        Dim r As Role = ctx.RoleSet.FirstOrDefault(Function(role) role.RoleName.Equals(roleName))
                        u.Roles.Add(r)
                    Next
                End If
            Next

            ctx.SaveChanges()
        End Using
    End Sub

    Public Overloads Overrides Sub CreateRole(ByVal roleName As String)
        Using ctx As New UsersEntities()
            ctx.AddToRoleSet(New Role())
            ctx.SaveChanges()
        End Using
    End Sub

    Public Overloads Overrides Function IsUserInRole(ByVal username As String, ByVal roleName As String) As Boolean
        Using ctx As New UsersEntities()
            Return ctx.RoleSet.Include("Users").Where(Function(u) u.RoleName.Equals(roleName)).SelectMany(Function(x) x.Users).Count(Function(x) x.Username.Equals(username)) > 0
        End Using
    End Function

    Public Overloads Overrides Function GetAllRoles() As String()
        Using ctx As New UsersEntities()
            Return ctx.RoleSet.[Select](Function(x) x.RoleName).ToArray()
        End Using
    End Function

    Public Overloads Overrides Function GetRolesForUser(ByVal username As String) As String()
        Using ctx As New UsersEntities()
            Return ctx.UserSet.Include("Roles").Where(Function(x) x.Username.Equals(username)).SelectMany(Function(x) x.Roles.[Select](Function(y) y.RoleName)).ToArray()
        End Using
    End Function

    Public Overloads Overrides Function DeleteRole(ByVal roleName As String, ByVal throwOnPopulatedRole As Boolean) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overloads Overrides Function FindUsersInRole(ByVal roleName As String, ByVal usernameToMatch As String) As String()
        Throw New NotImplementedException()
    End Function

    Public Overloads Overrides Function GetUsersInRole(ByVal roleName As String) As String()
        Throw New NotImplementedException()
    End Function

    Public Overloads Overrides Sub RemoveUsersFromRoles(ByVal usernames As String(), ByVal roleNames As String())
        Throw New NotImplementedException()
    End Sub

    Public Overloads Overrides Function RoleExists(ByVal roleName As String) As Boolean
        Using ctx As New UsersEntities()
            Return ctx.RoleSet.Count(Function(x) x.RoleName.Equals(roleName)) > 0
        End Using
    End Function
End Class