<%@ Control 
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="ProductCard.ascx.cs"
    Inherits="WingtipToys.CustomControl.ProductCard" %>

<h3>Product Card</h3>

<p> <%= Product.Name%> </p>
<p> <%= Product.UnitPrice%> </p>
<p> <%= Product.Description%> </p>
