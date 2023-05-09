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