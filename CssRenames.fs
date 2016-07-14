
namespace Bootstrap3to4

module CssRenames =

    let swaps = [
        ("btn-default", "btn-secondary")
        ("control-label", "form-control-label")
        ("input-lg", "form-control-lg")
        ("input-sm", "form-control-sm")
        ("panel-heading", "card-title")
        ("panel-body", "card-block")
        ("panel-footer", "card-footer")
        ("panel-primary", "card-primary")
        ("panel-success", "card-success")
        ("panel-info", "card-info")
        ("panel-warning", "card-warning")
        ("panel-daner", "card-danger")
        ("panel-default", "")
        ("panel", "card")
        ("well", "card")
    ]

    let renameClasses line:string =
        swaps |> List.fold (fun acc (cur, fix) -> acc.Replace(cur, fix)) line 

