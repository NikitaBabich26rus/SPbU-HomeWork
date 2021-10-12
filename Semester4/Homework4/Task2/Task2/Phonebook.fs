module Phonebook

open System.IO
open System

// Print commands for interface.
let printCommands =
    printfn "Commands:"
    printfn "Exit: 1"
    printfn "Add phone and name: 2"
    printfn "Get name by phone: 3"
    printfn "Get phone by name: 4"
    printfn "Print phonebook: 5"
    printfn "Write to file: 6"
    printfn "Read from file: 7"

// Add phone and name.
let addPhoneAndName name phone phonebook = (name, phone) :: phonebook 

// Get phone by name.
let getPhoneByName phonebook name =
    phonebook |> List.filter(fun (currentName, _) -> name = currentName) |> List.map(snd)

// Get name by phone.
let getNameByPhone phonebook phone =
    phonebook |> List.filter(fun (_, currentPhone) -> phone = currentPhone) |> List.map(fst)

// Print the phonebook.
let rec printPhonebook phonebook =
    match phonebook with
    | [] -> printf ""
    | head :: tail ->
        printfn "%A" head
        printPhonebook tail

// Write data to file.
let writeDataToFile phonebook path =
    let newList = phonebook |> List.map(fun (name, phone) -> name + " " + phone)
    File.WriteAllLines(path, newList)

// Read data from file.
let readDataFromFile path =
    let file = Seq.map (fun (str: string) -> (Array.get (str.Split(" ")) 0, Array.get (str.Split(" ")) 1)) (File.ReadAllLines(path))
    Seq.toList file

// Interaction with the interface.
let rec getStarted phonebook = 
    printCommands
    let command = Console.ReadLine()
    match command with
    | "1" -> ignore
    | "2" ->
        printfn "%s" "Type name and phone"
        let name = Console.ReadLine()
        let phone = Console.ReadLine()
        getStarted (addPhoneAndName name phone phonebook)
    | "3" ->
        printfn "%s" "Type phone"
        let phone = Console.ReadLine()
        printfn "%A" (getNameByPhone phonebook phone)
        getStarted phonebook
    | "4" ->
        printfn "%s" "Type name"
        let name = Console.ReadLine()
        printfn "%A" (getPhoneByName phonebook name)
        getStarted phonebook
    | "5" ->
        printPhonebook phonebook
        getStarted phonebook
    | "6" ->
        printfn "%s" "Type path"
        let path = Console.ReadLine();
        writeDataToFile phonebook path
        getStarted phonebook
    | "7" ->
        printfn "%s" "Type path"
        let path = Console.ReadLine();
        let fileData = readDataFromFile path
        getStarted fileData
    | _ ->
        printfn "%s" "Incorrect command try again"
        getStarted phonebook