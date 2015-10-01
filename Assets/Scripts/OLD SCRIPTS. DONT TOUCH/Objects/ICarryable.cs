using UnityEngine;
using System.Collections;

public interface ICarryable{

	void pickUp(Combatant combatant);
	void drop(Collider carrier);
}
