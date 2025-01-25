Imports System
Imports System.Collections
Imports System.Configuration
Imports System.Data
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports WindowsLive

Partial Public Class Live
    Inherits Page
    Protected Overloads Overrides Sub OnLoad(ByVal e As EventArgs)
        MyBase.OnLoad(e)

        Dim action As String = If(Request("action"), "login")

        ' get the user token
        Dim wll As New WindowsLiveLogin(True)
        Dim myUser As WindowsLiveLogin.User = wll.ProcessLogin(Request.Form)

        Select Case action
            Case "logout"
                ' logout
                FormsAuthentication.SignOut()
                Response.Redirect("/")
                Exit Select

            Case "clearcookie"
                ' logout
                FormsAuthentication.SignOut()

                ' 1x1 transparent GIF
                Dim type As String
                Dim content As Byte()
                wll.GetClearCookieResponse(type, content)
                Response.ContentType = type
                Response.OutputStream.Write(content, 0, content.Length)
                Response.End()

                Exit Select
            Case Else


                ' token to user association
                ' get the user token in the login
                If myUser Is Nothing AndAlso Request.Cookies("LiveID") IsNot Nothing AndAlso Not String.IsNullOrEmpty(Request.Cookies("LiveID")("token")) Then
                    Dim token As String = Request.Cookies("LiveID")("token")
                    myUser = wll.ProcessToken(token)
                End If

                ' no live ID user, redirect to login
                If myUser Is Nothing Then
                    FormsAuthentication.RedirectToLoginPage("LiveID=1")
                    Exit Sub
                End If

                Dim userID As String = myUser.Id
                Dim returnUrl As String = myUser.Context
                Dim persistent As Boolean = myUser.UsePersistentCookie

                ' the role name will be based on the userID.
                Dim roleName As String = String.Concat("Live-", userID)

                ' the user is authenticated, so I can associate him to Live ID
                If Request.IsAuthenticated Then
                    ' check for the association
                    If Not Roles.IsUserInRole(roleName) Then
                        If Not Roles.RoleExists(roleName) Then
                            Roles.CreateRole(roleName)
                        End If

                        Roles.AddUserToRole(User.Identity.Name, roleName)
                    End If

                    ' delete the temporary cookie
                    Response.Cookies.Remove("LiveID")

                    Login(User.Identity.Name, persistent)
                Else

                    ' login via Live
                    ' the user exists
                    If Roles.RoleExists(roleName) Then
                        Dim username As String = Roles.GetUsersInRole(roleName)(0)

                        Login(username, persistent)
                    Else
                        ' we need to associate the user
                        ' the token will be used later
                        Response.Cookies("LiveID")("token") = myUser.Token
                        FormsAuthentication.RedirectToLoginPage(String.Concat("LiveID=1&ReturnUrl=", Request.Url.ToString()))

                    End If
                End If

                ' in case, back to login
                FormsAuthentication.RedirectToLoginPage()

                Exit Select
        End Select
    End Sub

    Private Sub Login(ByVal username As String, ByVal persistent As Boolean)
        ' FormsAuthentication login
        FormsAuthentication.RedirectFromLoginPage(username, persistent)
        Response.End()
    End Sub
End Class