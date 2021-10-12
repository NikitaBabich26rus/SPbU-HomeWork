module Tests

open NUnit.Framework
open PrimeNumbers
open FsUnit

let testCasesPrimeNumbers =
    [
        4, 11
        2, 5
        1, 3
        3, 7
        9, 29
        47, 223
        59, 281
        30, 127
        24, 97
    ] |> List.map (fun (number, answer) -> TestCaseData(number, answer))


[<Test>]
[<TestCaseSource("testCasesPrimeNumbers")>]
let getASequenceOfPrimeNumbersTest number answer =
    getASequenceOfPrimeNumbers |> Seq.item number |> should equal answer
