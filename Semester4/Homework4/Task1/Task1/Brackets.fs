module Brackets

// Checking bracket sequence for correctness.
let checkingBracketSequenceForCorrectness (sequence : List<char>) =
    
    // Сhecking two parentheses for compatibility.
    let isPair openBracket closeBracket = 
        match openBracket with
        | '(' -> closeBracket = ')'
        | '{' -> closeBracket = '}'
        | '[' -> closeBracket = ']'
        | _ -> false

    // Is the parenthesis open.
    let isOpenBracket value =
        value = '(' || value = '{' || value = '['

    // Work with a sequence item.
    let rec checkElementOfSequence (currentSequence: List<char>) (stack: List<char>) =
        if currentSequence.IsEmpty && stack.IsEmpty then
            true
        elif currentSequence.IsEmpty && stack <> [] then
            false            
        else
            let currentValue = List.head currentSequence
            if (isOpenBracket currentValue) then
                checkElementOfSequence (List.tail currentSequence) (currentValue :: stack)
            elif (stack.IsEmpty) then 
                false
            elif (isPair (List.head stack) currentValue) then 
                checkElementOfSequence (List.tail currentSequence) (List.tail stack)
            else 
                false

    checkElementOfSequence sequence []