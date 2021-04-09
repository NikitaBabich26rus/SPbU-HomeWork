module Net

open System

type Computer(name: string, os: string, infected: bool) =
    member this.Os = os

    member this.Name = name

    member val Infected = false with get, set

    member val GotInfectedThisTurn = false with get, set

    member this.ChanceOfInfection =
        match os with
        | "Windows" -> 0.7
        | "Linux" -> 0.3
        | "MacOS" -> 0.1
        | _ -> 0.0

type Net(computers: List<Computer>, adjacencyMatrix: List<List<bool>>) =

    let bfsStep(random: Random) =
        List.iter (fun (computer: Computer) -> if computer.GotInfectedThisTurn then computer.GotInfectedThisTurn <- false) computers

        for i in 0 .. computers.Length - 1 do
            if (computers.Item i).Infected && not (computers.Item i).GotInfectedThisTurn then
                for j in 0 .. computers.Length - 1 do
                    if (adjacencyMatrix.Item i).Item j && not (computers.Item j).Infected
                        && random.NextDouble() >= (computers.Item j).ChanceOfInfection
                    then
                        (computers.Item j).GotInfectedThisTurn <- true
                        (computers.Item j).Infected <- true

    let state =
        for i in 0 .. computers.Length - 1 do
            let computer = computers.Item i
            printfn "Name: %s, OS: %s, is infected: %b" computer.Name computer.Os computer.Infected

    member this.Computers = computers

    member this.Start (steps: int, frequency: int, random: Random) =
        for i in 1 .. steps do
            bfsStep(random)