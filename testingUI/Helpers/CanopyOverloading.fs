module helpers.CanopyOverloading

open canopy
open System

let isInList listArray textTemplate =
    let textOfMessage = System.String.Concat("Проверка, что хотя бы один элемент списка содержит значение ", textTemplate)
    describe textOfMessage
    listArray *= textTemplate

let isFullEqualityOfTwoStrings (leftSide: string, rightSide: string)  =
    let textOfMessage = System.String.Concat("Строка ", leftSide, " совпадает со строкой ", rightSide)
    describe textOfMessage
    leftSide === rightSide

let isEqualityOfElementValueAndString value text =
     let textOfMessage = System.String.Concat("Значение элемента совпадает со строкой ", text)
     describe textOfMessage
     value == text

let setValueToElement elementForm value =
    let textOfMessage = System.String.Concat("Установка значения ", value, " в поле ", elementForm)
    describe textOfMessage
    elementForm << value
