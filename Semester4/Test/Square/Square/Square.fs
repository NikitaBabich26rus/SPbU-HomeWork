module Square

// Print square.
let rec printSquare (list: List<string>) =
    match list.Length with
    | 1 -> printfn "%s" list.Head
    | _ -> printfn "%s" list.Head
           printSquare list.Tail

// Get square with stars.
let getSquare n =

    // Create first and last line.
    let rec lineOfStars str count =
        if count < n then
            lineOfStars (str + "*") (count + 1)
        else 
            str

    // Create middle line.
    let rec lineWithSpaces str count =
        match count with
        | 0 -> lineWithSpaces "*" (count + 1)
        | number when number = n - 1 -> (str + "*")
        | _ -> lineWithSpaces (str + " ") (count + 1)

    // Fill square.
    let rec fillSquare list count =
        match count with
        | number when number = n - 1 -> list @ [(lineOfStars "" 0)]
        | 0 -> fillSquare [(lineOfStars "" 0)] (count + 1)
        | _ -> fillSquare (list @ [(lineWithSpaces "" 0)]) (count + 1)

    if n < 1 then 
        raise (System.ArgumentException("Side of the square is less than 1"));
    fillSquare [] 0
