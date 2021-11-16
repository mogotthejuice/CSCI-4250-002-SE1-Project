using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using GameLibrary.Models;

namespace UnitTesting {
	[TestFixture]
	class ResourceBoardTest {
		private ResourceBoard board;

		[SetUp]
		public void Setup() {
			board = new ResourceBoard();
		}

		[Test]
		public void ResourceBoard_IsInitialized() {
			Assert.IsNotNull(board);
		}

		[TestCase(Resources.Coffee)]
		[TestCase(Resources.USB_Sticks)]
		[TestCase(Resources.CPU_Cores)]
		[TestCase(Resources.Power)]
		[TestCase(Resources.Money)]
		public void GetNumResource_WithValidResource_ReturnsCorrectNum(Resources resource) {
			int expected = 5;
			board.NumResources[resource] = expected;

			Assert.AreEqual(expected, board.GetNumResource(resource));
		}
		/*
		[Test]
		public void GetNumResource_WithInvalidResource_ThrowsArgumentException() {
			Assert.Throws<ArgumentException>(() => board.GetNumResource(Resources.Overclock));
		}*/

		[Test]
		public void AddBitcoin_WithLessThanMaxInvestments_IncrementsNumBitcoinInvestments() {
			int expected = board.NumBitcoinInvestments + 1;

			board.AddBitcoin();

			Assert.AreEqual(expected, board.NumBitcoinInvestments);
		}

		[Test]
		public void AddBitcoin_WithMaxInvestments_ThrowsInvalidOperationException() {
			const int MAX_BITCOINS = 10;
			while (board.NumBitcoinInvestments < MAX_BITCOINS)
				board.AddBitcoin();

			Assert.Throws<InvalidOperationException>(() => board.AddBitcoin());
		}

		[Test]
		public void AddDeveloper_WithLessThanMaxDevelopers_IncrementsNumDevelopersOwnedAndUnplaced() {
			int expectedOwned = board.NumDevelopersOwned + 1;
			int expectedUnplaced = board.NumDevelopersUnplaced + 1;

			board.AddDeveloper();

			Assert.AreEqual(expectedOwned, board.NumDevelopersOwned);
			Assert.AreEqual(expectedUnplaced, board.NumDevelopersUnplaced);
		}

		[Test]
		public void AddDeveloper_WithMaxDevelopers_ThrowsInvalidOperationException() {
			const int MAX_DEVELOPERS = 10;
			while (board.NumDevelopersOwned < MAX_DEVELOPERS)
				board.AddDeveloper();

			Assert.Throws<InvalidOperationException>(() => board.AddDeveloper());
		}

		[Test]
		public void AddConsultantCard_WithValidCard_AddsCard()
		{
			ConsultantCard card = new ConsultantCard(null, null);

			board.AddConsultantCard(card);

			Assert.AreSame(card, board.ConsultantCards[board.ConsultantCards.Count - 1]);
		}

		[Test]
		public void AddConsultantCard_WithNullCard_ThrowsArgumentNullException() {
			Assert.Throws<ArgumentNullException>(() => board.AddConsultantCard(null));
		}

		[Test]
		public void AddLicenseTile_WithValidTile_AddsTile()	{
			LicenseTile tile = new LicenseTile();

			board.AddLicenseTile(tile);

			Assert.AreSame(tile, board.LicenseTiles[board.LicenseTiles.Count - 1]);
		}

		[Test]
		public void AddLicenseTile_WithNullTile_ThrowsArgumentNullException() {
			Assert.Throws<ArgumentNullException>(() => board.AddLicenseTile(null));
		}
	}
}
