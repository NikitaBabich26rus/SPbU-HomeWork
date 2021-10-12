module Tests

open NUnit.Framework
open Square

[<Test>]
let simpleTest1 () =
    let answer = getSquare 3;
    Assert.AreEqual(["***"; "* *"; "***"], answer)

[<Test>]
let simpleTest2 () =
    let answer = getSquare 5;
    Assert.AreEqual(["*****"; "*   *"; "*   *"; "*   *"; "*****"], answer)

[<Test>]
let simpleTest3 () =
    let answer = getSquare 1;
    Assert.AreEqual(["*"], answer)