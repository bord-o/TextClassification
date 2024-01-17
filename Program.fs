namespace TextClassification
open System
// Usage:
module Main = 
    let original = Mydata.Lorem.lorem
    let compressed = Gzip.compress original
    let decompressed = Gzip.decompress compressed
    //printfn "Original: %s" original
    let datadir = @"C:\Users\brody\source\repos\TextClassification\Data\"

    [<EntryPoint>]
    let main args =
        printfn "Original Length: %A" original.Length
        //printfn "Compressed: %A" compressed.Length
        printfn "Compressed Length: %A" compressed.Length
        //printfn "Decompressed: %s" decompressed
        printfn "Decompressed Length: %A" decompressed.Length
        Loader.initData datadir
        printfn "Done Reading"
        let _ = Console.ReadLine ()
        0
        


            
