module clientSitePages.PizzasBlock

type PizzasBlock() =
    static member pizzasList = "#pizzas div[class*='with-controls']"
    static member pizzaName = "[class*='product__name']";
    static member pizzaDescription = "[class*='product__description']"
    static member pizzaSizes = "[class$='product__size'] [class$='item']"
    static member pizzasDoughTypes = "[class$='dough-selector'] [class*='item']"
    static member addToCart = "[class$=to-cart] button"
