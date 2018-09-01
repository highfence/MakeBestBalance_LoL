namespace LogicLib

open DomainClassLib

module MatchMaker =

    let TestInterop ( x : Player ) =
        
        printfn "%A" x.GameId
        printfn "%A" x.Name
        printfn "%A" x.Scores