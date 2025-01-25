Imports Microsoft.Web.Mvc.AspNet4

Namespace CoolMvcBlog
    Public Class TimeController
        Inherits System.Web.Mvc.Controller

        Public Function Index() As ActionResult
            ViewData("ParentActionTime") = DateTime.Now.ToLongTimeString

            Return View()
        End Function

        <OutputCache(Duration:=30, VaryByParam:="none")>
        <ChildActionCache(Duration:=30)>
        Public Function CurrentServerTime() As ActionResult
            ViewData("time") = DateTime.Now.ToLongTimeString
            Return View()
        End Function
    End Class
End Namespace