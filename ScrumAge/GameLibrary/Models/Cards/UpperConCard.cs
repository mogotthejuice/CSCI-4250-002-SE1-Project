using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GameLibrary.Models;

namespace GameLibrary.Models {
    public class UpperConCard {
        public List<UpperConCardComponents> Components { get; private set;}
        public int Number {get; private set;}

        public UpperConCard(List<UpperConCardComponents> component, int number)
        {
            Components = component;
            Number = number;
        }

        public void MethodPicker() {
            foreach (var c in Components)
            {
                switch (c) {
                    //execute Method based on component
                }
            }
        }

        //respective behaviors for the components
        //immediate reward cards
        public void MoneyCard() {

        }

        public void ResourceCard() {

        }

        public void ResourceDiceRollCard() {

        }

        public void VictoryPointsCard() {

        }

        public void OverclockCard() {

        }

        public void BitcoinCard() {

        }

        public void ConConCard() {

        }

        //later reward cards
        public void OneUseOverclockCard() {

        }

        public void Any2Resources() {
            
        }
    }
}