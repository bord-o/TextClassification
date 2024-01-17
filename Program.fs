namespace TextClassification
open System
open System.Text
// Usage:
module Main = 
    let (train, test)  = Loader.initData ()

    let compressionTest data =  
        let original = Encoding.UTF8.GetString test
        let compressed = Gzip.compress original
        let decompressed = Gzip.decompress compressed
        printfn "Original Length: %A" original.Length
        //printfn "Compressed: %A" compressed.Length
        printfn "Compressed Length: %A" compressed.Length
        //printfn "Decompressed: %s" decompressed
        printfn "Decompressed Length: %A" decompressed.Length
        Console.ReadLine ()

    [<EntryPoint>]
    let main args =
        0
        


            
