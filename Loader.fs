namespace TextClassification

open System.IO
open System.Text

module Loader =


    let initData (dataDir:string) =

        let test = File.ReadAllBytes(Path.Join(dataDir, "test.csv" )) 
        let train = File.ReadAllBytes(Path.Join(dataDir, "train.csv")) 
        let sample = test[0..10]
        ()

        //printfn $"{test}"
        //printfn $"{train}"


