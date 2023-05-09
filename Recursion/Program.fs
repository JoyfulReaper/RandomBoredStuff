module RecursiveFunctions =
    
    // Compute factorial of an integer
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n - 1)

    printfn $"Factorial of 6 is: {factorial 6}"

    /// Computes the greatest common factor of two integers.
    /// Since all of the recursive calls are tail calls,
    /// the compiler will turn the function into a loop,
    /// which improves performance and reduces memory consumption.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn $"The Greatest Common Factor of 300 and 620 is %d{greatestCommonFactor 300 620}"


    /// This example computes the sum of a list of integers using recursion.
    ///
    /// '::' is used to split a list into the head and tail of the list,
    /// the head being the first element and the tail being the rest of the list.
    let rec sumList xs =
        match xs with
        | [] -> 0
        | y::ys -> y + sumList ys


    /// This makes 'sumList' tail recursive, using a helper function with a result accumulator.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | [] -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator + y) ys

    /// This invokes the tail recursive helper function, providing '0' as a seed accumulator.
    /// An approach like this is common in F#.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn $"The sum 1-10 is: %d{sumList oneThroughTen}"
    printfn $"The sum 1-10 is: %d{sumListTailRecursive oneThroughTen}"