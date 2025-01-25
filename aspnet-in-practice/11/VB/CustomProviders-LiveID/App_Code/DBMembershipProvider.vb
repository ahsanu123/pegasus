Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports ObjectModel
Imports System.Web.Configuration

Public Class DBMembershipProvider
    Inherits MembershipProvider

    Public Overloads Overrides Property ApplicationName() As String
        Get
            Return "/"
        End Get
        Set(ByVal value As String)
        End Set
    End Property

    Public Overloads Overrides Function ValidateUser(ByVal username As String, ByVal password As String) As Boolean
        Using ctx As New UsersEntities()
            Return ctx.UserSet.Count(Function(user) user.Username.Equals(username) AndAlso user.Password.Equals(password)) = 1
        End Using
    End Function

    Public Overloads Overrides Function CreateUser(ByVal username As String, ByVal password As String, ByVal email As String, ByVal passwordQuestion As String, ByVal passwordAnswer As String, ByVal isApproved As Boolean, _
    ByVal providerUserKey As Object, ByRef status As MembershipCreateStatus) As MembershipUser
        Using ctx As New UsersEntities()
            ' let's compose the user
            Dim u As New MembershipUser(Me.Name, username, username, email, passwordQuestion, String.Empty, _
            True, False, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, _
            DateTime.Now)

            Dim user As New User()
            user.Username = username
            user.Password = password
            user.Email = email
            ctx.AddToUserSet(user)

            ' TODO: check for e-mail and username availability

            ' updating...
            Try
                ctx.SaveChanges()
            Catch
                ' there was an error
                status = MembershipCreateStatus.ProviderError
                Return Nothing
            End Try

            ' successfully created
            status = MembershipCreateStatus.Success
            Return u
        End Using
    End Function
    Public Overloads Overrides Function GetUser(ByVal username As String, ByVal userIsOnline As Boolean) As MembershipUser
        Using ctx As New UsersEntities()
            Dim u As User = ctx.UserSet.FirstOrDefault(Function(x) x.Username.Equals(username))
            If u Is Nothing Then
                Return Nothing
            End If

            Return New MembershipUser(Me.Name, username, username, u.Email, String.Empty, String.Empty, _
            True, False, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, _
            DateTime.Now)
        End Using
    End Function

    Public Overloads Overrides Function GetUser(ByVal providerUserKey As Object, ByVal userIsOnline As Boolean) As MembershipUser
        Return GetUser(providerUserKey.ToString(), userIsOnline)
    End Function

    Public Overloads Overrides ReadOnly Property EnablePasswordReset() As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overloads Overrides ReadOnly Property EnablePasswordRetrieval() As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overloads Overrides ReadOnly Property MaxInvalidPasswordAttempts() As Integer
        Get
            Return 0
        End Get
    End Property

    Public Overloads Overrides ReadOnly Property MinRequiredNonAlphanumericCharacters() As Integer
        Get
            Return 1
        End Get
    End Property

    Public Overloads Overrides ReadOnly Property MinRequiredPasswordLength() As Integer
        Get
            Return 5
        End Get
    End Property

    Public Overloads Overrides ReadOnly Property PasswordAttemptWindow() As Integer
        Get
            Return 0
        End Get
    End Property

    Public Overloads Overrides ReadOnly Property PasswordFormat() As MembershipPasswordFormat
        Get
            Return MembershipPasswordFormat.Clear
        End Get
    End Property

    Public Overloads Overrides ReadOnly Property PasswordStrengthRegularExpression() As String
        Get
            Return String.Empty
        End Get
    End Property

    Public Overloads Overrides ReadOnly Property RequiresQuestionAndAnswer() As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overloads Overrides ReadOnly Property RequiresUniqueEmail() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overloads Overrides Function ChangePassword(ByVal username As String, ByVal oldPassword As String, ByVal newPassword As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overloads Overrides Function ChangePasswordQuestionAndAnswer(ByVal username As String, ByVal password As String, ByVal newPasswordQuestion As String, ByVal newPasswordAnswer As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overloads Overrides Function DeleteUser(ByVal username As String, ByVal deleteAllRelatedData As Boolean) As Boolean
        Throw New NotImplementedException()
    End Function
    Public Overloads Overrides Function FindUsersByEmail(ByVal emailToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
        Throw New NotImplementedException()
    End Function

    Public Overloads Overrides Function FindUsersByName(ByVal usernameToMatch As String, ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
        Throw New NotImplementedException()
    End Function

    Public Overloads Overrides Function GetAllUsers(ByVal pageIndex As Integer, ByVal pageSize As Integer, ByRef totalRecords As Integer) As MembershipUserCollection
        Throw New NotImplementedException()
    End Function

    Public Overloads Overrides Function GetNumberOfUsersOnline() As Integer
        Throw New NotImplementedException()
    End Function

    Public Overloads Overrides Function GetPassword(ByVal username As String, ByVal answer As String) As String
        Throw New NotImplementedException()
    End Function



    Public Overloads Overrides Function GetUserNameByEmail(ByVal email As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overloads Overrides Function ResetPassword(ByVal username As String, ByVal answer As String) As String
        Throw New NotImplementedException()
    End Function

    Public Overloads Overrides Function UnlockUser(ByVal userName As String) As Boolean
        Throw New NotImplementedException()
    End Function

    Public Overloads Overrides Sub UpdateUser(ByVal user As MembershipUser)
        Throw New NotImplementedException()
    End Sub
End Class