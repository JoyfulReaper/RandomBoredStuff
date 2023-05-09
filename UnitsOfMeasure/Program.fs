module UnitsOfMeasure =

    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    let sampleValue1 = 1600.0<meter>

    // Define a new unit type
    [<Measure>]
    type mile =
        static member asMeter = 1609.34<meter/mile> // Conversion factor mile to meter.

    /// Define a unitized constant
    let sampleValue2 = 500.0<mile>

    // Compute metric-system constant
    let sampleValue3 = sampleValue2 * mile.asMeter

    // Values using Units of Measure can be used just like the primitive numeric type for things like printing.
    printfn $"After a %f{sampleValue1} race I would walk %f{sampleValue2} miles which would be %f{sampleValue3} meters"