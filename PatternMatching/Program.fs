open System


module PatternMaching =
    
    /// A record for a person's first and last name.
    type Person = {
        First : string
        Last  : string
    }

    /// A Discriminated Union of 3 different kinds of employees
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// Count everyone underneath the employee in the management hierarchy,
    /// including the employee. The matches bind names to the properties
    /// of the cases so that those names can be used inside the match branches.
    /// Note that the names used for binding do not need to be the same as the
    /// names given in the DU definition above.
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(person) -> 0
            | Manager(person, reports) -> reports |> List.sumBy countReports
            | Executive(person, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant

    let someGuy = Engineer {First = "Some"; Last = "Guy"}
    let someAssistant = Engineer {First = "Assistant"; Last = "Guy"}
    let managerDude = Manager ({First = "Manager"; Last = "Dude"}, [someGuy])
    let someDaveGuy = Executive({First = "Dave"; Last = "Guy"}, [managerDude], someAssistant)
    let lonelyDave = Manager({First = "Dave"; Last = "Lonely"}, [])

    //let someGuyEngineer = Engineer someGuy
    //let managerDudeManager = Manager(managerDude, [someGuyEngineer])
    //let someDaveGuyExecutive = Executive(someDaveGuy, [managerDudeManager], someAssistant)

    printfn "There are %i reports" (countReports someDaveGuy)


    /// Find all managers/executives named "Dave" who do not have any reports.
    /// This uses the 'function' shorthand to as a lambda expression.
    let findDaveWithOpenPosition(emps : List<Employee>) = 
        emps
        |> List.filter(function
                        | Manager({First = "Dave"}, []) -> true
                        | Executive({First = "Dave"}, [], _) -> true
                        | _ -> false)

    let lonelyDaves = findDaveWithOpenPosition [someGuy; someAssistant; managerDude; someDaveGuy; lonelyDave]
    printfn "There are %i lonely Daves" (lonelyDaves |> List.length)

    // Note the use of parentheses to extract the individual fields of the tuple for the Manager and Executive cases. 
    // This allows you to access the Person record type, along with any other fields for that case.
    lonelyDaves
    |> List.iter (fun emp ->
        match emp with
        | Manager({First = "Dave"; Last = last}, []) -> printfn $"Lonely Manager Dave: Mr. {last}"
        | Executive({First = "Dave"; Last = last}, [], _) -> printfn $"Lonely Executive Dave: Mr. {last}"
        | _ -> ())

    //////////////////////////////////////////

    /// You can also use the shorthand function construct for pattern matching,
    /// which is useful when you're writing functions which make use of Partial Application.
    let private parseHelper (f: string -> bool * 'T) = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDatetimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDatetimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // Define some more functions which parse with the helper function.
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    let ParseANumber =
        printfn($"Pick a number")
        let input = Console.ReadLine()
        let didItParse = parseInt input
        match didItParse with
        | Some num -> printfn($"You picked {num}")
        | None -> printfn($"That's not a number!")

