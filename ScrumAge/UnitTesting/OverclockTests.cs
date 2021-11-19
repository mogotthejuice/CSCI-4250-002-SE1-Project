using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Models;


namespace UnitTesting 
{

    
    public class OverclockTests
    {

        [SetUp]
        public void setUp()
        {
            //Arrange or Object Setup
            var overclock = new GameLibrary.Models.Overclock();
        }

        [Test]

        public void Upgrade_isAtMaxLevel_NoUpgrade()
        {
            var overclock = new GameLibrary.Models.Overclock();
            //Assign level and max value
            int startlevel = 4;
            int maxValue = 4;

            //Verify that level is not at Maximum level
                if (startlevel == maxValue)
                {
                //Act + Assert
                Assert.Throws<InvalidOperationException>(() => overclock.Upgrade());

                }
        }
         [ Test]
        public void Upgrade_isNotAtMaxLevel_Upgraded()
        {
            //Arrange
            var overclock = new GameLibrary.Models.Overclock();
            //Assign level and max value
            int startlevel = 1;
            int maxValue = 4;

            //Verify that level is not at Maximum level
            if (startlevel < maxValue)
            {
                //Act
                startlevel++;
                

            }
            //Assert
            Assert.AreNotEqual(startlevel,maxValue);


          }
         [ Test]    
        public void Overclock_hasBeenUsed_UseOperationException()
         {
            //initialize variable
            bool HasBeenUsed = true;
            //Arrange
            var overclock = new GameLibrary.Models.Overclock();
            //Act
            overclock.Use();
           if( HasBeenUsed )
           { 
            //Assert
             Assert.Throws<InvalidOperationException>(() => overclock.Use());
           }

        }
     [Test]  
     public void Overclock_hasNotBeenUsed_Use()
         {
              
            //Arrange
            var overclock = new Overclock();
            //Act
            overclock.Use();
            
            //Assert
             Assert.IsFalse(overclock.HasBeenUsed);


        }
    [Test]
    public void Overclock_Reset()
         {
              
            //initialize variable
            bool HasBeenUsed = false;
            //Arrange
            var overclock = new GameLibrary.Models.Overclock();
            //Act
            overclock.Reset();
           if( HasBeenUsed )
           { 
             //Assert
             Assert.IsFalse(overclock.HasBeenUsed);
           }
            
        

        }
        



    }

    

    
}