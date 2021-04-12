open System
open Net

[<EntryPoint>]
let main argv =
    let computers1 =
        [
            new Computer("first", "Windows", false)
            new Computer("second", "Windows", false)
            new Computer("third", "Windows", false)
            new Computer("fourth", "Windows", true)
        ]
    let matrix2 =
        [
            [false; false; false; false]
            [false; false; false; false]
            [false; false; false; false]
            [false; false; false; false]
        ]
    let net = new Net(computers1, matrix2)
    net.Start(5, new Random())
    let computers = net.Computers
    0