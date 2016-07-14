
namespace Bootstrap3to4

open System
open System.IO

module Files =

    let getByExt path exts =

        let dir = new DirectoryInfo(path)
        
        dir.EnumerateFiles()
        |> Seq.filter (fun f -> f.Extension.Length > 1)
        |> Seq.filter (fun f -> List.contains (f.Extension.Substring(1)) exts)
        |> Seq.map (fun f -> f.FullName)

    let mapByLine path mapFunc =

        let newPath = path + ".b3to4"
        let sw = new StreamWriter(newPath)
        
        File.ReadLines(path)
        |> Seq.map (fun line -> mapFunc line) 
        |> Seq.iter (fun (line:string) -> 
            sw.WriteLine(line)
        ) 

        sw.Close()

    let copyOver (path:string) = 
        let newPath = path.Substring(0, path.Length - 6)
        File.Copy(path, newPath, true)
        File.Delete(path)
