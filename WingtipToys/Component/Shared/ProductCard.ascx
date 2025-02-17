<%@ Control 
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="ProductCard.ascx.cs"
    Inherits="WingtipToys.CustomControl.ProductCard" %>

<%@ Import Namespace="WingtipToys.CustomControl" %>


<asp:Panel
    ID="PreviewPanel"
    runat="server">

    <div class="product-card">

        <div>
            <img alt="<%#: Product.Name %>"
                src="<%#: Product.ImageUrl %>"
                />
        </div>
        <div>
            <sub><%#: Product.Type %></sub>

            <div class="properties">
                <b><%#: Product.Name %> - $<%#: Product.UnitPrice %></b>
            </div>

            <p class="description">
                <%#: Product.Description %>
            </p>
        </div>
        <asp:Button 
            CommandArgument="<%# Product.Id %>"
            CommandName="<%# ProductCardItemCommandArgs.Edit %>"
            OnCommand="HandleButtonClicked"
            Text="Edit"
            runat="server"/>


    </div>

</asp:Panel>

<asp:Panel
    ID="EditPanel"
    runat="server">

    <div class="product-card">

        <div>
            <h4>Its Edit Panel</h4>
            <img 
                alt="<%#: Product.Name %>"
                src="<%#: Product.ImageUrl %>"
                />
        </div>
        <div>
            <sub><%#: Product.Type %></sub>

            <div class="properties">
                <b><%#: Product.Name %> - $<%#: Product.UnitPrice %></b>
            </div>

            <p class="description">
                <%#: Product.Description %>
            </p>
        </div>

        <asp:Button 
            CommandArgument="<%# Product.Id %>"
            CommandName="<%# ProductCardItemCommandArgs.Cancel %>"
            OnCommand="HandleButtonClicked"
            Text="Cancel"
            runat="server"/>

        <asp:Button 
            CommandArgument="<%# Product.Id %>"
            CommandName="<%# ProductCardItemCommandArgs.Save %>"
            OnCommand="HandleButtonClicked"
            Text="Save"
            runat="server"/>

        <asp:Button 
            CommandArgument="<%# Product.Id %>"
            CommandName="<%# ProductCardItemCommandArgs.Delete %>"
            OnCommand="HandleButtonClicked"
            Text="Delete"
            runat="server"/>

    </div>

</asp:Panel>
