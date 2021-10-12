module Tests

open NUnit.Framework
open Phonebook

[<Test>]
let addPhoneAndNameTest () =
    let answer = addPhoneAndName "Vasya" "12345" []
    Assert.AreEqual([("Vasya", "12345")], answer)

[<Test>]
let getPhoneByNameTest () =
    let answer = getPhoneByName [("Vasya", "12345")] "Vasya"
    Assert.AreEqual("12345", answer.Head)

[<Test>]
let getNameByPhoneTest () =
    let answer = getNameByPhone [("Vasya", "12345")] "12345"
    Assert.AreEqual("Vasya", answer.Head)

[<Test>]
let writeDataToFileAndReadDataFromFileTest () =
    writeDataToFile [("Vasya", "12345")] "../../../Phonebook"
    let answer = readDataFromFile "../../../Phonebook"
    Assert.AreEqual([("Vasya", "12345")], answer)