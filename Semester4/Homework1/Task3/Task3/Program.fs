open System

let getExponentListOfTwo n m =
    let rec exponentiation index list = 
        if index = m then
            Some(List.append list [pown 2 index])
        else
            exponentiation (index + 1) (List.append list [pown 2 index])

    if n < 0 || m < 0 then
        None
    elif n = 0 && m = 0 then
        Some([1])
    else
        exponentiation n ([])

[<EntryPoint>]
let main argv =
    let answer = getExponentListOfTwo 7 12
    printfn "%A" answer
    0
