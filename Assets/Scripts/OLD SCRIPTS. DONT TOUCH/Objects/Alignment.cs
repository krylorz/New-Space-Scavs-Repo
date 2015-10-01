using UnityEngine;
using System.Collections;

public enum AlignmentType{FRIENDLY, ENEMY, NEUTRAL};

public static class Alignment {
	public static string Alignment2String(AlignmentType alignment){
		switch(alignment){
		case AlignmentType.ENEMY:
			return "enemy";
		case AlignmentType.FRIENDLY:
			return "friendly";
		case AlignmentType.NEUTRAL:
			return "neutral";
		}
		return "neutral";
	}
	
	public static AlignmentType String2Alignment(string alignment){
		switch(alignment){
		case "enemy":
			return AlignmentType.ENEMY;
		case "friendly":
			return AlignmentType.FRIENDLY;
		case "neutral":
			return AlignmentType.NEUTRAL;
		}
		throw new UnityException("No Alignment of type " + alignment);
	}
	
	
}
