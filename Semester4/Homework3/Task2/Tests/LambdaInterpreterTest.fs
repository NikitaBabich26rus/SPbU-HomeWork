module Tests

open NUnit.Framework
open LambdaInterpreter

[<SetUp>]
let Setup () =
    ()

[<Test>]
let betaReductionTest () =
    let value = betaReduction (Application(Abstraction("x", Variable("y")),
        Application(Abstraction("x", Application(Variable("x"), Application(Variable("x"),
        Variable("x")))), Abstraction("x", Application(Variable("x"), Application(Variable("x"), Variable("x")))))))
    Assert.AreEqual(Variable("y"), value)
