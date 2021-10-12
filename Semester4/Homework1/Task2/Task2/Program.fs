open System

let getTheFactorialOfNumber value =
    let rec factorial currentValue step =
        if value = step then
            currentValue
        else
            factorial (currentValue * (step + 1)) (step + 1)
    if value < 0 then
        None
    elif value = 0 then
        Some(0)
    else
        Some(factorial 1 1)


[<EntryPoint>]
let main argv =
    let answer = getTheFactorialOfNumber 4
    printfn "%A" answer
    0 
