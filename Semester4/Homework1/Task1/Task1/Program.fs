open System

let getFibonacciValue fibonacciNumber =
    let rec fibonacci value1 value2 step =
        if step = fibonacciNumber then
            Some(value2)
        else 
            fibonacci value2 (value2 + value1) (step + 1)
    if fibonacciNumber < 1 then 
        None
    elif fibonacciNumber = 1 then
        Some(0)
    else 
        fibonacci 0 1 1

[<EntryPoint>]
let main argv =
    let answer = getFibonacciValue 15
    printfn "%A" answer
    0
