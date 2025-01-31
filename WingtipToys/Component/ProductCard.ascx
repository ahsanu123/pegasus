<%@ Control 
    Language="C#"
    AutoEventWireup="true"
    CodeBehind="ProductCard.ascx.cs"
    Inherits="WingtipToys.CustomControl.ProductCard" %>

<div class="product-card">

    <div>
        <img 
            alt="<%#: Product.Name %>"
            src="<%#: Product.ImageUrl %>"
            />
    </div>
    <div>
        <sub><%#: Product.Type %></sub>

        <div class="properties">
            <b><%#: Product.Name %> - $<%#: Product.UnitPrice %></b>
            <button>➕ Cart</button>
        </div>

        <p class="description">
            <%#: Product.Description %>
        </p>
    </div>

</div>
