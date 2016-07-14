
namespace Bootstrap3to4

open System
open CliTypes
open Mono.Options

module Main =

    [<EntryPoint>]
    let main (args: string[]) =
        let options = new Options()
        let optionSet = new OptionSet()

        optionSet.Add("?|help", "Show help message",
            fun o -> options.Help <- true) |> ignore
        optionSet.Add("x|ext=", "Required. File extension(s). May be used more than once.",
            fun o -> options.AddExt o) |> ignore

        let generic = optionSet.Parse(args) 
        let paths = List.ofSeq(generic)

        if options.Help || options.Ext.Length = 0 || paths.Length = 0 then
            Console.Error.WriteLine("Usage: Bootstrap3to4.exe [options] path")
            optionSet.WriteOptionDescriptions(Console.Error)
        else
            Console.WriteLine(options.Ext)
            Console.WriteLine(paths)

        0
