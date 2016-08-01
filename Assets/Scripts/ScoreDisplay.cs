using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	public void FillRoll(List<int> rolls){
		string scoresString = FormatRolls(rolls);
		for (int i=0; i< scoresString.Length; i++){
			rollTexts[i].text = scoresString[i].ToString();
		}

	}

	public void FillFrames (List<int> frames) {
		for (int i=0; i< frames.Count; i++){
			frameTexts[i].text = frames[i].ToString();
		}
	}

	public string IsStrikeOrSpare(List<int> rolls){
		string scoresString = FormatRolls(rolls);
		string lastaction = scoresString.Substring(scoresString.Length -1);
		if (scoresString == "X X X X X X X X X XXX"){
			return ("Perfect Game!!!");
		}else if (lastaction == "X" || lastaction ==" "){
			return "Strike!!";
		}else if (lastaction =="/"){
			return "Spare!";
		}else {
			return "Null";
		}
	}

	public static string FormatRolls (List<int> rolls){
		string output ="";

		// Method 1
		for (int i=0; i< rolls.Count; i++){
			if (rolls[i]==0){
				output+= "-";
			}else if (output.Length==20){  			//final ball
				if (rolls[i]==10){						//last ball is 10, either strike or spare
					if (rolls[i-1]==0){
						output += "/";
					}else{
						output += "X";
					}
				}else if (rolls[i-2]==10) { 			// Strike last frame: two bonus balls
					if (rolls[i-1]+rolls[i]==10){
						if (rolls[i-1]==10){				// two strikes in a row on last frame
							output += "-";
						}else {
							output += "/";
						}
					}else {
						output += rolls[i].ToString();		//normal
					}
				}else {
					output += rolls[i].ToString();		//normal
				}

			}else if(output.Length % 2==0){ 	//first ball of frame
				if (rolls[i]==10){ 						//Strike
					if (output.Length==18){
						output += "X";                  //final frame exception
					}else{
						output += "X ";
					}
				}else {
					output += rolls[i].ToString();		//normal
				}
			}else if (output.Length % 2==1){	//second ball of frame
				if (rolls[i]+rolls[i-1]==10){ 			//spare
					if (rolls[i]==0){
						output += "-";  //final frame exception
					}else	{
						output += "/";
					}
				}else if (rolls[i]==10){
					output += "X";
				}else {
					output += rolls[i].ToString();		//normal
				}
			}
		}

//		// Method 2
//		for (int i=0; i< rolls.Count; i++){
//			if(output.Length % 2==0){ 	//first ball of frame
//				if (rolls[i]==10){ 						//Strike
//					if 	(output.Length==18){
//						output += "X";						//last frame
//					} else if (output.Length==20){
//						if (rolls[i-1]!=0){
//							output += "X";
//						}else {
//							output += "/";			//Exception of spare in last ball with a 10
//						}
//					}else	{				
//						output += "X ";
//					}
//				}else if (output.Length==20 && rolls[i]+rolls[i-1]==10 && rolls[i-1]!=10){
//					output += "/";				//Exception of spare in last ball
//				}else if (output.Length==20 && rolls[i]+rolls[i-1]==10 && rolls[i-1]==10){
//					output += "-";	
//				} else {
//					if (rolls[i]==0){
//						output+= "-";
//					}else{
//						output += rolls[i].ToString();		//normal
//					}		
//				}
//			}else if (output.Length % 2==1){	//second ball of frame
//				if (rolls[i]+rolls[i-1]==10){ 			//spare
//					if (rolls[i]==0){
//						output+="-";				//finalframe 10 0 exception!
//					}else{
//						output += "/";
//					}
//				}else if (rolls[i]==10){
//					output += "X";					//finalframe 10 on sceond ball!
//				}else {
//					if (rolls[i]==0){
//						output+= "-";
//					}else{
//						output += rolls[i].ToString();		//normal
//					}
//				}
//			}
//		}

//		// Their method
//		for (int i=0; i< rolls.Count; i++){
//			int box = output.Length+1;								//score box 1 to 21
//
//			if (rolls[i] ==0) {										//Always enter 0 as -
//				output += "-";
//			} else if ((box % 2 ==0 || box==21) && rolls[i-1] +rolls[i] ==10) {	//Spare anywhere
//				output +="/";
//			} else if (box >=19 && rolls[i] ==10) {					//strike in frame 10
//				output += "X";
//			} else if (rolls[i] == 10) {							//strike in frame 1-9
//				output += "X ";
//			} else {
//				output += rolls[i].ToString();						// Normal 1-9 bowl
//			}
//		}


		return output;
	}
}
