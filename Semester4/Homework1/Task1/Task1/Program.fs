open System

let getFibonacciValue fibonacciNumber =
    let rec fibonacci value1 value2 step =
        if (fibonacciNumber = 1)
            then Some(value1)
        elif (step = fibonacciNumber)
            then Some(value2)
        else
            fibonacci (value2) (value2 + value1) (step + 1)
    if (fibonacciNumber < 1)
        then None
    else
        fibonacci 0 1 1

[<EntryPoint>]
let main argv =
    let answer = getFibonacciValue 30
    printfn "%A" answer
    0
