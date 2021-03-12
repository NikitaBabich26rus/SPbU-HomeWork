module LambdaInterpreter

type Term =
    | Variable of char
    | Application of Term * Term
    | Abstraction of char * Term

let rec substitution value currentTerm newTerm =
    match (currentTerm, newTerm) with
    | (Variable (x), _) when value = x -> newTerm
    | (Variable (x), _) -> currentTerm
    | (Application (term1, term2), _) -> Application(substitution value term1 newTerm, substitution value term2 newTerm)
    | (Abstraction (x, term), Variable (_)) when x = value -> Abstraction(x, term)
    | (Abstraction (x, term), _) ->
       //


let betaReduction T =
    let rec beta term =
        match term with
        | Variable (value) -> Variable(value)
        | Application (Abstraction (value, term1), term2) -> substitution value term1 term2
        | Application (term1, term2) ->
            let newTerm = beta term1
            match newTerm with
            | Abstraction (value, currentTerm) -> beta (substitution value currentTerm term2)
            | _ -> Application(newTerm, beta term2)
        | Abstraction (value, term) -> Abstraction(value, beta term)
    beta T