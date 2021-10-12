module Tests

open NUnit.Framework
open ParseTree
open FsUnit

[<Test>]
let parseTreeWithValueTest () =
    countParseTree (Value 10) |> should equal 10

[<Test>]
let parseTreeWithAdditionTest () =
    countParseTree (Addition(Value 3, Value 4)) |> should equal 7

[<Test>]
let parseTreeWithMultiplicationTest () =
    countParseTree (Multiplication(Value 3, Value 4)) |> should equal 12

[<Test>]
let parseTreeWithDivisionTest () =
    countParseTree (Division(Value 12, Value 4)) |> should equal 3

[<Test>]
let parseTreeWithSubtractionTest () =
    countParseTree (Subtraction(Value 12, Value 4)) |> should equal 8

[<Test>]
let parseTreeWithExceptionTest () =
    (fun () -> countParseTree (Division(Value 12, Value 0)) |> ignore) |> should throw typeof<System.DivideByZeroException>

[<Test>]
let parseTreeWithLargeTreeTest () =
    countParseTree (Addition(Multiplication(Subtraction(Value 12, Value 4), Value 4), Division(Value 12, Addition(Value 3, Value 4)))) |> should equal 33
