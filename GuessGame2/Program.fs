open System

type GuessResult =
    | TooLow
    | TooHigh
    | Win

let chooseSecretNumber() =
    Random.Shared.Next(1, 101)

let getGuess() =
    printf "Guess a number between 1 and 100: "
    Console.ReadLine() |> int

let checkGuess (target: int) (guess: int) =
    match compare guess target with
    | 0 -> GuessResult.Win
    | -1 -> GuessResult.TooLow
    | 1 -> GuessResult.TooHigh
    | _ -> failwith "Invalid guess"

let printGuessResult guessResult =
    match guessResult with
    | GuessResult.Win -> printfn "You guessed correctly!"
    | GuessResult.TooLow -> printfn "Too low!"
    | GuessResult.TooHigh -> printfn "Too high!"
    guessResult

let guessGame() =
    let target = chooseSecretNumber()
    let rec gameLoop target turn =
        let result = 
            getGuess()
            |> checkGuess target
            |> printGuessResult

        match result with
        | GuessResult.Win -> printfn "You guessed in %d tries" turn
        | _ when turn = 10 -> printfn "You lose! The number I was thinking of was %i" target
        | _ -> gameLoop target (turn + 1)
            
    gameLoop target 1

guessGame()