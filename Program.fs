namespace TextClassification

open System
open System.IO
open System.Diagnostics

module Main =
    //  (1: “World”, 2: “Sports”, 3: “Business”, 4: “Sci/Tech”)

    let (train, test) = Loader.initData ()

    [<EntryPoint>]
    let main args =
        // Seq.iter (fun row -> printfn "%A" row) sample
        // Knn.predict "The news was wrong" train 10
        let rand = Random()
        let mutable randomSample = Seq.toArray test
        do rand.Shuffle(randomSample)

        let timer = new Stopwatch()
        timer.Start()
        let accuracy = Knn.test (Seq.take 10 randomSample) train 3
        timer.Stop()

        File.WriteAllText(
            "./results.txt",
            $"The overall accuracy was: {accuracy} and testing completed in {timer.Elapsed.Minutes} minutes"
        )

        int (accuracy * 100.0)
