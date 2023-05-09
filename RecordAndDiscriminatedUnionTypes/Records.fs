module RecordTypes
    open DiscriminatedUnions
    
    /// Example of defining a record type
    type ContactCard =
        { Name     : string
          Phone    : string
          Verified : bool  }

    /// Example of instantiaing a record type
    let contact1 = 
        { Name     = "Alf"
          Phone    = "(206) 555-0157"
          Verified = false }

    /// You can also do this on the same line with ';' separators.
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// This example shows how to use "copy-and-update" on record values. It creates
    /// a new record value that is a copy of contact1, but has different values for
    /// the 'Phone' and 'Verified' fields.
    /// To learn more, see: https://learn.microsoft.com/dotnet/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 =
        { contact1 with
            Phone = "(206) 555-0112"
            Verified = true }

    /// This example shows how to write a function that processes a record value.
    /// It converts a 'ContactCard' object to a string.
    let showContactCard (c: ContactCard) =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn $"Alf's Contact Card: {showContactCard contact1}"
    printfn $"Alf's Contact Card2: {showContactCard contact2}"


    /// Example of a record with a member
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

    // Members can implment object-oriented members
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified) " else "") + this.Address

    let contactAlternate = 
        { Name     = "Alf"
          Phone    = "(206) 555-0157"
          Address  = "111 Alf St"
          Verified = false }

    // Members are accessed via the '.' operator on an instantiated type.
    printfn $"Alf's alternate contact card is {contactAlternate.PrintedContactCard}"
    printfn ""

    // Records can also be represented as structs with [<Struct>] attribute
    [<Struct>]
    type ContactCardStruct =
        { Name     : string
          Phone    : string
          Verified : bool }


    /// DiscriminatedUnion stuff from the other .fs file
    printAllCards()