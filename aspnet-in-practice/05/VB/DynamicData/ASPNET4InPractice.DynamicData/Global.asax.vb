Imports System.Web.Routing
Imports System.Web.DynamicData

Public Class Global_asax
    Inherits HttpApplication

    Private Shared s_defaultModel As New MetaModel
    Public Shared ReadOnly Property DefaultModel() As MetaModel
        Get
            Return s_defaultModel
        End Get
    End Property
    
    Public Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
		DefaultModel.RegisterContext(GetType(NorthwindEntities), New ContextConfiguration() With {.ScaffoldAllTables = True})
    
        ' The following statement supports separate-page mode, where the List, Detail, Insert, and 
        ' Update tasks are performed by using separate pages. To enable this mode, uncomment the following 
        ' route definition, and comment out the route definitions in the combined-page mode section that follows.
        routes.Add(New DynamicDataRoute("{table}/{action}.aspx") With {
            .Constraints = New RouteValueDictionary(New With {.Action = "List|Details|Edit|Insert"}),
            .Model = DefaultModel})
    
        ' The following statements support combined-page mode, where the List, Detail, Insert, and
        ' Update tasks are performed by using the same page. To enable this mode, uncomment the
        ' following routes and comment out the route definition in the separate-page mode section above.
        'routes.Add(New DynamicDataRoute("{table}/ListDetails.aspx") With {
        '    .Action = PageAction.List,
        '    .ViewName = "ListDetails",
        '    .Model = DefaultModel})
    
        'routes.Add(New DynamicDataRoute("{table}/ListDetails.aspx") With {
        '    .Action = PageAction.Details,
        '    .ViewName = "ListDetails",
        '    .Model = DefaultModel})
    End Sub
    
    Private Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
        RegisterRoutes(RouteTable.Routes)
    End Sub
    
End Class
