// Learn more about F# at http://fsharp.org

open System 
open System.IO

open XMLTest 

[<EntryPoint>]
let main argv =

    let inputs2 = InputXml.GetSample().Customers 

    printfn "XML example '%A'" inputs2 
    printfn " " 

    printfn "orders example '%A'" orders       
    printfn " " 

    printfn "orderLines example '%A'" orderLines       
    printfn " " 

    printfn "orderLines2 example '%A'" <| orderLines.XElement.ToString()         
    printfn " " 

    printfn "All finished from ExpertF#Ch08XML" 
    0 // return an integer exit code
