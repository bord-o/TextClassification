namespace TextClassification

open System.IO
open System.Text

module Loader =


    let initData (dataDir:string) =
        let test = File.ReadAllBytes(Path.Join(dataDir, "test.csv" )) |> Encoding.UTF8.GetString
        let train = File.ReadAllBytes(Path.Join(dataDir, "train.csv")) |> Encoding.UTF8.GetString
        ()

        //printfn $"{test}"
        //printfn $"{train}"


