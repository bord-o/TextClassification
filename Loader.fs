namespace TextClassification

open System.IO
open System.Text
open FSharp.Data
module Loader =


    //let datadir = @"C:\Users\brody\source\repos\TextClassification\Data\"
    let dataDir = @"C:\Users\BLittle\Documents\GIT\TextClassification\Data\"
    [<Literal>]
    let fulldata = @"C:\Users\BLittle\Documents\GIT\TextClassification\Data\test.csv"
    

    type DataRow = CsvProvider<fulldata>

    let initData () =

        let test = File.ReadAllBytes(Path.Join(dataDir, "test.csv" )) 
        let train = File.ReadAllBytes(Path.Join(dataDir, "train.csv")) 
        let sample = test[0..10]
        (sample, test)

        //printfn $"{test}"
        //printfn $"{train}"


