module ParseTree

/// Arithmetic expression tree.
type ParseTree = 
    | Value of int
    | Addition of ParseTree * ParseTree
    | Multiplication of ParseTree * ParseTree
    | Division of ParseTree * ParseTree
    | Subtraction of ParseTree * ParseTree

/// Counting an arithmetic expression tree.
let rec countParseTree parseTree = 
    match parseTree with 
    | Value value -> value
    | Addition (leftChild, rightChild) -> (countParseTree leftChild) + (countParseTree rightChild)
    | Multiplication (leftChild, rightChild) -> (countParseTree leftChild) * (countParseTree rightChild)
    | Subtraction (leftChild, rightChild) -> (countParseTree leftChild) - (countParseTree rightChild)
    | Division (leftChild, rightChild) -> let rightValue = countParseTree rightChild
                                          if rightValue = 0 then  raise (System.DivideByZeroException())
                                          (countParseTree leftChild) / rightValue
                                          