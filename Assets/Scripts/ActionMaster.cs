using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster{

	public enum Action{Tidy, Reset, EndTurn, EndGame};

	private int[] bowls = new int[21];
	private int bowl = 1 ;

	public static Action NextAction(List<int> pinFalls){
		ActionMaster am = new ActionMaster();
		Action currentAction = new Action();

		foreach(int pinFall in pinFalls){
			currentAction = am.Bowl(pinFall);
		}
		return currentAction;
	}

	private Action Bowl (int pins){ 
		if(pins < 0 || pins > 10){throw new UnityException ("Invalid pins");}

		bowls[bowl-1] = pins;

		if (bowl==21){//final last bonus ball
			return Action.EndGame;
		}

		if (bowl==20){//final frame
			if (pins==10){
				bowl ++;
				return Action.Reset;
			}else if (bowls[18]==10){
				bowl++;
				return Action.Tidy;
			}else if ((bowls[18]+bowls[19])==10) { //spare on last frame, or strike then 0
				bowl ++;
				return Action.Reset;
			}else {
				//clear bowl and bowls?
				return Action.EndGame;
			}
		}

		if (bowl==19){//final frame
			if (pins==10){
				bowl ++;
				return Action.Reset;
			}else {
				bowl ++;
				return Action.Tidy;
			}
		}


		if (bowl % 2 ==1) {// begin frame
			if (pins==10){
				bowl +=2;
				return Action.EndTurn;
			}else {
				bowl +=1;
				return Action.Tidy;
			}
		} else if (bowl % 2 ==0){// End of frame
			bowl ++;
			return Action.EndTurn;
		}

		throw new UnityException ("Not sure what action to return!");
	}
}
