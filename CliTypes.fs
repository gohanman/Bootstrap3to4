
namespace Bootstrap3to4

module CliTypes = 

    type Options() =
        let mutable m_help = false
        let mutable m_write = false
        let mutable m_ext: list<string> = []

        member this.Help with get() = m_help
                         and set newHelp = m_help <- newHelp
        
        member this.OverWrite with get() = m_write
                              and set newWrite = m_write <- newWrite

        member this.Ext with get() = m_ext

        member this.AddExt ext = m_ext <- ext :: m_ext

