<%@ Control 
    Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="TwoWayProductCard.ascx.cs" 
    Inherits="WingtipToys.CustomControl.TwoWayProductCard" %>


<asp:Panel 
    ID="previewPanel"
    runat="server">

    <div>
        <b>Name:</b>
        <asp:Label 
            ID="LabelName"
            runat="server"/>
    </div>
    <div>
        <b>Type:</b>
        <asp:Label 
            ID="LabelType"
            runat="server"/>
    </div>
    <div>
        <b>Description:</b>
        <asp:Label 
            ID="LabelDescription"
            runat="server"/>
    </div>
    <div>
        <b>Image Url:</b>
        <asp:Label 
            ID="LabelImageUrl"
            runat="server"/>
    </div>
    <div>
        <b>Unit Price:</b>
        <asp:Label 
            ID="LabelUnitPrice"
            runat="server"/>
    </div>

</asp:Panel>

<asp:Panel 
    ID="editPanel"
    runat="server">

    <label>
        <b>Name</b>
        <input 
            id="NameInput"
            runat="server"/>
    </label>
    <label>
        <b>Type</b>
        <input 
            id="TypeInput"
            runat="server"/>
    </label>
    <label>
        <b>Description</b>
        <input 
            id="DescriptionInput"
            runat="server"/>
    </label>
    <label>
        <b>Image Url</b>
        <input 
            id="ImageUrlInput"
            runat="server"/>
    </label>
    <label>
        <b>Unit Price</b>
        <input 
            type="number"
            id="UnitPriceInput"
            runat="server"/>
    </label>

</asp:Panel>

<div>

    <button
        onclick="HandleOnEdit"
        id="ButtonEdit"
        runat="server">
        Edit
    </button>
    <button
        onclick="HandleOnSave"
        id="ButtonSave"
        runat="server">
        Save
    </button>
    <button
        onclick="HandleOnCancel"
        id="ButtonCancel"
        runat="server">
        Cancel
    </button>

</div>

