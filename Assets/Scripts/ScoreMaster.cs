using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ScoreMaster {


	//Returns a list of cumulative scores, like a normal score card
	public static List<int> ScoreCumulative (List<int> rolls) {
		List<int> cumulativeScores = new List<int>();
		int runningTotal =0;

		foreach (int frameScore in ScoreFrames (rolls)){
			runningTotal+=frameScore;
			cumulativeScores.Add (runningTotal);
		}

		return cumulativeScores;
	}

	//Return a list of individual frame scores
	public static List<int> ScoreFrames (List<int> rolls){
		List<int> AlwaysAppearframeList = new List<int>();
		List<int> FinalframeList = new List<int>();
		List<int> BonusScores = new List<int>();
		List<int> numRollsLeft = new List<int>();
		int currentFrameScore =0;
		int numCompleteFrameInput = 0;
		int currentbowlnum = 0;
		bool firstball=true;

		foreach(int roll in rolls){		
			currentFrameScore+=roll;
			if (numCompleteFrameInput>=10){  				// stop adding if 10 frames complete
				
			}else{
				if (roll==10 && firstball){ 						//strike
					BonusScores.Add(2);
					AlwaysAppearframeList.Add(currentFrameScore);
					currentFrameScore=0;
					firstball=true;
					numCompleteFrameInput+=1;
					currentbowlnum+=1;
					numRollsLeft.Add(rolls.Count-currentbowlnum);
				}else if (roll==10 && !firstball){					//Spare 0,10
					BonusScores.Add(1);
					AlwaysAppearframeList.Add(currentFrameScore);
					currentFrameScore=0;
					firstball=true;
					numCompleteFrameInput+=1;
					currentbowlnum+=1;
					numRollsLeft.Add(rolls.Count-currentbowlnum);
				}else if (firstball){								//firstball 
					firstball=false;
					currentbowlnum+=1;
				}else if (! firstball && currentFrameScore==10){	//spare
					BonusScores.Add(1);
					AlwaysAppearframeList.Add(currentFrameScore);
					currentFrameScore=0;
					firstball=true;
					numCompleteFrameInput+=1;
					currentbowlnum+=1;
					numRollsLeft.Add(rolls.Count-currentbowlnum);
				}else if (! firstball && currentFrameScore<10){		//two balls under 10
					BonusScores.Add(0);
					AlwaysAppearframeList.Add(currentFrameScore);
					currentFrameScore=0;
					firstball=true;
					numCompleteFrameInput+=1;
					currentbowlnum+=1;
					numRollsLeft.Add(rolls.Count-currentbowlnum);
				}
			}
		}
		// create finalFrame list by adding in bonus scoring and hiding spare/strikes
		for (int i=0; i<numCompleteFrameInput; i++) {
			
			if (AlwaysAppearframeList[i]==10 && BonusScores[i]<=numRollsLeft[i]){
				if (BonusScores[i]==1){ 			//if spare bonus
					FinalframeList.Add(AlwaysAppearframeList[i]+rolls[rolls.Count-numRollsLeft[i]]);
				}else if (BonusScores[i]==2){		//if stike bonus
					FinalframeList.Add(AlwaysAppearframeList[i]+rolls[rolls.Count-numRollsLeft[i]]+rolls[rolls.Count-numRollsLeft[i]+1]);
				}
			}else if(AlwaysAppearframeList[i]<10) {	//not spare or strike
				FinalframeList.Add(AlwaysAppearframeList[i]);
			}
		}

		return FinalframeList;
	}


}
