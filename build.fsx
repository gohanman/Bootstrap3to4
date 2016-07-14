#r @"packages/FAKE/tools/FakeLib.dll"
open Fake.FscHelper
open Fake.FileHelper
open Fake

Target "Clean" (fun _ ->
    DeleteFile "Bootstrap3to4.exe"
)

Target "Default" (fun _ ->

    let refs = ["packages/Mono.Options/lib/net4-client/Mono.Options.dll"]

    let sources = ["CliTypes.fs"; "Bootstrap3to4.fs" ]

    sources
    |> Compile [Out "Bootstrap3to4.exe"; References refs; StaticLink "Mono.Options"]
)

RunTargetOrDefault "Default"

