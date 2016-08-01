using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;


[TestFixture]
public class ScoreDisplayTest{


	[Test]
	public void T00PassingTest() {
		Assert.AreEqual (1,1);
	}

	[Test]
	public void T01Bowl1() {
		int[] rolls = {1};
		string rollsString = "1";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T02Bowl12345() {
		int[] rolls = {1,2,3,4,5};
		string rollsString = "12345";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T03Bowl12104() {
		int[] rolls = {1,2,10,4};
		string rollsString = "12X 4";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T04Bowl12345() {
		int[] rolls = {1,2,3,4,5,5};
		string rollsString = "12345/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T05Bowl10() {
		int[] rolls = {10};
		string rollsString = "X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T06Bowl1001054641010() {
		int[] rolls = {10,0,10,5,4,6,4,10,10};
		string rollsString = "X -/546/X X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T07BowlAll10() {
		int[] rolls = {10,10,10,10,10,10,10,10,10,10,10,10};
		string rollsString = "X X X X X X X X X XXX";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T08BowlAll10010() {
		int[] rolls = {10,10,10,10,10,10,10,10,10,10,0,10};
		string rollsString = "X X X X X X X X X X-/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T09BowlAll1036() {
		int[] rolls = {10,10,10,10,10,10,10,10,10,10,3,6};
		string rollsString = "X X X X X X X X X X36";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T10BowlAll1037() {
		int[] rolls = {10,10,10,10,10,10,10,10,10,10,3,7};
		string rollsString = "X X X X X X X X X X3/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T11BowlEndinSpare5() {
		int[] rolls = {10,3,4,10,3,7,10,0,1,10,7,3,10,3,7,5};
		string rollsString = "X 34X 3/X -1X 7/X 3/5";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T12BowlEndinSpare10() {
		int[] rolls = {10,3,4,10,3,7,10,0,1,10,7,3,10,3,7,10};
		string rollsString = "X 34X 3/X -1X 7/X 3/X";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T13BowlEndinSpare0() {
		int[] rolls = {10,3,4,10,3,7,10,0,1,10,7,3,10,0,10,0};
		string rollsString = "X 34X 3/X -1X 7/X -/-";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T14BowlEndinSpare10() {
		int[] rolls = {10,3,4,10,3,7,10,0,1,10,7,3,10,0,10,10};
		string rollsString = "X 34X 3/X -1X 7/X -/X";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T15BowlEndinStrike100() {
		int[] rolls = {10,3,4,10,3,7,10,0,1,10,7,3,10,10,10,0};
		string rollsString = "X 34X 3/X -1X 7/X XX-";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T16BowlEndinStrike00() {
		int[] rolls = {10,3,4,10,3,7,10,0,1,10,7,3,10,10,0,0};
		string rollsString = "X 34X 3/X -1X 7/X X--";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T17BowlEndinStrike37() {
		int[] rolls = {10,3,4,10,3,7,10,0,1,10,7,3,10,10,3,7};
		string rollsString = "X 34X 3/X -1X 7/X X3/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}

	[Test]
	public void T18BowlEndinspare10() {
		int[] rolls = {10,3,4,10,3,7,10,0,1,10,7,3,10,3,7,10};
		string rollsString = "X 34X 3/X -1X 7/X 3/X";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls(rolls.ToList()));
	}
}
