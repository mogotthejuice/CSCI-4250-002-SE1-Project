using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLibrary.Services;

using GameLibrary.Models;


namespace UnitTests
{
    [TestFixture]
    class LicenseTileTest
    {
       public Dictionary<Resources, int> resources { get; private set; } 
       private LicenseTile tile;
       
        [SetUp]
        public void Setup()
        {
            tile = new LicenseTile();

        }

        [Test]
        public void InadequateResourceUsage_toPurchaseLicenseTile_Exception()
        {
           //Act and Assert
             if (tile.Type == LicenseTileType.FIXED_RESOURCES)
              {
                foreach (Resources resource in tile.RequiredResources.Keys)
                    if (tile.RequiredResources[resource] != resources[resource]) 
                    {
                        Assert.Throws<InvalidOperationException>(() =>tile.GetScore(resources));
                    }
                 
              }

           
           

        }
        [Test]
        public void SpecificPlayerChosenResources_equals_NecessaryResource_And_TotalResourcesUsed_isEquivalentTo_DeterminedAmountOfResources_Exception()
        {
             bool valid = false;
           //Act and Assert
           if (tile.Type == LicenseTileType.FIXED_NUM_RESOURCES & HelperFunctions.TotalNumResources(resources) != tile.NumResources)
            {
              
                Assert.Throws<InvalidOperationException>(() =>tile.GetScore(resources));
                    
                 
            }
            else
            {
                //player chooses X number resources of Y different types
                //Act and Assert
                    tile.GetScore(resources);
                    int numTypes = 0;
                    foreach (int value in resources.Values)
                        if (value > 0)
                            numTypes++;
                            valid= true;

                // clarifies that the resource type selected by user matches the available resource types for the game
                    if (numTypes != tile.NumResourceTypes)
                    {
                        Assert.Throws<InvalidOperationException>(() =>tile.GetScore(resources));
                        Assert.IsFalse(valid);

                    }
                     Assert.AreEqual(numTypes, tile.NumResourceTypes);




            }

           
           

        }
         [Test]
         public void Verfication_Of_UtilizedResources()
         {
           //Arrange
            var resource = tile.GetScore(resources);
           //Act and Assert
            int MAX_RESOURCES_USED = 7;
            int numResources = HelperFunctions.TotalNumResources(resources);
                if (numResources > MAX_RESOURCES_USED || numResources <= 0)
                {
                    Assert.Throws<InvalidOperationException>(() =>tile.GetScore(resources));
                }
                   
                 
              Assert.IsNotNull(resource);
          }

    }
}
