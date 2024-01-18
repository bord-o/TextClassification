﻿namespace TextClassification

open System
open System.Text
// Usage:
module Main =
    let (train, test, sample) = Loader.initData ()

    let compressionTest data =
        let original = "asdf"
        let compressed = Gzip.compress original
        let decompressed = Gzip.decompress compressed
        printfn "Original Length: %A" original.Length
        //printfn "Compressed: %A" compressed.Length
        printfn "Compressed Length: %A" compressed.Length
        //printfn "Decompressed: %s" decompressed
        printfn "Decompressed Length: %A" decompressed.Length
        Console.ReadLine()

    [<EntryPoint>]
    let main args =
        // Seq.iter (fun row -> printfn "%A" row) sample
        // Knn.predict "The news was wrong" train 10
        let accuracy = Knn.test (Seq.take 1000 test) train 3
        int (accuracy * 100.0)
