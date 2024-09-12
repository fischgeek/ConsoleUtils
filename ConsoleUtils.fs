namespace ConsoleUtils

open System

module ConsoleUtils = 
    let wait() = Console.ReadLine() |> ignore

    let private pad2 i =
            if i <= 9 then
                sprintf "0%i" i
            else
                i.ToString()

    let private pad3 (i: int) : string =
            if i <= 9 then
                sprintf "00%i" i
            else if i <= 99 then
                sprintf "0%i" i
            else
                i.ToString()

    let private stampString =
        let d = DateTime.Now
        sprintf "%i-%s-%s %s:%s:%s.%s" 
            d.Year (pad2 d.Month) (pad2 d.Day) (pad2 d.Hour) 
            (pad2 d.Minute) (pad2 d.Second) (pad3 d.Millisecond)

    let printWithStamp (str: string) = printfn $"[{stampString}] {str}"

    let out s = Console.WriteLine($"{s.ToString()}")

    let nout s = 
        "" |> out
        s |> out

    let outn s = 
        s |> out
        "" |> out

    let noutn s = 
        "" |> out 
        s |> outn

    let outt s = printWithStamp s

    let prompt (question: string) = 
        printf $"{question}: "
        Console.ReadLine()

    let promptn (question: string) = 
        printfn $"{question}"
        Console.ReadLine()
    
    let printClr (str: string) (clr: ConsoleColor) = 
        Console.ForegroundColor <- clr
        printf $"{str}"
        Console.ForegroundColor <- ConsoleColor.White

    let printClrn (stringVal: string) (clr: ConsoleColor) = 
        Console.ForegroundColor <- clr
        printfn $"{stringVal}"
        Console.ForegroundColor <- ConsoleColor.White

    let printSuccess (str: string) = printClr str ConsoleColor.Green

    let printWarning (str: string) = printClr str ConsoleColor.Yellow

    let printError (str: string) = printClr str ConsoleColor.Red

    let printSuccessn (str: string) = printClrn str ConsoleColor.Green

    let printWarningn (str: string) = printClrn str ConsoleColor.Yellow

    let printErrorn (str: string) = printClrn str ConsoleColor.Red

    let outblue str = printClr str ConsoleColor.Blue