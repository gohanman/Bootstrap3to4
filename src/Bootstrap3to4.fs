
namespace Bootstrap3to4

open System
open CliTypes
open CssRenames
open Files
open Mono.Options

module Main =

    [<EntryPoint>]
    let main (args: string[]) =
        let options = new Options()
        let optionSet = new OptionSet()

        optionSet.Add("?|help", "Show help message",
            fun o -> options.Help <- true) |> ignore
        optionSet.Add("o|overwrite", "Update files in place",
            fun o -> options.OverWrite <- true) |> ignore
        optionSet.Add("x|ext=", "Required. File extension(s). May be used more than once.",
            fun o -> options.AddExt o) |> ignore

        let generic = optionSet.Parse(args) 
        let paths = List.ofSeq(generic)

        if options.Help || options.Ext.Length = 0 || paths.Length <> 1 then
            Console.Error.WriteLine("Usage: Bootstrap3to4.exe [options] path")
            optionSet.WriteOptionDescriptions(Console.Error)
        else
            Files.getByExt paths.Head options.Ext
            |> Seq.iter (fun path -> Files.mapByLine path CssRenames.renameClasses)

            if options.OverWrite then
                Console.WriteLine("overwriting")
                Files.getByExt paths.Head ["b3to4"]
                |> Seq.iter (fun path -> Files.copyOver path)
        0
