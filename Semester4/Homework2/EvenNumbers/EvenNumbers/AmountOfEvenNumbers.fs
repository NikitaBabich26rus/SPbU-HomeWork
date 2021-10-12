module AmountOfEvenNumbers 
    
    /// Get amount of even numbers from list by map.
    let getAmountOfEvenNumbersByMap list =
        list |> List.map(fun value ->
            if (value % 2 = 0) then
                1
            else
                0
        )|> List.sum

    /// Get amount of even numbers from list by filter.
    let getAmountOfEvenNumbersByFilter list =
        list |> List.filter(fun value -> value % 2 = 0)|> List.length

    /// Get amount of even numbers from list by fold.
    let getAmountOfEvenNumbersByFold list = 
        list |> List.fold(fun acc value ->
            if (value % 2 = 0) then
                acc + 1
            else 
                acc
        ) 0