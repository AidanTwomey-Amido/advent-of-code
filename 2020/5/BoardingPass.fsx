open System;
open System.IO

let readLines (filePath:string) = seq {
    use sr = new StreamReader (filePath)
    while not sr.EndOfStream do
        yield sr.ReadLine ()
}

let splitSeatCode (seatCode:string) =
  (seatCode.Substring(0,7), seatCode.Substring(7,3))

let toVal x i =
    match x with
    | 'F' -> 0
    | 'L' -> 0
    | _   -> pown 2 i


let orderedCode c = c |> Seq.toList |> List.rev

let toSeatRow seatCode =
    let rec loop seatCodes n i =
        match seatCodes with
        | [] -> n
        | h::t  -> n + (toVal h i) + loop t n (i+1)
    let (rowCode, columnCode) = splitSeatCode seatCode
    let row = loop (orderedCode rowCode) 0 0
    let col = loop (orderedCode columnCode) 0 0
    (row, col)

let toSeatId (row,column) =
    (row*8) + column



// # check

["BFFFBBFRRR";"FFFBBBFRRR";"BBFFBBFRLL";"BBBBBBBRRR"] 
    |> Seq.map toSeatRow 
    |> Seq.map toSeatId
    |> Seq.iter (fun (id) -> printfn "%i" id)

// problem

let maxId = 
  readLines "puzzledata"
    |> Seq.map toSeatRow 
    |> Seq.map toSeatId
    |> Seq.max
    
printfn "%i" maxId

let orderedIds = 
  readLines "puzzledata"
    |> Seq.map toSeatRow 
    |> Seq.map toSeatId
    |> Seq.sortDescending
    |> Seq.toList

let rec findMissingSeat ids last =
    match ids with
    | []                   -> 0
    | h::t when h = last-1 -> findMissingSeat t h
    | h::t                 -> h + 1

let middingId = findMissingSeat orderedIds 914

printfn "missing seat %i" middingId
