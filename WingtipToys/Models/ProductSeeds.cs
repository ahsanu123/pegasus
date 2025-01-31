using System.Collections.Generic;

namespace WingtipToys.Models
{
    public static class ProductSeed
    {
        public static List<Product> PredefinedProduct = new List<Product>
        {
            new Product { 
                Name = "Red Apples" ,
                ImageUrl="https://images.squarespace-cdn.com/content/v1/5c5310c785ede1e27998bbb0/1631737558831-ZJ13HCOWDBXV5BFNTB3E/Apple+Anatomy+with+Labels.jpeg",
                Description="Apples are round, fleshy fruits that grow on trees and come in many colors, sizes, and flavors. They are a good source of fiber, vitamins A and C, and antioxidants",
                Type="Fruit",
                UnitPrice=2
            },
            new Product { 
                Name = "Strawberry" ,
                ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/4/4c/Garden_strawberry_%28Fragaria_%C3%97_ananassa%29_single2.jpg/800px-Garden_strawberry_%28Fragaria_%C3%97_ananassa%29_single2.jpg",
                Description="A strawberry is both a low-growing, flowering plant and also the name of the fruit that it produces. Strawberries are soft, sweet, bright red berries. They're also delicious. Strawberries have tiny edible seeds, which grow all over their surface.",
                Type="Fruit",
                UnitPrice=1
            },
            new Product { 
                Name = "Cabbage" ,
                ImageUrl="https://www.kroger.com/product/images/large/front/0000000004555",
                Description="Cabbage (Brassica oleracea) is a cruciferous vegetable. It is a leafy green or purple biennial plant, grown as an annual vegetable crop for its dense-leaved heads.",
                Type="Vegetables",
                UnitPrice=2
            },
            new Product { 
                Name = "Egg Plant" ,
                ImageUrl="https://assets.epicurious.com/photos/62bdec79393b88c262b9318d/4:3/w_5535,h_4151,c_limit/EggplantStorage_HERO_062922_36252.jpg",
                Description="ypically used as a vegetable in cooking, it is a berry by botanical definition. As a member of the genus Solanum, it is related to the tomato, chili pepper",
                Type="Vegetables",
                UnitPrice=2
            },
            new Product { 
                Name = "Watermelon" ,
                ImageUrl="https://cdn.britannica.com/99/143599-050-C3289491/Watermelon.jpg",
                Description="Watermelon is a flowering plant species of the Cucurbitaceae family and the name of its edible fruit. A scrambling and trailing vine-like plant, it is a highly cultivated fruit worldwide, with more than 1,000 varieties.",
                Type="Fruit",
                UnitPrice=2
            },
            new Product { 
                Name = "Durian Fruit" ,
                ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/b/bc/Durian_in_black.jpg/1200px-Durian_in_black.jpg",
                Description="Durian is a tropical fruit with a spiky shell, strong odor, and custard-like flesh. It's native to Southeast Asia and is sometimes called the king of fruits",
                Type="Fruit",
                UnitPrice=2
            },
        };
    }
}
