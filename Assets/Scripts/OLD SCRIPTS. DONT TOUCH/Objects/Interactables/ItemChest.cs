using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Animator))]
public class ItemChest : Interactable {

	Animator animator;
	public Item itemToSpawn;
	bool spawningItem;
	
	protected override void OnAwake ()
	{
		base.OnAwake ();
		animator = GetComponent<Animator>();
	}
	
	
	protected override void onInteract (PlayerBehavior interactee)
	{
		base.onInteract (interactee);
		if(!spawningItem){
			releaseItem();
		}
		this.doneInteracting(interactee);
		
	}
	
	void releaseItem(){
		spawningItem = true;
		animator.Play ("Opening");
	}
	
	void Update(){
		if(animator.GetCurrentAnimatorStateInfo(0).IsName("Open")){
			spawnItem();
		}
	}
	
	void spawnItem(){
		if(itemToSpawn != null){
			Instantiate(itemToSpawn, transform.position, transform.rotation);
			itemToSpawn = null;
			//TODO: Turn off animator, switch sprite to final image.
		}
	}
	
}
