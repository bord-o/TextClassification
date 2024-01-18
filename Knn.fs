namespace TextClassification

open FSharp.Collections.ParallelSeq

module Knn =
    open Gzip

    type Distance = { genre: int; distance: float }

    let predict (txt: string) (data: Loader.TextClass seq) (k: int) : int =
        let distances =
            data
            |> PSeq.mapi (fun i (row: Loader.TextClass) ->
                // printfn $"Processing data: {i}";
                { genre = row.genre
                  distance = (NCD txt row.text) })
            |> Seq.sortBy (fun dist -> dist.distance)
            |> Seq.take k

        let genre, count =
            distances
            |> Seq.countBy (fun dist -> dist.genre)
            |> Seq.maxBy (fun (genre, count) -> count)

        printfn $"Found genre: {genre} to be most likely, with a count of {count}/{k}\n"
        genre

    let test (test: Loader.TextClass seq) (train: Loader.TextClass seq) (k: int) : float =

        printfn $"Running {Seq.length test} tests"

        // run number and was it accurate
        let results =
            test
            |> Seq.mapi (fun i { genre = genre; text = text } ->
                printfn $"Test number {i} with genre: {genre}"
                (i, (predict text train k) = genre))
            |> Seq.toList

        let accuracy =
            let correct_count =
                (results |> List.filter (fun (run_num, correct) -> correct)).Length

            (float correct_count) / (float results.Length)

        printfn $"Ran {results.Length} tests and found a total accuracy of {accuracy}"
        accuracy
