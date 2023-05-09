module DiscriminatedUnions

    /// The following represents the suit of a playing card.
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    /// A Discriminated Union can also be used to represent the rank of a playing card.
    type Rank =
        /// Represents the rank of cards 2 .. 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// Discriminated Unions can also implement object-oriented members.
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    /// This is a record type that combines a Suit and a Rank.
    /// It's common to use both Records and Discriminated Unions when representing data.
    type Card = { Suit: Suit; Rank: Rank }

    /// This computes a list representing all the cards in a deck.
    let fullDeck = 
        [ for suit in [Hearts; Diamonds; Clubs; Spades] do
            for rank in Rank.GetAllRanks() do
                yield { Suit = suit; Rank = rank } ]

    /// Convert a 'Card' object to a string
    let showPlayingCard (c: Card) =
        let rankString =
            match c.Rank with
            | Ace -> "Ace"
            | King -> "King"
            | Queen -> "Queen"
            | Jack -> "Jack"
            | Value n -> string n
        let suitString =
            match c.Suit with
            | Clubs -> "Clubs"
            | Diamonds -> "Diamonds"
            | Spades -> "Spades"
            | Hearts -> "Hearts"
        rankString + " of " + suitString

    let printAllCards() =
        for card in fullDeck do
            printfn $"{showPlayingCard card}"