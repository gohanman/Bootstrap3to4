
namespace Bootstrap3to4

module CssRenames =

    let swaps = [
        ("img-responsive", "img-fluid")
        ("table-condensed", "table-sm")
        ("control-label", "form-control-label")
        ("input-lg", "form-control-lg")
        ("input-sm", "form-control-sm")
        ("btn-default", "btn-secondary")
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
        ("pull-left", "pull-xs-left")
        ("pull-right", "pull-xs-right")
    ]

    let renameClasses line:string =
        swaps |> List.fold (fun acc (cur, fix) -> acc.Replace(cur, fix)) line 

