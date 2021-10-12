open System

let findElementInList list value = 
    let rec findElement list index =
        match list with
        | head :: _ when head = value -> Some(index) 
        | [] -> None
        | _ :: tail -> findElement tail (index + 1)
    findElement list 0
   

[<EntryPoint>]
let main argv =
    let answer = findElementInList [1; 2; 3; 4; 67; 89; 0; 45] -7
    printfn "%A"answer
    0
