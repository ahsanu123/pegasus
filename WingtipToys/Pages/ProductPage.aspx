<%@ Page 
    Title="Product Page" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="ProductPage.aspx.cs" 
    EnableEventValidation="false" 
    Inherits="WingtipToys.ProductPage" %>


<asp:Content 
    ID="BodyContent" 
    ContentPlaceHolderID="MainContent" 
    runat="server">

    <h2>
      Product  page
    </h2>   

    <asp:Button
        OnClick="HandleOnAddProduct"
        Text="Add Product"
        runat="server"/> 
    <hr />

    <asp:UpdatePanel
        ID="Updatepanel"
        runat="server">

        <ContentTemplate>
            <asp:Label 
                ID="DebugLabel"
                runat="server"/>

            <asp:Repeater 
                ID="MainRepeater"
                OnItemDataBound="ProductRepeaterOnItemDataBound"
                ItemType="WingtipToys.Models.Product"
                runat="server">

                <ItemTemplate>
                    <controls:ProductCard 
                        ID="ProductCard"
                        Product="<%# Item %>"
                        runat="server"/>
                </ItemTemplate>

            </asp:Repeater>
        </ContentTemplate>

<%--        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="MainRepeater" EventName="ItemCommand"/>
        </Triggers>--%>

    </asp:UpdatePanel>

</asp:Content>
