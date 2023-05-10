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


    ///////////// Implementing an Interface /////////////

    /// This is a type that implements the IDisposable interface.
    type ReadFile() =
        let file = new System.IO.StreamReader("readme.txt")
        member this.ReadLine() = file.ReadLine()
        // This is the implementation of IDisposiable members
        interface System.IDisposable with
            member this.Dispose() = file.Close()

    /// This is an object that implements IDisposable via an Object Expression.
    /// A new type definition is not required to implement an interface.
    let interfaceImplementation = 
        { new System.IDisposable with 
            member this.Dispose() = printfn "Disposed!"  }

    interfaceImplementation.Dispose()


    ///////////// Which Types to Use /////////////
    (*
    Which Types to Use
    The presence of Classes, Records, Discriminated Unions, and Tuples leads to an important question: which should you use? Like most everything in life,
    the answer depends on your circumstances.

    Tuples are great for returning multiple values from a function, and using an ad-hoc aggregate of values as a value itself.

    Records are a "step up" from Tuples, having named labels and support for optional members. They are great for a low-ceremony representation of data in-transit through your program.
    Because they have structural equality, they are easy to use with comparison.

    Discriminated Unions have many uses, but the core benefit is to be able to utilize them in conjunction with Pattern Matching to account for all possible "shapes" that a data can have.

    Classes are great for a huge number of reasons, such as when you need to represent information and also tie that information to functionality.
    As a rule of thumb, when you have functionality that is conceptually tied to some data, using Classes and the principles of Object-Oriented Programming is a significant benefit.
    Classes are also the preferred data type when interoperating with C# and Visual Basic, as these languages use classes for nearly everything.
    *)