module Tests

open AmountOfEvenNumbers
open NUnit.Framework
open FsUnit
open FsCheck



[<Test>]
let amountOfEvenNumbersByMapTest () =
    getAmountOfEvenNumbersByMap [1; 2; 3; 4; 5] |> should equal 2

[<Test>]
let amountOfEvenNumbersByFoldTest () =
    getAmountOfEvenNumbersByFold [2; 3; 8; 9; -122] |> should equal 3

[<Test>]
let amountOfEvenNumbersByFilterTest () =
    getAmountOfEvenNumbersByFilter [] |> should equal 0

[<Test>]
let amountOfEvenNumbersByFilterAndByFoldTest () =
    Check.QuickThrowOnFailure (fun (ls: List<int>) -> (getAmountOfEvenNumbersByFilter ls) = (getAmountOfEvenNumbersByFold ls))

[<Test>]
let amountOfEvenNumbersByFilterAndByMapTest () =
    Check.QuickThrowOnFailure (fun (ls: List<int>) -> (getAmountOfEvenNumbersByFilter ls) = (getAmountOfEvenNumbersByMap ls))
