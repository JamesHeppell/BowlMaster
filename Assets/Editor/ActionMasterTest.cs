using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;


[TestFixture]
public class ActionMasterTest{

	private List<int> pinFalls;
	private ActionMaster2.Action endTurn = ActionMaster2.Action.EndTurn;
	private ActionMaster2.Action tidy = ActionMaster2.Action.Tidy;
	private ActionMaster2.Action endGame = ActionMaster2.Action.EndGame;
	private ActionMaster2.Action reset = ActionMaster2.Action.Reset;

	[SetUp]
	public void Setup(){
		pinFalls = new List<int> ();
	}

	[Test]
	public void T00PassingTest() {
		Assert.AreEqual (1,1);
	}

	[Test]
	public void T01OneStrikeREturnsEndTurn(){
		pinFalls.Add(10);
		Assert.AreEqual(endTurn, ActionMaster2.NextAction (pinFalls));
	}

	[Test]
	public void T02Bowl8ReturnsTidy(){
		pinFalls.Add(8);
		Assert.AreEqual (tidy, ActionMaster2.NextAction(pinFalls));
	}

	[Test]
	public void T03Bowl28SpareReturnsEndTurn (){
		int[] rolls = {8,2};
		Assert.AreEqual (endTurn, ActionMaster2.NextAction(rolls.ToList()));
	}

	[Test]
	public void T04BowllastbowlNotSpareReturnsEndGame (){
		int[] rolls = {3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,5};
		Assert.AreEqual(endGame, ActionMaster2.NextAction(rolls.ToList()));
	}

	[Test]
	public void T05GetLastBonusBallReturnsReset (){
		int[] rolls = {3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,7};
		Assert.AreEqual(reset, ActionMaster2.NextAction(rolls.ToList()));
	}

	[Test]
	public void T06GetBonusBallonDoubleStrikeFinalFrameReturnsReset (){
		int[] rolls = {3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 10,10};
		Assert.AreEqual(reset, ActionMaster2.NextAction(rolls.ToList()));
	}

	[Test]
	public void T07FinalFrameBowl100ReturnsTidy (){
		int[] rolls = {3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 10,0};
		Assert.AreEqual(tidy, ActionMaster2.NextAction(rolls.ToList()));
	}

	[Test]
	public void T08CheckResetAtStrikeLastFrame (){
		int [] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10};
		Assert.AreEqual(reset, ActionMaster2.NextAction(rolls.ToList()));
	}

	[Test]
	public void T09CheckEndGameFromrollarray(){
		int [] rolls = {1,1, 10, 10, 1,9, 1,1, 1,1, 1,1, 8,2, 7,3, 9,1, 9 };
		Assert.AreEqual(endGame, ActionMaster2.NextAction(rolls.ToList()));
	}

	[Test]
	public void T10CheckEndGameFromrollarray(){
		int [] rolls = {1,1, 10, 10, 1,9, 1,1, 1,1, 1,1, 8,2, 7,3, 10,5 };
		Assert.AreEqual(tidy, ActionMaster2.NextAction(rolls.ToList()));
	}

	[Test]
	public void T11SecondBowl10ReturnEndTurn(){
		int [] rolls = {1,1, 0,10};
		Assert.AreEqual(endTurn, ActionMaster2.NextAction(rolls.ToList()));
	}

	[Test]
	public void T12Bowl10asSparethen51ReturnEndTurn(){
		int [] rolls = {1,1, 0,10, 5,1};
		Assert.AreEqual(endTurn, ActionMaster2.NextAction(rolls.ToList()));
	}

	[Test]
	public void T13EndGameAfter3FinalStrikesReturnEndGame(){
		int [] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,10,10};
		Assert.AreEqual(endGame, ActionMaster2.NextAction(rolls.ToList()));

	}

	[Test]
	public void T14ZerooneReturnEndTurn(){
		int [] rolls = {0,1};
			Assert.AreEqual(endTurn, ActionMaster2.NextAction(rolls.ToList()));

	}

}
