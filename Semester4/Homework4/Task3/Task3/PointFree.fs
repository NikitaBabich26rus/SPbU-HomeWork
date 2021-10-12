module PointFree

let mapMultiplication x l = List.map (fun value -> value * x) l

let mapMultiplication1 x = List.map (fun value -> value * x)

let mapMultiplication2 x = List.map (fun value -> (*) x value)

let mapMultiplication3 x = List.map ((*) x)

let mapMultiplication4 = List.map << (*)
