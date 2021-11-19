using System;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using GameLibrary.Models;
using GameLibrary.Models.Cards;

namespace GameLibrary.Services {
    public static class FileReader{
        static readonly string rootFolder = "ScrumAge/GameLibrary/TextFiles"; 
        public static void ReadCardDeck(){
            //string path = "/Users/briannamartinson/Documents/GitHub/CSCI-4250-002-SE1-Project/ScrumAge/GameLibrary/TextFiles/ConsultantCardDeck.csv";
            string path = @"ScrumAge/GameLibrary/TextFiles/ConsultantCardDeck.csv";

            // var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly(). CodeBase);
            // var iconPath = Path.Combine(outPutDirectory, "GameLibrary\\TextFiles\\ConsultantCardDeck.csv");
            // string path = new Uri(iconPath ).LocalPath;

            try{
                if(File.Exists(path)){
                    string[] lines = File.ReadAllLines(path);
                    foreach(string line in lines){
                        string[] words = line.Split(',');
                        UpperConCard up = new UpperConCard((UpperConCardComponents)Enum.Parse(typeof(UpperConCardComponents), words[0]), Int32.Parse(words[1]), ((Resources)Enum.Parse(typeof(Resources), words[2])));
                        ILowerConCard bot;
                        if(words[3].Equals("green")){
                            bot = new GreenLowerConCard((GreenConCardBackground)Enum.Parse(typeof(GreenConCardBackground), words[4]));
                        }
                        else{
                            bot = new SandLowerConCard(((SandConCardPerson)Enum.Parse(typeof(SandConCardPerson), words[4])), Int32.Parse(words[5]));
                        }
                        ConsultantCard card = new ConsultantCard(up, bot);
                        Gameboard.GetInstance().ConCards.Enqueue(card);
                    }
                }
            }
            catch (Exception e) {
                Gameboard.GetInstance().AddToGameLog($"Sorry, {e.Message}");
                return;
            }
        }

        public static void ReadTileDeck(){
            string textFile = "ScrumAge/GameLibrary/TextFiles/LicenseTileDeck.csv"; 
            try{
                if(File.Exists(textFile)){
                    string[] lines = File.ReadAllLines(textFile);
                    foreach(string line in lines){
                        string[] words = line.Split(',');

                        switch(words[0]){
                            case "VARIABLE_NUM_RESOURCES":
                                LicenseTile tileV = new LicenseTile();
                                Gameboard.GetInstance().LicenseTiles.Enqueue(tileV);
                                break;
                            case "FIXED_NUM_RESOURCES":
                                LicenseTile tileFN = new LicenseTile(Int32.Parse(words[1]), Int32.Parse(words[2]));
                                Gameboard.GetInstance().LicenseTiles.Enqueue(tileFN);
                                break;
                            case "FIXED_RESOURCES":
                                Dictionary<Resources, int> reqResources = new Dictionary<Resources, int>();
                                //TODO loop - add to reqResources for n paired entries 
                                reqResources.Add((Resources)Enum.Parse(typeof(Resources), words[1]), 1);
                                if(reqResources.ContainsKey((Resources)Enum.Parse(typeof(Resources), words[2]))){
                                    reqResources[(Resources)Enum.Parse(typeof(Resources), words[2])] += 1;
                                }
                                else{
                                    reqResources.Add((Resources)Enum.Parse(typeof(Resources), words[2]), 1);
                                }
                                if(reqResources.ContainsKey((Resources)Enum.Parse(typeof(Resources), words[3]))){
                                    reqResources[(Resources)Enum.Parse(typeof(Resources), words[3])] += 1;
                                }
                                else{
                                    reqResources.Add((Resources)Enum.Parse(typeof(Resources), words[3]), 1);
                                }
                                LicenseTile tileF = new LicenseTile(reqResources);
                                Gameboard.GetInstance().LicenseTiles.Enqueue(tileF);
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception e) {
                Gameboard.GetInstance().AddToGameLog($"Sorry, {e.Message}");
                return;
            }
        }
    }
}