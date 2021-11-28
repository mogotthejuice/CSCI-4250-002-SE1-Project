using System;

using GameLibrary.Models;
using GameLibrary.Models.Locations;

namespace GameLibrary.Services
{
    public class ConCardHandler {
        private static Gameboard game = Gameboard.GetInstance();
        private static GameLog log = GameLog.GetInstance();
        public static ConsultantCard activeCard;

        public static void MethodPicker()
        {
            ConsultantCard card = game.CurrentPlayer.Board.ConsultantCards[^1];
            activeCard.Upper.Components = card.Upper.Components;
            switch (card.Upper.Components)
            { //execute Method based on component
                case UpperConCardComponents.RESOURCE:
                case UpperConCardComponents.RESOURCE_DICE_ROLL:
                case UpperConCardComponents.VICTORY_POINTS:
                    ResourceCard();
                    break;
                case UpperConCardComponents.OVERCLOCK:
                    OverclockCard();
                    break;
                case UpperConCardComponents.BITCOIN_INVESTMENT:
                    BitcoinCard();
                    break;
                case UpperConCardComponents.CONSULTANT_CARD:
                    ConConCard();
                    break;
                case UpperConCardComponents.ONE_USE_OVERCLOCK:
                    OneUseOverclockCard();
                    break;
                case UpperConCardComponents.ANY_2_RESOURCES:
                    Any2Resources();
                    break;
                default:
                    break;
            }
        }

        //Respective behaviors for the components
        //immediate reward cards
        public static void ResourceCard()
        { //works for the Food, Resource, Resources with Dice Roll, and Victory Points cards
            ResourceBoard player = game.CurrentPlayer.Board;
            ConsultantCard card = player.ConsultantCards[^1];

            if (card.Upper.Components.Equals(UpperConCardComponents.RESOURCE))
            {
                player.NumResources[card.Upper.Resource] += card.Upper.Number;
            }
            else if (card.Upper.Components.Equals(UpperConCardComponents.RESOURCE_DICE_ROLL))
            {
                int roll = GameFunctions.DiceRoll(2);
                player.NumResources[card.Upper.Resource] += roll;
            }
        }

        public static void OverclockCard()
        {
            Player player = game.CurrentPlayer;
            NerdLocation.UpgradeTool(ref player);
        }

        public static void BitcoinCard()
        {
            game.CurrentPlayer.Board.AddBitcoin();
        }

        public static void ConConCard()
        {
            game.CurrentPlayer.Board.ConsultantCards.Add(game.ConCards.Dequeue());
        }

        //later reward cards
        public static void OneUseOverclockCard()
        { //This involves a special 'one use' overclock 
            throw new NotImplementedException(); //LOW PRIORITY ITEM
        }

        public static void Any2Resources()
        {
            throw new NotImplementedException(); //LOW PRIORITY ITEM
        }

        /// <summary>
        /// Gets the type of consultant card for use for display
        /// </summary>
        /// <returns>The type of consultant card for use with the display</returns>
        public static UpperConCardComponents GetCardType()
        {
            return activeCard.Upper.Components;
        }
    }
}
