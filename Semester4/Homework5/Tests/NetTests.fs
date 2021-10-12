module Tests

open NUnit.Framework
open Net
open System

let computers1 =
    [
        new Computer("1", "Windows", false)
        new Computer("2", "Windows", false)
        new Computer("3", "Windows", false)
        new Computer("4", "Windows", true)
    ]

let matrix1 =
    [
        [false; false; false; false]
        [false; false; false; false]
        [false; false; false; false]
        [false; false; false; false]
    ]

[<Test>]
let networkWithoutInterconnectedWindowsComputers () =
    let net = new Net(computers1, matrix1)
    net.Start(5, new Random())
    let answer = net.Computers
    Assert.IsTrue((answer.Item 0).Infected)
    Assert.IsFalse((answer.Item 1).Infected)
    Assert.IsFalse((answer.Item 2).Infected)
    Assert.IsFalse((answer.Item 3).Infected)