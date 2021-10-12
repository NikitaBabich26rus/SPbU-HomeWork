module  MapForTree

/// Tree.
type Tree<'a> = 
    | Node of 'a * Tree<'a> * Tree<'a>
    | Empty

 /// Applies a function to each value of the tree.
let rec mapForTree func tree =
    match tree with
    | Node(value, leftChild, rightChild) -> Node(func value, mapForTree func leftChild, mapForTree func rightChild)
    | Empty -> Empty