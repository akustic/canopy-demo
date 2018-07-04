module clientSitePages.DeliverySelectionPoup

type DeliverySelectionPopup() =
    static member deliveryTypesLinks = "div[class$='popup__tabs'] li"
    static member storesRadioList = "[class$=category]"
    static member chooseButton = "[class$=actions] button"