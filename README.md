# lucca-currency-converter

My approach to solve the currency conversion probleme has been the following...

The file given by command line option contains N lines with two currencies and their corresponding rate change.
Here, we are looking for a path, going throught several of theese currencies, in order to find the final conversion
of the given amount of money.

In this way, the problem can be represented by a graph with N vertices, each line representing a link from the
first currency to the second one, with a weight of 1 (because it does take 1 step to goes from a node to an other everytime).

For instance, your example can be represented by the following graph :


CHF ------------ AUD
 |                |
EUR --- USD      JPY--- INR
                  |
                 KRW


I used the Dijkstra algorithm in order to find the optimal path, then get the final result by computing a new amount of money 
in the new currency at each iteration, going throught a node to an other.

IMPORTANT NOTE : I took into account the rounding of 4 decimals after the comma for every steps of the algorithm, however,
I found out that the output result given by my program is different with your example (59032 instead of 59033).

There are some commented Conwole.WriteLine lines in the programm that shows there are a slightly difference in the decimal
number precision.
My guess are I chose to use double number, and the result could differ a bit by using float or even decimal type.

My personnal choice is to keep this precision difference because I think double numbers are great for mathematics.
However, if you think I am wrong and using other type to get the same exact final int result would have been better,
I would be glad to learn your point of view and re ajust my program.

Mr.Hugo.
