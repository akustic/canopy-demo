module clientSitePages.MainPage

type MainPage() =
    static member pizzasLink = "a[href*='#pizzas']"
    static member cartButton = "a[href$='cart']"