﻿using ClashRoyale.API;
using System;
using System.Linq;
using System.Collections.Generic;
using ClashRoyale.API.Models;
using ClashRoyalCli.APIExtend;

namespace ClashRoyalCli
{
    partial class Program
    {

        static void Main(string[] args)
        {
            if (ConfigRepo.NotConfigure())
            {
                Console.WriteLine("You must complete the config.json file.");
                Console.WriteLine("Create an account on https://developer.clashroyale.com and genrate a key(token)");
                Console.ReadKey();
                return;
            }
            ClientCR client = new ClientCR(ConfigRepo.Config);

            if (client.Player != null)
            {
                Console.WriteLine($"Player : {client.Player}");
            }
            if (client.Clan != null)
            {
                Console.WriteLine($"Clan   : {client.Clan}");
            }
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("1 - Rank of your clan");
                Console.WriteLine("2 - Open tournaments");
                Console.WriteLine("3 - Completed cards");
                Console.WriteLine("4 - Missing cards");
                Console.WriteLine("5 - Usage cards in local top 200");
                Console.WriteLine("6 - Upcomming chests");
                Console.WriteLine("7 - Winrate card local top 200");

                Console.WriteLine("9 - Change player and clan");
                Console.WriteLine("x - End");

                Console.WriteLine();
                Console.Write("---> Choice : ");
                var key = Console.ReadKey();
                Console.WriteLine();

                if (key.KeyChar == '1')
                {
                    Console.Write($"Local rank (y,n) :");
                    while (true)
                    {
                        var ok = Console.ReadKey();
                        Console.WriteLine();
                        if (ok.KeyChar.ToString().ToUpper() == "Y")
                        {
                            Console.WriteLine($"Local.....");
                            var posi = client.GetClanRank();
                            Console.WriteLine($"Local ank of your clan is {posi}");
                            break;
                        }
                        if (ok.KeyChar.ToString().ToUpper() == "N")
                        {
                            Console.WriteLine($"General.....");
                            var posi = client.GetClanRank(false);
                            Console.WriteLine($"General rank of your clan is {posi}");
                            break;
                        }
                    }
                }
                else if (key.KeyChar == '2')
                {
                    var tournements = client.GetTournaments();//.OrderBy(p => p.CreatedTime);
                    Console.WriteLine($" Open     Places    Status        Name");
                    foreach (var item in tournements)
                    {
                        Console.WriteLine($"{item}");
                    }
                }
                else if (key.KeyChar == '3')
                {
                    var cards = client.GetMissingCards().Where(p=>p.Missing >= 0).ToList() ;
                    Console.WriteLine($">> {cards.Count} full collected cards");
                    Console.WriteLine($">> {cards.Where(p=> p.IsMax).Count()} max cards");
                    Console.WriteLine($" Type    Level   IsMax     Cards   Name");
                    foreach (var cardtype in CardHelper.CardLevel)
                    {
                        foreach (var card in cards.Where(p => p.CardType == cardtype).OrderBy(p => p.Missing))
                        {
                            Console.WriteLine($"{card}");
                        }
                    }
                }
                else if (key.KeyChar == '4')
                {
                    var cards = client.GetMissingCards();
                    Console.WriteLine($" Type    Level   IsMax     Cards   Name");
                    foreach (var cardtype in CardHelper.CardLevel)
                    {
                        foreach (var card in cards.Where(p => p.CardType == cardtype && p.Missing < 0).OrderByDescending(p => p.Missing))
                        {
                            Console.WriteLine($"{card}");
                        }
                    }
                }
                else if (key.KeyChar == '9')
                {
                    Console.WriteLine();
                    Console.WriteLine("1 - Change player and clan");
                    Console.WriteLine("2 - Change clan");
                    Console.WriteLine();
                    Console.Write("---> Choice : ");

                    var change = Console.ReadKey();
                    Console.WriteLine();
                    Console.WriteLine();
                    if (change.KeyChar == '1')
                    {
                        Console.Write($"Player tag :");
                        var tag = Console.ReadLine();
                        if (!tag.StartsWith("#")) tag = "#" + tag;
                        var playerlocal = client.GetPlayer(tag);
                        if (playerlocal != null)
                        {
                            Console.WriteLine($"Player : {playerlocal.Name}");
                            client.SetPlayertag(playerlocal.Tag);
                            ConfigRepo.SetPlayertag(playerlocal.Tag);
                            Console.Write($"Change clan (y,n) :");
                            while (true)
                            {
                                var ok = Console.ReadKey();
                                Console.WriteLine();
                                if (ok.KeyChar.ToString().ToUpper() == "Y")
                                {
                                    Console.WriteLine($"Clan : {playerlocal.Clan.Name}");
                                    client.SetClanTag(playerlocal.Clan.Tag);
                                    ConfigRepo.SetClanTag(playerlocal.Clan.Tag);
                                    break;
                                }
                                if (ok.KeyChar.ToString().ToUpper() == "N") break;
                            }
                        }
                        else
                        {
                            Console.Write($"Not exist");
                        }
                    }
                    else if (change.KeyChar == '2')
                    {
                        Console.Write($"Clan tag :");
                        var tag = Console.ReadLine();
                        if (!tag.StartsWith("#")) tag = "#" + tag;
                        var clanlocal = client.GetClan(tag);
                        if (clanlocal != null)
                        {
                            Console.WriteLine($"Clan : {clanlocal.Name}");
                            client.SetClanTag(tag);
                            ConfigRepo.SetClanTag(tag);
                        }
                        else
                        {
                            Console.Write($"Not exist");
                        }
                    }
                }
                else if (key.KeyChar == '5')
                {
                    Console.WriteLine($"wait ...");
                    var clanlocal = client.GetDetailClan();
                    var cards = client.GetCarsUsageTopRanking(clanlocal.Location.Id);
                    Console.WriteLine($"       Card  Usage");
                    var i = 1;
                    var usage = 100000;
                    foreach (var card in cards)
                    {
                        var posi = "   ";
                        if (usage != card.UsageCount)
                        {
                            posi = i.ToString().PadLeft(3);
                            i++;
                        }
                        Console.WriteLine($"{posi} : {card}");
                        usage = card.UsageCount;
                    }
                }
                else if (key.KeyChar == '6')
                {
                    var chests = client.GetChests();
                    Console.WriteLine($" Num   Chest");
                    foreach (var chest in chests)
                    {
                        Console.WriteLine($"{chest}");
                    }
                }
                else if (key.KeyChar == '7')
                {
                    Console.WriteLine($"wait ...");
                    var clanlocal = client.GetDetailClan();
                    var cards = client.GetCardWins(clanlocal.Location.Id);
                    Console.WriteLine($"  Wins   Card");
                    foreach (var card in cards)
                    {
                        Console.WriteLine($"{card}");
                    }
                }
                else if (key.KeyChar == 'x')
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
