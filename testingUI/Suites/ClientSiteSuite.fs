module ClientSiteSuite

open canopy

open steps.ClientSiteBaseSteps

let all() =
    context "Заказы с сайта"

    before (fun _ ->
        describe "Открываю браузер на полный экран"
        start chrome
        pin FullScreen
    )

    after (fun _ ->
        describe "Закрываю браузер"
        quit()
    )

    "В корзину можно добавить пиццу" &&& fun _ ->
     OpenPage("https://dodopizza.ru/belgorod/schorsa37a")
     let pizzaName = AddRandomPizzaToCart()
     SelectCarryOut()
     GoToCart()
     CheckPizzaInCart(pizzaName)

