module PrimeNumbers

let getASequenceOfPrimeNumbers = 
    let isPrime value =
        if value < 2 then
            false
        else 
            let sqrt = (int << sqrt << double) value
            [2 .. sqrt] |> List.forall (fun x -> value % x <> 0)

    Seq.initInfinite id |> Seq.filter isPrime
