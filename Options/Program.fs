module OptionValues =

    // Single-case discriminated union
    type ZipCode = ZipCode of string

    // Type where ZipCode is optional
    type Customer = { ZipCode: ZipCode option }

    /// Next, define an interface type that represents an object to compute the shipping zone for the customer's zip code,
    /// given implementations for the 'getState' and 'getShippingZone' abstract methods.
    type IShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// Next, calculate a shipping zone for a customer using a calculator instance.
    /// This uses combinators in the Option module to allow a functional pipeline for
    /// transforming data with Optionals.
    let CustomerShippingZone (calculator: IShippingCalculator, customer: Customer) =
        customer.ZipCode
        |> Option.bind calculator.GetState
        |> Option.map calculator.GetShippingZone



    type ShippingCalculator() =
        interface IShippingCalculator with
            member this.GetState(zipCode) =
                Some "New York"
            member this.GetShippingZone(state) =
                1

    let someCustomer = { ZipCode = Some (ZipCode "12345") }
    let shippingZone = CustomerShippingZone (ShippingCalculator(), someCustomer)
    match shippingZone with
    | Some zone -> printfn $"Shipping zone is {zone}"
    | None -> printfn "No shipping zone found"