﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Program
    {
        public static int[] deck = new int[52] { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };

        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to blackjack");
            Console.ReadLine();

            int playerOneTotal = FirstDeal(1);

            Console.WriteLine($"Total {playerOneTotal}\n");

            int playerTwoTotal = FirstDeal(2);

            Console.WriteLine($"Total {playerTwoTotal}\n");
            string p1Choice = string.Empty;
            string p2Choice = string.Empty; 
            do
            {
                if (p1Choice.ToUpper() != "STAY")
                {
                    playerOneTotal = HitOrStay(1, playerOneTotal, out p1Choice);
                }
                
                if (playerOneTotal > 21)
                {
                    Console.WriteLine("Bust");

                    break;
                }

                if (p2Choice.ToUpper() != "STAY")
                {
                    playerTwoTotal = HitOrStay(2, playerTwoTotal, out p2Choice);
                }
                
                if (playerTwoTotal > 21)
                {
                    Console.WriteLine("Bust");

                    break;
                }
            }
            while ((playerOneTotal <= 21 && p1Choice.ToUpper()!="STAY")||(playerTwoTotal <= 21 && p2Choice.ToUpper()!= "STAY"));


            //announce the winner
            if (playerOneTotal > 21 || (playerTwoTotal < 21 && playerTwoTotal > playerOneTotal))
            {
                Console.WriteLine("Player 2 Wins");
            }

            else if (playerTwoTotal > 21 || (playerOneTotal < 21 && playerOneTotal > playerTwoTotal))
            {
                Console.WriteLine("Player 1 wins");
            }


            Console.ReadLine();
        }

        /// <summary>
        /// Deal method that deals a card of value 1 - 10.
        /// </summary>
        /// <returns>Returns a value between 1 - 10</returns>
        public static int Deal()
        {
            var deckIndex = new Random();

            var index = 0;

            do
            {
                index = deckIndex.Next(0, 51);

            } while (deck[index] == 0);

            var tmp = deck[index];

            //set it to 0 to indicate already dealt card
            deck[index] = 0;

            return tmp;
        }

        public static int FirstDeal(int playerId)
        {
            int p = 0;
            int playerTotal = 0;

            //deal two cards to first player then sum, if less than 21, move on to player 2 
            do
            {
                int deckDeal = Deal();

                Console.WriteLine($"Player {playerId} - Card dealt: ");

                playerTotal += deckDeal;

                Console.WriteLine($"{deckDeal}");

                p++;
            }
            while (p < 2);

            return playerTotal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="playerId"></param>
        /// <param name="playerTotal"></param>
        /// <returns></returns>
        public static int HitOrStay(int playerId, int playerTotal, out string choice)
        {
            
            var pChoice = string.Empty;

            if (playerTotal <= 21)
            {
                do
                {
                    Console.WriteLine($"Player {playerId} - Hit or Stay");

                    pChoice = Console.ReadLine();

                    if (pChoice.ToUpper() == "HIT")
                    {
                        int deckDealp1 = Deal();

                        Console.WriteLine($"Player {playerId} - Card dealt: ");

                        playerTotal += deckDealp1;

                        Console.WriteLine(deckDealp1);

                        Console.WriteLine($"Player {playerId} total: {playerTotal}\n");
                    }
                    else if (pChoice.ToUpper() == "STAY")
                    {
                        Console.WriteLine($"Player {playerId} total: {playerTotal}");
                        break;
                    }

                    else
                    {
                        Console.WriteLine("Invalid input, please select Hit or Stay\n");
                    }

                } while (pChoice.ToUpper() != "HIT" && pChoice.ToUpper() != "STAY");

                choice = pChoice;

                return playerTotal;
            }

            else
            {
                choice = pChoice;

                return playerTotal;
            }
        }
    }
}
