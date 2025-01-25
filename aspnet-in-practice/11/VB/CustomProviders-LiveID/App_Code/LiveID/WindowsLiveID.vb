'
' * FILE: WindowsLiveLogin.cs
' * 
' * DESCRIPTION: Sample implementation of Web Authentication protocol in C#.
' * Also includes trusted login and application verification
' * sample implementation.
' *
' * VERSION: 1.0
' *
' * Copyright (c) 2007 Microsoft Corporation. All Rights Reserved.
' 


Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections.Specialized
Imports System.Collections
Imports System.Web
Imports System.Web.Configuration
Imports System.Security.Cryptography
Imports System.IO
Imports System.Net
Imports System.Reflection
Imports System.Xml

Namespace WindowsLive
    ''' <summary>
    ''' Sample implementation of Web Authentication protocol in C#.
    ''' Also includes trusted login and application verification
    ''' sample implementation.
    ''' </summary>
    Public Class WindowsLiveLogin
        ' Implementation of basic methods for Web Authentication support. 


        ''' <summary>
        ''' Stub implementation for logging debug output. You can run
        ''' a tool such as 'dbmon' to see the output.
        ''' </summary>
        Private Shared Sub debug(ByVal msg As String)
            System.Diagnostics.Debug.WriteLine(msg)
            System.Diagnostics.Debug.Flush()
        End Sub

        ''' <summary>
        ''' Holds the user information after a successful login.
        ''' </summary>
        Public Class User
            ''' <summary>
            ''' Creates a User object.
            ''' </summary>
            Public Sub New(ByVal timestamp As String, ByVal id As String, ByVal flags As String, ByVal context As String, ByVal token As String)
                setTimestamp(timestamp)
                setId(id)
                setFlags(flags)
                setContext(context)
                setToken(token)
            End Sub

            Private m_timestamp As DateTime

            ''' <summary>
            ''' Timestamp is the time as obtained from the SSO token.
            ''' </summary>
            Public ReadOnly Property Timestamp() As DateTime
                Get
                    Return m_timestamp
                End Get
            End Property

            Private Sub setTimestamp(ByVal timestamp As String)
                If timestamp Is Nothing Then
                    Throw New ArgumentException("Error: User: Null timestamp in token.")
                End If

                Dim timestampInt As Integer

                Try
                    timestampInt = Convert.ToInt32(timestamp)
                Catch generatedExceptionName As Exception
                    Throw New ArgumentException("Error: User: Invalid timestamp: " & timestamp)
                End Try

                Dim refTime As New DateTime(1970, 1, 1, 0, 0, 0, _
                DateTimeKind.Utc)
                Me.m_timestamp = refTime.AddSeconds(timestampInt)
            End Sub

            Private m_id As String

            ''' <summary>
            ''' Id is the pairwise unique ID for the user.
            ''' </summary>
            Public ReadOnly Property Id() As String
                Get
                    Return m_id
                End Get
            End Property

            Private Sub setId(ByVal id As String)
                If id Is Nothing Then
                    Throw New ArgumentException("Error: User: Null id in token.")
                End If

                Dim re As New Regex("^\w+$")
                If Not re.IsMatch(id) Then
                    Throw New ArgumentException("Error: User: Invalid id: " & id)
                End If

                Me.m_id = id
            End Sub

            Private _usePersistentCookie As Boolean

            ''' <summary>
            ''' Indicates whether the application
            ''' is expected to store the user token in a session or
            ''' persistent cookie.
            ''' </summary>
            Public ReadOnly Property UsePersistentCookie() As Boolean
                Get
                    Return _usePersistentCookie
                End Get
            End Property

            Private Sub setFlags(ByVal flags As String)
                _usePersistentCookie = False
                If (flags IsNot Nothing) AndAlso (flags <> "") Then
                    Try
                        Dim flagsInt As Integer = Convert.ToInt32(flags)
                        Me._usePersistentCookie = ((flagsInt Mod 2) = 1)
                    Catch generatedExceptionName As Exception
                        Throw New ArgumentException("Error: User: Invalid flags: " & flags)
                    End Try
                End If
            End Sub

            Private m_context As String

            ''' <summary>
            ''' Context is the application context that was originally
            ''' passed to the login request, if any.
            ''' </summary>
            Public ReadOnly Property Context() As String
                Get
                    Return m_context
                End Get
            End Property

            Private Sub setContext(ByVal context As String)
                Me.m_context = context
            End Sub

            Private m_token As String

            ''' <summary>
            ''' Token is the encrypted Web Authentication token containing
            ''' the UID. This can be cached in a cookie and the UID can be
            ''' retrieved by calling the ProcessToken method.
            ''' </summary>
            Public ReadOnly Property Token() As String
                Get
                    Return m_token
                End Get
            End Property

            Private Sub setToken(ByVal token As String)
                Me.m_token = token
            End Sub
        End Class

        ''' <summary>
        ''' Initialize the WindowsLiveLogin module with the
        ''' application ID and secret key.
        '''
        ''' We recommend that you employ strong measures to protect
        ''' the secret key. The secret key should never be
        ''' exposed to the Web or other users.
        ''' </summary>
        Public Sub New(ByVal appId As [String], ByVal secret As [String])
            Me.New(appId, secret, Nothing)
        End Sub

        ''' <summary>
        ''' Initialize the WindowsLiveLogin module with the
        ''' application ID, secret key, and security algorithm to use.
        '''
        ''' We recommend that you employ strong measures to protect
        ''' the secret key. The secret key should never be
        ''' exposed to the Web or other users.
        ''' </summary>
        Public Sub New(ByVal appId__1 As [String], ByVal secret__2 As [String], ByVal securityAlgorithm__3 As [String])
            AppId = appId__1
            Secret = secret__2
            SecurityAlgorithm = securityAlgorithm__3
        End Sub

        ''' <summary>
        ''' Initialize the WindowsLiveLogin module from the
        ''' web.config file if loadAppSettings is true. Otherwise,
        ''' you will have to manually set the AppId, Secret and
        ''' SecurityAlgorithm properties.
        ''' </summary>
        Public Sub New(ByVal loadAppSettings As Boolean)
            If Not loadAppSettings Then
                Exit Sub
            End If

            Dim appSettings As NameValueCollection = WebConfigurationManager.AppSettings
            If appSettings Is Nothing Then
                Throw New IOException("Error: WindowsLiveLogin: Failed to load the Web application settings.")
            End If

            AppId = appSettings("wll_appid")
            Secret = appSettings("wll_secret")
            SecurityAlgorithm = appSettings("wll_securityalgorithm")
            BaseUrl = appSettings("wll_baseurl")
            SecureUrl = appSettings("wll_secureurl")
        End Sub

        ''' <summary><![CDATA[
        ''' Initialize the WindowsLiveLogin module from a settings file. 
        ''' 
        ''' 'settingsFile' specifies the location of the XML settings
        ''' file containing the application ID, secret key, and an optional
        ''' security algorithm. The file is of the following format:
        ''' 
        ''' <windowslivelogin>
        ''' <appid>APPID</appid>
        ''' <secret>SECRET</secret>
        ''' <securityalgorithm>wsignin1.0</securityalgorithm>
        ''' </windowslivelogin>
        ''' 
        ''' We recommend that you store the Windows Live Login settings file
        ''' in an area on your server that cannot be accessed through
        ''' the Internet. This file contains important confidential
        ''' information. 
        ''' ]]></summary>
        Public Sub New(ByVal settingsFile As String)
            Dim settings As NameValueCollection = parseSettings(settingsFile)
            AppId = settings("appid")
            Secret = settings("secret")
            SecurityAlgorithm = settings("securityalgorithm")
            BaseUrl = settings("baseurl")
            SecureUrl = settings("secureurl")
        End Sub

        Private m_appId As String

        ''' <summary>
        ''' You can use this property to get or set the application ID.
        ''' </summary>
        Public Property AppId() As String



            Get
                If m_appId Is Nothing OrElse m_appId.Length = 0 Then
                    Throw New InvalidOperationException("Error: AppId: Application ID was not set. Aborting.")
                End If

                Return m_appId
            End Get
            Set(ByVal value As String)
                If value Is Nothing OrElse value.Length = 0 Then
                    Throw New ArgumentNullException("value")
                End If
                Dim re As New Regex("^\w+$")
                If Not re.IsMatch(value) Then
                    Throw New ArgumentException("Error: AppId: Application ID must be alphanumeric: " & value)
                End If
                m_appId = value
            End Set
        End Property

        Private cryptKey As Byte()
        Private signKey As Byte()

        ''' <summary>
        ''' You can use this method to set your secret key if
        ''' one was not provided at initialization time.
        ''' </summary>
        Public Property Secret() As String



            Get
                Return Nothing
            End Get
            Set(ByVal value As String)
                If value Is Nothing OrElse value.Length = 0 Then
                    Throw New ArgumentNullException("value")
                End If
                If value.Length < 16 Then
                    Throw New ArgumentException("Error: Secret: Secret key is expected to be longer than 16 characters: " & value.Length)
                End If
                cryptKey = derive(value, "ENCRYPTION")
                signKey = derive(value, "SIGNATURE")
            End Set
        End Property

        Private m_securityAlgorithm As String

        ''' <summary>
        ''' This property gets or sets the security algorithm being
        ''' used.
        ''' </summary>
        Public Property SecurityAlgorithm() As String

            Get
                If (m_securityAlgorithm Is Nothing) OrElse (m_securityAlgorithm.Length = 0) Then
                    Return "wsignin1.0"
                End If

                Return m_securityAlgorithm
            End Get
            Set(ByVal value As String)
                m_securityAlgorithm = value
            End Set
        End Property

        Private m_baseUrl As String

        ''' <summary>
        ''' Sets the URL to use for the Windows Live Login server. You
        ''' should not have to use or change this. Furthermore, we
        ''' recommend that you use the Sign In control instead of
        ''' the URL methods provided here.
        ''' </summary>
        Public Property BaseUrl() As String

            Get
                If (m_baseUrl Is Nothing) OrElse (m_baseUrl.Length = 0) Then
                    Return "http://login.live.com/"
                End If

                Return m_baseUrl
            End Get
            Set(ByVal value As String)
                m_baseUrl = value
            End Set
        End Property

        Private m_secureUrl As String

        ''' <summary>
        ''' Set the secure (HTTPS) URL to use for the Windows Live Login server.
        ''' You should not have to use or change this directly.
        ''' </summary>
        Public Property SecureUrl() As String

            Get
                If (m_secureUrl Is Nothing) OrElse (m_secureUrl.Length = 0) Then
                    Return "https://login.live.com/"
                End If

                Return m_secureUrl
            End Get
            Set(ByVal value As String)
                m_secureUrl = value
            End Set
        End Property

        ''' <summary>
        ''' Processes the login response from the Windows Live Login server.
        ''' </summary>
        '''
        ''' <param name="query">Contains the preprocessed POST query
        ''' such as that returned by HttpRequest.Form</param>
        ''' 
        ''' <returns>The method returns a User object on successful
        ''' sign-in; otherwise null.</returns>
        Public Function ProcessLogin(ByVal query As NameValueCollection) As User
            If query Is Nothing Then
                debug("Error: ProcessLogin: Invalid query.")
                Return Nothing
            End If

            Dim action As String = query("action")

            If action <> "login" Then
                debug("Warning: ProcessLogin: query action ignored: " & action)
                Return Nothing
            End If

            Dim token As String = query("stoken")
            Dim context As String = query("appctx")

            If context IsNot Nothing Then
                context = HttpUtility.UrlDecode(context)
            End If

            Return ProcessToken(token, context)
        End Function

        ''' <summary>
        ''' Returns the sign-in URL to use for the Windows Live Login server.
        ''' We recommend that you use the Sign In control instead.
        ''' </summary>
        ''' <returns>Sign-in URL</returns>
        Public Function GetLoginUrl() As String
            Return GetLoginUrl(Nothing)
        End Function

        ''' <summary>
        ''' Returns the sign-in URL to use for the Windows Live Login server.
        ''' We recommend that you use the Sign In control instead.
        ''' </summary>
        ''' <param name="context">If you specify it, <paramref
        ''' name="context"/> will be returned as-is in the login
        ''' response for site-specific use.</param>
        ''' <returns>Sign-in URL</returns>
        Public Function GetLoginUrl(ByVal context As String) As String
            Dim algPart As String = "&alg=" & SecurityAlgorithm
            Dim contextPart As String = If((context Is Nothing), [String].Empty, "&appctx=" & HttpUtility.UrlEncode(context))
            Return (BaseUrl & "wlogin.srf?appid=") + AppId + algPart + contextPart
        End Function

        ''' <summary>
        ''' Returns the sign-out URL to use for the Windows Live Login server.
        ''' We recommend that you use the Sign In control instead.
        ''' </summary>
        ''' <returns>Sign-out URL</returns>
        Public Function GetLogoutUrl() As String
            Return (BaseUrl & "logout.srf?appid=") + AppId
        End Function

        ''' <summary>
        ''' Decodes and validates a Web Authentication token. Returns a User
        ''' object on success.
        ''' </summary>
        Public Function ProcessToken(ByVal token As String) As User
            Return ProcessToken(token, Nothing)
        End Function

        ''' <summary>
        ''' Decodes and validates a Web Authentication token. Returns a User
        ''' object on success. If a context is passed in, it will be
        ''' returned as the context field in the User object.
        ''' </summary>
        Public Function ProcessToken(ByVal token As String, ByVal context As String) As User
            If token Is Nothing OrElse token.Length = 0 Then
                debug("Error: ProcessToken: Invalid token.")
                Return Nothing
            End If

            Dim stoken As String = DecodeToken(token)
            If stoken Is Nothing OrElse stoken.Length = 0 Then
                debug("Error: ProcessToken: Failed to decode token: " & token)
                Return Nothing
            End If

            stoken = ValidateToken(stoken)
            If stoken Is Nothing OrElse stoken.Length = 0 Then
                debug("Error: ProcessToken: Failed to validate token: " & token)
                Return Nothing
            End If

            Dim parsedToken As NameValueCollection = HttpUtility.ParseQueryString(stoken)
            If parsedToken Is Nothing OrElse parsedToken.Count < 3 Then
                debug("Error: ProcessToken: Failed to parse token after decoding: " & token)
                Return Nothing
            End If

            Dim appId__1 As String = parsedToken("appid")
            If appId__1 <> AppId Then
                debug(("Error: ProcessToken: Application ID in token did not match ours: " & appId__1 & ", ") + AppId)
                Return Nothing
            End If

            Dim user As User = Nothing
            Try
                user = New User(parsedToken("ts"), parsedToken("uid"), parsedToken("flags"), context, token)
            Catch e As Exception
                debug("Error: ProcessToken: Contents of token considered invalid: " & e.Message)
            End Try
            Return user
        End Function

        ''' <summary>
        ''' When a user signs out of Windows Live or a Windows Live
        ''' application, a best-effort attempt is made to sign the user out
        ''' from all other Windows Live applications the user might be signed
        ''' in to. This is done by calling the handler page for each
        ''' application with 'action' parameter set to 'clearcookie' in the query
        ''' string. The application handler is then responsible for clearing
        ''' any cookies or data associated with the login. After successfully
        ''' signing the user out, the handler should return a GIF (any
        ''' GIF) as response to the action=clearcookie query.
        '''
        ''' This function returns an appropriate content type and body
        ''' response that the application handler can return to
        ''' signify a successful sign-out from the application.
        ''' </summary>
        Public Sub GetClearCookieResponse(ByRef type As String, ByRef content As Byte())
            Const gif As String = "R0lGODlhAQABAIAAAAAAAP///yH5BAEAAAEALAAAAAABAAEAAAIBTAA7"
            type = "image/gif"
            content = Convert.FromBase64String(gif)
        End Sub

        ''' <summary>
        ''' Decode the given token. Returns null on failure.
        ''' </summary>
        '''
        ''' <list type="number">
        ''' <item>First, the string is URL unescaped and base64
        ''' decoded.</item>
        ''' <item>Second, the IV is extracted from the first 16 bytes
        ''' of the string.</item>
        ''' <item>Finally, the string is decrypted by using the
        ''' encryption key.</item> 
        ''' </list>
        Public Function DecodeToken(ByVal token As String) As String
            If cryptKey Is Nothing OrElse cryptKey.Length = 0 Then
                Throw New InvalidOperationException("Error: DecodeToken: Secret key was not set. Aborting.")
            End If

            Const ivLength As Integer = 16
            Dim ivAndEncryptedValue As Byte() = u64(token)

            If (ivAndEncryptedValue Is Nothing) OrElse (ivAndEncryptedValue.Length <= ivLength) OrElse ((ivAndEncryptedValue.Length Mod ivLength) <> 0) Then
                debug("Error: DecodeToken: Attempted to decode invalid token.")
                Return Nothing
            End If

            Dim aesAlg As Rijndael = Nothing
            Dim memStream As MemoryStream = Nothing
            Dim cStream As CryptoStream = Nothing
            Dim sReader As StreamReader = Nothing
            Dim decodedValue As String = Nothing

            Try
                aesAlg = New RijndaelManaged()
                aesAlg.KeySize = 128
                aesAlg.Key = cryptKey
                aesAlg.Padding = PaddingMode.PKCS7
                memStream = New MemoryStream(ivAndEncryptedValue)
                Dim iv As Byte() = New Byte(ivLength - 1) {}
                memStream.Read(iv, 0, ivLength)
                aesAlg.IV = iv
                cStream = New CryptoStream(memStream, aesAlg.CreateDecryptor(), CryptoStreamMode.Read)
                sReader = New StreamReader(cStream, Encoding.ASCII)
                decodedValue = sReader.ReadToEnd()
            Catch e As Exception
                debug("Error: DecodeToken: Decryption failed: " & e.Message)
                Return Nothing
            Finally
                Try
                    If sReader IsNot Nothing Then
                        sReader.Close()
                    End If
                    If cStream IsNot Nothing Then
                        cStream.Close()
                    End If
                    If memStream IsNot Nothing Then
                        memStream.Close()
                    End If
                    If aesAlg IsNot Nothing Then
                        aesAlg.Clear()
                    End If
                Catch e As Exception
                    debug("Error: DecodeToken: Failure during resource cleanup: " & e.Message)
                End Try
            End Try

            Return decodedValue
        End Function

        ''' <summary>
        ''' Creates a signature for the given string by using the
        ''' signature key.
        ''' </summary>
        Public Function SignToken(ByVal token As String) As Byte()
            If signKey Is Nothing OrElse signKey.Length = 0 Then
                Throw New InvalidOperationException("Error: SignToken: Secret key was not set. Aborting.")
            End If

            If (token Is Nothing) OrElse (token.Length = 0) Then
                debug("Attempted to sign null token.")
                Return Nothing
            End If

            Using hashAlg As HashAlgorithm = New HMACSHA256(signKey)
                Dim data As Byte() = Encoding.[Default].GetBytes(token)
                Dim hash As Byte() = hashAlg.ComputeHash(data)
                Return hash
            End Using
        End Function

        ''' <summary>
        ''' Extracts the signature from the token and validates it.
        ''' </summary>
        Public Function ValidateToken(ByVal token As String) As String
            If token Is Nothing OrElse token.Length = 0 Then
                debug("Error: ValidateToken: Invalid token.")
                Return Nothing
            End If

            Dim s As String() = {"&sig="}
            Dim bodyAndSig As String() = token.Split(s, StringSplitOptions.None)

            If bodyAndSig.Length <> 2 Then
                debug("Error: ValidateToken: Invalid token: " & token)
                Return Nothing
            End If

            Dim sig As Byte() = u64(bodyAndSig(1))

            If sig Is Nothing Then
                debug("Error: ValidateToken: Could not extract the signature from the token.")
                Return Nothing
            End If

            Dim sig2 As Byte() = SignToken(bodyAndSig(0))

            If sig2 Is Nothing Then
                debug("Error: ValidateToken: Could not generate a signature for the token.")
                Return Nothing
            End If

            If sig.Length = sig2.Length Then
                For i As Integer = 0 To sig.Length - 1
                    If sig(i) <> sig2(i) Then
                        GoTo badSig
                    End If
                Next

                Return token
            End If
badSig:

            debug("Error: ValidateToken: Signature did not match.")
            Return Nothing
        End Function

        ' Implementation of the methods needed to perform Windows Live
        ' application verification as well as trusted login. 


        ''' <summary>
        ''' Generates an Application Verifier token.
        ''' </summary>
        Public Function GetAppVerifier() As String
            Return GetAppVerifier(Nothing)
        End Function

        ''' <summary>
        ''' Generates an Application Verifier token. An IP address
        ''' can be included in the token.
        ''' </summary>
        Public Function GetAppVerifier(ByVal ip As String) As String
            Dim ipPart As String = If((ip Is Nothing), [String].Empty, ("&ip=" & ip))
            Dim token As String = ("appid=" & AppId & "&ts=") + getTimestamp() + ipPart
            Dim sig As String = e64(SignToken(token))

            If sig Is Nothing Then
                debug("Error: GetAppVerifier: Failed to sign the token.")
                Return Nothing
            End If

            token += "&sig=" & sig
            Return HttpUtility.UrlEncode(token)
        End Function

        ''' <summary>
        ''' Returns the URL needed to retrieve the application
        ''' security token. The application security token
        ''' will be generated for the Windows Live site.
        '''
        ''' JavaScript Output Notation (JSON) output is returned:
        '''
        ''' {"token":"<value>"}
        ''' </summary>
        Public Function GetAppLoginUrl() As String
            Return GetAppLoginUrl(Nothing, Nothing, False)
        End Function

        ''' <summary>
        ''' Returns the URL needed to retrieve the application
        ''' security token.
        '''
        ''' By default, the application security token will be
        ''' generated for the Windows Live site; a specific Site ID
        ''' can optionally be specified in 'siteId'.
        '''
        ''' JSON output is returned:
        '''
        ''' {"token":"<value>"}
        ''' </summary>
        Public Function GetAppLoginUrl(ByVal siteId As String) As String
            Return GetAppLoginUrl(siteId, Nothing, False)
        End Function

        ''' <summary>
        ''' Returns the URL needed to retrieve the application
        ''' security token.
        '''
        ''' By default, the application security token will be
        ''' generated for the Windows Live site; a specific Site ID
        ''' can optionally be specified in 'siteId'. The IP address
        ''' can also optionally be included in 'ip'.
        '''
        ''' JSON output is returned:
        '''
        ''' {"token":"<value>"}
        ''' </summary>
        Public Function GetAppLoginUrl(ByVal siteId As String, ByVal ip As String) As String
            Return GetAppLoginUrl(siteId, ip, False)
        End Function

        ''' <summary>
        ''' Returns the URL needed to retrieve the application
        ''' security token.
        '''
        ''' By default, the application security token will be
        ''' generated for the Windows Live site; a specific Site ID
        ''' can optionally be specified in 'siteId'. The IP address
        ''' can also optionally be included in 'ip'.
        '''
        ''' If 'js' is false, then JSON output is returned: 
        '''
        ''' {"token":"<value>"}
        '''
        ''' Otherwise, a JavaScript response is returned. It is assumed
        ''' that WLIDResultCallback is a custom function implemented to
        ''' handle the token value:
        ''' 
        ''' WLIDResultCallback("<tokenvalue>");
        ''' </summary>
        Public Function GetAppLoginUrl(ByVal siteId As String, ByVal ip As String, ByVal js As Boolean) As String
            Dim algPart As String = "&alg=" & SecurityAlgorithm
            Dim sitePart As String = If((siteId Is Nothing), "", "&id=" & siteId)
            Dim jsPart As String = If((Not js), [String].Empty, "&js=1")
            Dim url As String = (SecureUrl & "wapplogin.srf?app=") + GetAppVerifier(ip) + algPart + sitePart + jsPart
            Return url
        End Function

        ''' <summary>
        ''' Retrieves the application security token for application
        ''' verification from the application login URL. The
        ''' application security token will be generated for the
        ''' Windows Live site.
        ''' </summary>
        Public Function GetAppSecurityToken() As String
            Return GetAppSecurityToken(Nothing, Nothing)
        End Function

        ''' <summary>
        ''' Retrieves the application security token for application
        ''' verification from the application login URL.
        '''
        ''' By default, the application security token will be
        ''' generated for the Windows Live site; a specific Site ID
        ''' can optionally be specified in 'siteId'.
        ''' </summary>
        Public Function GetAppSecurityToken(ByVal siteId As String) As String
            Return GetAppSecurityToken(siteId, Nothing)
        End Function

        ''' <summary>
        ''' Retrieves the application security token for application
        ''' verification from the application login URL.
        '''
        ''' By default, the application security token will be
        ''' generated for the Windows Live site; a specific Site ID
        ''' can optionally be specified in 'siteId'. The IP address
        ''' can also optionally be included in 'ip'.
        '''
        ''' Implementation note: The application security token is
        ''' downloaded from the application login URL in JSON format
        ''' {"token":"<value>"}, so we need to extract
        ''' <value> from the string and return it as seen here.
        ''' </summary>
        Public Function GetAppSecurityToken(ByVal siteId As String, ByVal ip As String) As String
            Dim url As String = GetAppLoginUrl(siteId, ip)
            Dim body As String = fetch(url)
            If body Is Nothing Then
                debug("Error: GetAppSecurityToken: Failed to download token.")
                Return Nothing
            End If

            Dim re As New Regex("{""token"":""(.*)""}")
            Dim gc As GroupCollection = re.Match(body).Groups

            If gc.Count <> 2 Then
                debug("Error: GetAppSecurityToken: Failed to extract token: " & body)
                Return Nothing
            End If

            Dim cc As CaptureCollection = gc(1).Captures

            If cc.Count <> 1 Then
                debug("Error: GetAppSecurityToken: Failed to extract token: " & body)
                Return Nothing
            End If

            Return cc(0).ToString()
        End Function

        ''' <summary>
        ''' Returns a string that can be passed to the GetTrustedParams
        ''' function as the 'retcode' parameter. If this is specified as
        ''' the 'retcode', then the app will be used as return URL
        ''' after it finishes trusted login. 
        ''' </summary>
        Public Function GetAppRetCode() As String
            Return "appid=" & AppId
        End Function

        ''' <summary>
        ''' Returns a table of key-value pairs that must be posted to
        ''' the login URL for trusted login. Use HTTP POST to do
        ''' this. Be aware that the values in the table are neither
        ''' URL nor HTML escaped and may have to be escaped if you are
        ''' inserting them in code such as an HTML form.
        ''' 
        ''' The user to be trusted on the local site is passed in as
        ''' string 'user'.
        ''' </summary>
        Public Function GetTrustedParams(ByVal user As String) As NameValueCollection
            Return GetTrustedParams(user, Nothing)
        End Function

        ''' <summary>
        ''' Returns a table of key-value pairs that must be posted to
        ''' the login URL for trusted login. Use HTTP POST to do
        ''' this. Be aware that the values in the table are neither
        ''' URL nor HTML escaped and may have to be escaped if you are
        ''' inserting them in code such as an HTML form.
        ''' 
        ''' The user to be trusted on the local site is passed in as
        ''' string 'user'.
        ''' 
        ''' Optionally, 'retcode' specifies the resource to which
        ''' successful login is redirected, such as Windows Live Mail,
        ''' and is typically a string in the format 'id=2000'. If you
        ''' pass in the value from GetAppRetCode instead, login will
        ''' be redirected to the application. Otherwise, an HTTP 200
        ''' response is returned.
        ''' </summary>
        Public Function GetTrustedParams(ByVal user As String, ByVal retcode As String) As NameValueCollection
            Dim token As String = GetTrustedToken(user)

            If token Is Nothing Then
                Return Nothing
            End If

            token = "<wst:RequestSecurityTokenResponse xmlns:wst=""http://schemas.xmlsoap.org/ws/2005/02/trust""><wst:RequestedSecurityToken><wsse:BinarySecurityToken xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">" & token & "</wsse:BinarySecurityToken></wst:RequestedSecurityToken><wsp:AppliesTo xmlns:wsp=""http://schemas.xmlsoap.org/ws/2004/09/policy""><wsa:EndpointReference xmlns:wsa=""http://schemas.xmlsoap.org/ws/2004/08/addressing""><wsa:Address>uri:WindowsLiveID</wsa:Address></wsa:EndpointReference></wsp:AppliesTo></wst:RequestSecurityTokenResponse>"

            Dim nvc As New NameValueCollection(3)
            nvc("wa") = SecurityAlgorithm
            nvc("wresult") = token

            If retcode IsNot Nothing Then
                nvc("wctx") = retcode
            End If

            Return nvc
        End Function

        ''' <summary>
        ''' Returns the trusted login token in the format needed by the
        ''' trusted login gadget.
        '''
        ''' User to be trusted on the local site is passed in as string
        ''' 'user'.
        ''' </summary>
        Public Function GetTrustedToken(ByVal user As String) As String
            If user Is Nothing OrElse user.Length = 0 Then
                debug("Error: GetTrustedToken: Invalid user specified.")
                Return Nothing
            End If

            Dim token As String = (("appid=" & AppId & "&uid=") + HttpUtility.UrlEncode(user) & "&ts=") + getTimestamp()
            Dim sig As String = e64(SignToken(token))

            If sig Is Nothing Then
                debug("Error: GetTrustedToken: Failed to sign the token.")
                Return Nothing
            End If

            token += "&sig=" & sig
            Return HttpUtility.UrlEncode(token)
        End Function

        ''' <summary>
        ''' Returns the trusted sign-in URL to use for the Windows Live
        ''' Login server. 
        ''' </summary>
        Public Function GetTrustedLoginUrl() As String
            Return SecureUrl & "wlogin.srf"
        End Function

        ''' <summary>
        ''' Returns the trusted sign-out URL to use for the Windows Live
        ''' Login server. 
        ''' </summary>
        Public Function GetTrustedLogoutUrl() As String
            Return (SecureUrl & "logout.srf?appid=") + AppId
        End Function

        ' Helper methods 


        Private Shared Function parseSettings(ByVal settingsFile As String) As NameValueCollection
            If settingsFile Is Nothing Then
                Throw New ArgumentNullException("settingsFile")
            End If

            Dim settings As New NameValueCollection()

            ' Throws an exception on any failure.
            Dim xd As New XmlDocument()
            xd.Load(settingsFile)

            Dim appIdNode As XmlNode = xd.SelectSingleNode("//windowslivelogin/appid")
            Dim appId As [String] = If((appIdNode Is Nothing), Nothing, appIdNode.InnerText)
            If appId Is Nothing OrElse appId.Length = 0 Then
                Throw New XmlException("Error: parseSettings: Could not read appid node in settings file: " & settingsFile)
            End If
            settings("appid") = appId

            Dim secretNode As XmlNode = xd.SelectSingleNode("//windowslivelogin/secret")
            Dim secret As [String] = If((secretNode Is Nothing), Nothing, secretNode.InnerText)
            If secret Is Nothing OrElse secret.Length = 0 Then
                Throw New XmlException("Error: parseSettings: Could not read secret node in settings file: " & settingsFile)
            End If
            settings("secret") = secret

            Dim securityAlgorithmNode As XmlNode = xd.SelectSingleNode("//windowslivelogin/securityalgorithm")
            settings("securityalgorithm") = If((securityAlgorithmNode Is Nothing), Nothing, securityAlgorithmNode.InnerText)

            Dim baseUrlNode As XmlNode = xd.SelectSingleNode("//windowslivelogin/baseurl")
            settings("baseurl") = If((baseUrlNode Is Nothing), Nothing, baseUrlNode.InnerText)

            Dim secureUrlNode As XmlNode = xd.SelectSingleNode("//windowslivelogin/secureurl")
            settings("secureurl") = If((secureUrlNode Is Nothing), Nothing, secureUrlNode.InnerText)
            Return settings
        End Function

        ''' <summary>
        ''' Derives the signature or encryption key, given the secret key 
        ''' and prefix as described in the SDK documentation.
        ''' </summary>
        Private Shared Function derive(ByVal secret As String, ByVal prefix As String) As Byte()
            Using hashAlg As HashAlgorithm = HashAlgorithm.Create("SHA256")
                Const keyLength As Integer = 16
                Dim data As Byte() = Encoding.[Default].GetBytes(prefix + secret)
                Dim hashOutput As Byte() = hashAlg.ComputeHash(data)
                Dim byteKey As Byte() = New Byte(keyLength - 1) {}
                Array.Copy(hashOutput, byteKey, keyLength)
                Return byteKey
            End Using
        End Function

        ''' <summary>
        ''' Generates a timestamp suitable for the application
        ''' verifier token.
        ''' </summary>
        Private Shared Function getTimestamp() As String
            Dim refTime As New DateTime(1970, 1, 1, 0, 0, 0, _
            DateTimeKind.Utc)
            Dim ts As TimeSpan = DateTime.UtcNow - refTime
            Return CUInt(ts.TotalSeconds).ToString()
        End Function

        ''' <summary>
        ''' Base64-encode and URL-escape a byte array.
        ''' </summary>
        Private Shared Function e64(ByVal b As Byte()) As String
            Dim s As String = Nothing
            If b Is Nothing Then
                Return s
            End If

            Try
                s = Convert.ToBase64String(b)
                s = HttpUtility.UrlEncode(s)
            Catch e As Exception
                debug("Error: e64: Base64 conversion error: " & e.Message)
            End Try

            Return s
        End Function

        ''' <summary>
        ''' URL-unescape and Base64-decode a string.
        ''' </summary>
        Private Shared Function u64(ByVal s As String) As Byte()
            Dim b As Byte() = Nothing
            If s Is Nothing Then
                Return b
            End If
            s = HttpUtility.UrlDecode(s)

            Try
                b = Convert.FromBase64String(s)
            Catch e As Exception
                debug(("Error: u64: Base64 conversion error: " & s & ", ") & e.Message)
            End Try
            Return b
        End Function

        ''' <summary>
        ''' Fetch the contents given a URL.
        ''' </summary>
        Private Shared Function fetch(ByVal url As String) As String
            Dim body As String = Nothing
            Try
                Dim req As WebRequest = HttpWebRequest.Create(url)
                req.Method = "GET"
                Dim res As WebResponse = req.GetResponse()
                Using sr As New StreamReader(res.GetResponseStream(), Encoding.UTF8)
                    body = sr.ReadToEnd()
                End Using
            Catch e As Exception
                debug(("Error: fetch: Failed to get the document: " & url & ", ") & e.Message)
            End Try
            Return body
        End Function
    End Class
End Namespace