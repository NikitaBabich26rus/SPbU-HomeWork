open System

let listReverse list = 
    let rec reverse currentList newList =
        if currentList = [] then
            newList
        else 
            reverse (List.tail currentList) (List.head currentList :: newList)
    reverse list []

[<EntryPoint>]
let main argv =
    let answer = listReverse [3; 2; 1] 
    printfn "%A" answer
    0 
