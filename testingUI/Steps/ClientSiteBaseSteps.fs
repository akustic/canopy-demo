module steps.ClientSiteBaseSteps

open canopy
open clientSitePages.MainPage
open clientSitePages.PizzasBlock
open clientSitePages.DeliverySelectionPoup
open clientSitePages.CartPage
open System
open OpenQA.Selenium
open System.Collections.ObjectModel
open clientSitePages
open helpers.CanopyOverloading


let arePizzasLoaded() =
    (unreliableElements "[class$='product__size'] [class$='item']").Length > 0

let isPageLoaded() =
  for i in 1 .. 5 do
    waitFor  arePizzasLoaded
  sleep 1
    
let ClickOnOneInList = (fun (elementsList: ReadOnlyCollection<IWebElement>) ->
  let lastIndex = elementsList.Count-1
  let index = Random().Next(0, lastIndex);
  let element = elementsList.Item(index);
  System.String.Concat("Выбираю: ", element.Text ) |> describe
  isPageLoaded();
  sleep 1
  click(element)
)

let SelectElementsFromForm = (fun (form: IWebElement, locatorCss: string) -> 
    form.FindElements(By.CssSelector(locatorCss))
) 

let AddToCart = (fun (pizza: IWebElement) ->
    describe "Добавляю пиццу в корзину"
    pizza.FindElement(By.CssSelector(PizzasBlock.addToCart)).Click();
)

let AddRandomPizzaToCart =  (fun () ->
    click MainPage.pizzasLink
    let pizzasNames =  (unreliableElements PizzasBlock.pizzaName);
    let pizzasCount = (unreliableElements PizzasBlock.pizzasList).Length-1
    let indexRandomPizza = Random().Next(0, pizzasCount);
    System.String.Concat("Выбираю пиццу: ", pizzasNames.Item(indexRandomPizza).Text) |> describe
    let pizza = (unreliableElements PizzasBlock.pizzasList).Item(indexRandomPizza)
    let pizzasSizesButtons = SelectElementsFromForm(pizza, PizzasBlock.pizzaSizes)
    ClickOnOneInList(pizzasSizesButtons)
    let pizzasTypesButtons =  SelectElementsFromForm(pizza, PizzasBlock.pizzasDoughTypes)
    ClickOnOneInList(pizzasTypesButtons)
    AddToCart(pizza)
    pizzasNames.Item(indexRandomPizza).Text
)

let OpenPage = (fun (pageUrl: string) ->
    System.String.Concat("Открываю страницу с URL:", pageUrl) |> describe
    url pageUrl
)

let GoToCart = (fun () ->
    describe "Перехожу в корзину"
    click MainPage.cartButton
)

let SelectCarryOut = (fun () ->
    describe "Выбираю любую пиццерию для самовывоза"
    sleep 3
    click ((unreliableElements DeliverySelectionPopup.deliveryTypesLinks).Item(1))
    click ((unreliableElements DeliverySelectionPopup.storesRadioList).Item(1))
    click DeliverySelectionPopup.chooseButton
    sleep 1
)

let CheckPizzaInCart = (fun (pizzaName: string) ->
     System.String.Concat("Проверяю наличие в корзине пиццы:", pizzaName) |> describe
     count CartPage.pizzaNames 1
     let pagePizzaName = (unreliableElements CartPage.pizzaNames).Item(0).Text
     isFullEqualityOfTwoStrings (pagePizzaName, pizzaName)
)