
namespace Bootstrap3to4

open System
open CliTypes
open Mono.Options

module Main =

    [<EntryPoint>]
    let main (args: string[]) =
        let options = new Options()
        let optionSet = new OptionSet()

        optionSet.Add("help", "Show help message",
            fun o -> options.Help <- true) |> ignore
        optionSet.Add("x|ext=", "File extension(s)",
            fun o -> options.AddExt o) |> ignore

        optionSet.Parse(args) |> ignore

        if options.Help || options.Ext.Length = 0 then
            optionSet.WriteOptionDescriptions(Console.Error)
        else
            Console.WriteLine(options.Ext)

        0
