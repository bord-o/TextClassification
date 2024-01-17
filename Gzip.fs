namespace TextClassification 

open System.IO.Compression
open System.IO
open System.Text

module Gzip = 
    let compress (msg : string) : byte array =
        let bytes = Encoding.UTF8.GetBytes(msg)
        use outStream = new MemoryStream()
        use gZipStream = new GZipStream(outStream, CompressionMode.Compress)
        gZipStream.Write(bytes, 0, bytes.Length)
        gZipStream.Close()
        outStream.ToArray() 

    let decompress (msg: byte array) : string =
        use inStream = new MemoryStream(msg)
        use gZipStream = new GZipStream(inStream, CompressionMode.Decompress)
        use reader = new StreamReader(gZipStream)
        reader.ReadToEnd()

