module LambdaInterpreter

// Lambda term.
type Term =
    | Variable of string
    | Application of Term * Term
    | Abstraction of string * Term

// Get new name which not contained in set of used names.
let getNewName usedNames =
    let letters = List.map (fun x -> x.ToString()) [ 'a' .. 'z' ]
    let rec get count =
        let newSet =
            letters |> List.map (fun x ->
                if (count = 0) then
                    x
                else
                    x + count.ToString())
        let newSet = List.filter (fun x -> not (Set.contains x usedNames)) newSet
        if (List.isEmpty newSet) then
            get (count + 1)
        else
            newSet.[0]
    get 0

//Get free variables.
let rec getFreeVariables T =
    match T with
    | Variable (x) -> Set.singleton x
    | Application (S, T) -> Set.union (getFreeVariables S) (getFreeVariables T)
    | Abstraction (str, T) -> Set.difference (getFreeVariables T) (Set.singleton str)

//Substitution of term.
let rec substitution value currentTerm newTerm =
    match (currentTerm, newTerm) with
    | (Variable (x), _) when value = x -> newTerm
    | (Variable (x), _) -> currentTerm
    | (Application (term1, term2), _) -> Application(substitution value term1 newTerm, substitution value term2 newTerm)
    | (Abstraction (x, term), Variable (_)) when x = value -> Abstraction(x, term)
    | (Abstraction (x, term), _) ->
        let termFV = getFreeVariables term
        let newTermFV = getFreeVariables newTerm
        let cond = (Set.contains x newTermFV) && (Set.contains value termFV)
        if (not cond) then
            Abstraction(x, substitution value term newTerm)
        else
            let newName = getNewName (Set.union termFV newTermFV)
            let firstT = substitution x term (Variable(newName))
            let secondT = substitution value firstT newTerm
            Abstraction(newName, secondT)

// Beta reduction.
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