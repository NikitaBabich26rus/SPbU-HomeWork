module Tests

open NUnit.Framework
open Brackets


[<Test>]
let checkingBracketSequenceForCorrectnessTest1 () =
    let value = Seq.toList "(){}[]" |> checkingBracketSequenceForCorrectness
    Assert.IsTrue(value)
   
[<Test>]
let checkingBracketSequenceForCorrectnessTest2 () =
    let value = Seq.toList "()()((())))" |> checkingBracketSequenceForCorrectness
    Assert.IsFalse(value)

[<Test>]
let checkingBracketSequenceForCorrectnessTest3 () =
    let value = Seq.toList "{{}" |> checkingBracketSequenceForCorrectness
    Assert.IsFalse(value)

[<Test>]
let checkingBracketSequenceForCorrectnessTest4 () =
    let value = Seq.toList "" |> checkingBracketSequenceForCorrectness
    Assert.IsTrue(value)

[<Test>]
let checkingBracketSequenceForCorrectnessTest5 () =
    let value = Seq.toList "(((((((((((((()))))()()()()()))))))()()))))))}}{}{}{}}{{}}" |> checkingBracketSequenceForCorrectness
    Assert.IsFalse(value)

[<Test>]
let checkingBracketSequenceForCorrectnessTest6 () =
    let value = Seq.toList "]]]]][[[]]{}{}}{}{}" |> checkingBracketSequenceForCorrectness
    Assert.IsFalse(value)