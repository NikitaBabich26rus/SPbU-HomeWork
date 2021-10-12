module Tests

open NUnit.Framework
open LambdaInterpreter

[<Test>]
let betaReductionLargeExpressionTest () =
    let value = betaReduction (Application(Abstraction("x", Variable("y")),
        Application(Abstraction("x", Application(Variable("x"), Application(Variable("x"),
        Variable("x")))), Abstraction("x", Application(Variable("x"), Application(Variable("x"), Variable("x")))))))
    Assert.AreEqual(Variable("y"), value)

[<Test>]
let betaReductionSmallExpressionTest () =
    let value = betaReduction (Application(Abstraction("x", Abstraction("y", Variable("x"))), Abstraction("x", Variable("x"))))
    Assert.AreEqual(Abstraction("y", Abstraction("x", Variable("x"))), value)
