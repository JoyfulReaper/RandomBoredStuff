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
    if guesses = maxGuesses then
        printfn "You lose!"
    else
        printfn "Guess a number between 1 and 100"
        let guess = Console.ReadLine() |> int
        match checkGuess target guess with
        | result.Win -> printfn "You guessed in %d tries" (guesses + 1)
        | _ -> guessGame target (guesses + 1) maxGuesses

let playGuessGame() =
    let target = pickTarget()
    guessGame target 0 10

playGuessGame()