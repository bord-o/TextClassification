namespace TextClassification

open System.IO
open System.Text
open System
open FSharp.Data

module Loader =


    //[<Literal>]
    //let fulldata = @"C:\Users\brody\source\repos\TextClassification\Data\test.csv"
    //let dataDir = @"C:\Users\brody\source\repos\TextClassification\Data\"


    [<Literal>]
    let fulldata = @"C:\Users\BLittle\Documents\GIT\TextClassification\Data\test.csv"
    let dataDir = @"C:\Users\BLittle\Documents\GIT\TextClassification\Data\"


    type DataRow = CsvProvider<fulldata>
    type TextClass = { genre: int; text: string}


    let initData () =

        let test =
            DataRow.Load(Path.Join(dataDir, "test.csv")).Rows
            |> Seq.map (fun row ->
                { genre = row.``Class Index``
                  text = row.Title + Environment.NewLine + row.Description })

        let train =
            DataRow.Load(Path.Join(dataDir, "train.csv")).Rows
            |> Seq.map (fun row ->
                { genre = row.``Class Index``
                  text = row.Title + Environment.NewLine + row.Description })

        (train, test)

//printfn $"{test}"
//printfn $"{train}"
