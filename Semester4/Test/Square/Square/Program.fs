open System
open Square

[<EntryPoint>]
let main argv =
    let answer = getSquare 10
    printSquare answer
    0