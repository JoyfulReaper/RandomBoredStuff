module Arrays =

     /// This is The empty array.  Note that the syntax is similar to that of Lists, but uses `[| ... |]` instead.
    let array1 = [| |]

    /// Arrays are specified using the same range of constructs as lists.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// Array of numbers from 1 to 1000
    let array3 = [| 1 .. 1000 |]

    /// This is an array containing only the words "hello" and "world".
    let array4 =
        [| for word in array2 do
               if word.Contains("l") then
                   yield word |]

    /// This is an array initialized by index and containing the even numbers from 0 to 2000.
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    /// Sub-arrays are extracted using slicing notation.
    let evenNumbersSlice = evenNumbers[0..500]

    /// You can loop over arrays and lists using 'for' loops.
    for word in array4 do
        printfn $"word: {word}"


    // You can modify the contents of an array element by using the left arrow assignment operator.
    // To learn more about this operator, see: https://learn.microsoft.com/dotnet/fsharp/language-reference/values/index#mutable-variables
    array2[1] <- "WORLD!"
    printfn "array2: %A" array2

    /// You can transform arrays using 'Array.map' and other functional programming operations.
    /// The following calculates the sum of the lengths of the words that start with 'h'.
    /// Note that in this case, similar to Lists, array2 is not mutated by Array.filter.
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn $"The sum of the lengths of the words in Array 2 is: %d{sumOfLengthsOfWords}"