module Tests

open NUnit.Framework
open PointFree
open FsCheck


[<Test>]
let mapMultiplicationTest1 () =
    Check.QuickThrowOnFailure(fun x l -> (mapMultiplication x l) = (mapMultiplication1 x l))
    
[<Test>]
let mapMultiplicationTest2 () =
    Check.QuickThrowOnFailure(fun x l -> (mapMultiplication x l) = (mapMultiplication2 x l))

[<Test>]
let mapMultiplicationTest3 () =
    Check.QuickThrowOnFailure(fun x l -> (mapMultiplication x l) = (mapMultiplication3 x l))

[<Test>]
let mapMultiplicationTest4 () =
    Check.QuickThrowOnFailure(fun x l -> (mapMultiplication x l) = (mapMultiplication4 x l))