# BullsAndCows
Implementation of the game "Bulls and Cows", with an AI opponent and a player rating system.

# Rules of the game

Bulls and cows is a lot like the commercial game Mastermind™️,
but using four-digit numbers instead of coloured pegs.

In this version, you play head-to-head with the computer, taking alternate turns to guess each other's number.

The winner is the first player to guess their number. You always play first and so have a small advantage.

Each guess is marked according to how many bulls (correct digits in correct locations) and how many cows (correct digits but in the wrong positions) are present in the guess.

The number of bulls and cows for each guess is displayed in red to the right of the guess.

To play the game, first enter a number for the computer to guess (it doesn't cheat!)
at the top of the table, then enter your guesses at the bottom of your column.

# How it works

The AI and record-keeping system operate on the back-end, in order to ensure that no cheating ensues.

There is no time-limit to any game which a player begins against the AI.

The client and the server communicate via AJAX and the ASP.NET API.
