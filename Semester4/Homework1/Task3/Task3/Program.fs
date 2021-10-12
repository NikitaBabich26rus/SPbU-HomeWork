﻿open System

let listReverse list = 
    let rec reverse currentList accumulator =
        if currentList = [] then
            accumulator
        else 
            match currentList with
            | head :: tail -> reverse tail (head :: accumulator)
            | [] -> accumulator
    reverse list []

let getExponentListOfTwo n m =
    let rec exponentiation index list currentValue = 
        if index = m then
            Some(listReverse (currentValue :: list))
        else
            exponentiation (index + 1) (currentValue :: list) (currentValue * 2)
    if n < 0 || m < 0 then
        None
    elif n = 0 && m = 0 then
        Some([1])
    else
        exponentiation n ([]) (pown 2 n)

[<EntryPoint>]
let main argv =
    let answer = getExponentListOfTwo 1 6
    printfn "%A" answer
    0
