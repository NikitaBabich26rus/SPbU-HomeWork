module Tests

open NUnit.Framework
open FsUnit
open MapForTree

[<Test>]
let mapForTreeSimpleTest () =
    mapForTree (fun x -> x + 1) (Node(5, Empty, Empty)) |> should equal (Node(6, Empty, Empty))

[<Test>]
let mapForTreeWithDifficultFunctionTest () =
    mapForTree (fun x -> 3 * x * x + 10 * x + 15) (Node(1, Empty, Empty)) |> should equal (Node(28, Empty, Empty))

[<Test>]
let mapForTreeWithDifficultTreeTest () =
    mapForTree (fun x -> x * 2) (Node(5, Node(3, Node(2, Empty, Empty), Node(4, Empty, Empty)), Node(7, Node(6, Empty, Empty), Node(8, Empty, Empty)))) 
        |> should equal (Node(10, Node(6, Node(4, Empty, Empty), Node(8, Empty, Empty)), Node(14, Node(12, Empty, Empty), Node(16, Empty, Empty))))