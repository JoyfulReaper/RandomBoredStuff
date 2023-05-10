module DefiningClasses =
    
    /// A simple two-dimensional Vector class.
    /// The class's constructor is on the first line,
    /// and takes two arguments: dx and dy, both of type 'double'.
    type Vector2D(dx: double, dy: double) =
        /// This internal field stores the length of the vector, computed when the
        /// object is constructed
        let length = sqrt (dx * dx + dy * dy) 

        // 'this' specifies a name for the object's self-identifier.
        // In instance methods, it must appear before the member name.
        member this.DX = dx
        member this.DY = dy
        member this.Length = length

        /// This member is a method. The previous members are properties.
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    // How to instantiate the Vector2D class
    let vector1 = Vector2D(3.0, 4.0)

    /// Get a new scaled vector object, without modifying the original object.
    let vector2 = vector1.Scale(10.0)

    printfn $"Length of vector1: %f{vector1.Length}\nLength of vector2: %f{vector2.Length}"


    ///////////// Defining Generic Classes /////////////

    type StateTracker<'T>(initialElement: 'T) =
        /// Internal field to store the sate in a list
        let mutable states = [ initialElement ]

        /// Add a new element to the list of states
        member this.UpdateState newState =
            states <- newState :: states // use the '<-' operator to mutate the value.

        /// Get the entire list of historical states.
        member this.History = states

        /// Get the latest state
        member this.CurrentState = states.Head

    /// An 'int' instance of the state tracker class. Note that the type parameter is inferred.
    let tracker = StateTracker 10

    tracker.UpdateState 17

    tracker.History
    |> List.iter (fun state -> printfn "State: %A" state)