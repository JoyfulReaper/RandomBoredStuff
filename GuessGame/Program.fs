(*
let isOdd x = x % 2 <> 0

let addOneIfOdd input =
    let result =
        if isOdd input then
            input + 1
        else
            input
    result

printfn "%d" (addOneIfOdd 2)
*)

////// Guess the number game //////
(*
open System

let target = Random().Next(1, 101)
let mutable guesses = 0

type result =
    | TooLow
    | TooHigh
    | Win

let checkGuess target guess =
    if guess = target then
        printfn "You win!"
        result.Win
    elif guess < target then
        printfn "Too low!"
        result.TooLow
    else
        printfn "Too high!"
        result.TooHigh

let rec guessGame guesses =
    if guesses = 10
    then
        printfn "You lose!"
    else
    printfn "Guess a number between 1 and 100"
    let guess = Console.ReadLine() |> int
    match checkGuess target guess with
    | result.Win -> printfn "You guessed in %d tries" guesses
    | _ -> guessGame (guesses + 1)

guessGame guesses
*)

////// Guess the number game more functional //////
(*
open System

let pickTarget() =
    Random().Next(1, 101)

type result =
    | TooLow
    | TooHigh
    | Win

//compare is a built-in function in F# that compares two values of the same type and returns an integer that represents their order.
//It returns 0 if the two values are equal, -1 if the first value is less than the second, and 1 if the first value is greater than the second.
let checkGuess target guess =
    match compare guess target with
    | 0 -> printfn "You win!"; result.Win
    | -1 -> printfn "Too low!"; result.TooLow
    | 1 -> printfn "Too high!"; result.TooHigh
    | _ -> failwith "Invalid guess"

let rec guessGame target guesses maxGuesses =
    match guesses with
    | n when n = maxGuesses -> printfn "You lose!"
    | _ ->
        printfn "Guess a number between 1 and 100"
        let guess = Console.ReadLine() |> int
        match checkGuess target guess with
        | result.Win -> printfn "You guessed in %d tries" (guesses + 1)
        | _ -> guessGame target (guesses + 1) maxGuesses

let playGuessGame() =
    let target = pickTarget()
    guessGame target 0 10

playGuessGame()
*)

///// Improved Functional Guess the number game /////
open System

module GuessTheNumber =

    let pickTarget() =
        Random().Next(1, 101)

    type GuessResult =
        | TooHigh
        | TooLow
        | Win

    let checkGuess guess target =
        match compare target guess with
        | 0 -> GuessResult.Win
        | -1 -> GuessResult.TooLow
        | 1 -> GuessResult.TooHigh
        | _ -> failwith "Invalid guess"

    let printResult result numGuesses =
        match result with
        | GuessResult.Win -> printfn "You guessed correctly in %d tries!" (numGuesses + 1)
        | GuessResult.TooHigh -> printfn "Too high!"
        | GuessResult.TooLow -> printfn "Too low!"
            
    let isGameover numGuesses maxGuesses =
        numGuesses = maxGuesses
        

    let playGuessGame maxGuesses =
        let target = pickTarget()
        let rec gameLoop numGuesses = 
            if isGameover numGuesses maxGuesses then
                printfn "You lose!"
            else
            printfn "Guess a number between 1 and 100"
            let guess = Console.ReadLine() |> int
            let result = checkGuess target guess
            printResult result numGuesses
            match result with
            | GuessResult.Win -> ()
            | _ -> gameLoop (numGuesses + 1)

        gameLoop 0

    playGuessGame 10