using UnityEngine;
using System.Collections;

public class ArmorGrub : MonoBehaviour {

	protected float ai_attack_range = 8f;
	protected float ai_retreat_range = 5f;
	protected float ai_max_movement = 20f;
	public GameObject player;
	protected float playerDist;
	protected bool playerOnRight;
	Rigidbody rb;
	public float speed;
	protected Vector3 startPoint;
	protected float distFromStart;
	public Projectile projectile1;
	public FireMethod fireMethod;
	public float spread;
	public int health;
	Animator ani;
	// Use this for initialization
	void Start () {
		GetPlayer();
		rb = GetComponent<Rigidbody>();
		ani = GetComponent<Animator>();
		startPoint = this.transform.position;
	}
	
	void OnAwake()
	{
		//grubState = AI_Enums.AI_State.PATROL;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		playerDist = Vector2.Distance((Vector2)transform.position,(Vector2)player.transform.position);
		distFromStart = Vector2.Distance((Vector2)transform.position,(Vector2)startPoint);
		//ChangeState();
		//HandleState();
		PlayerSide();
		
	}
	
	
	
	void GetPlayer()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void PlayerSide()
	{

		Vector3 flipScale = transform.localScale;
		if( player.transform.position.x > transform.position.x)
		{
			playerOnRight = true;
			flipScale.x = 1f;
		}
		else
		{
			playerOnRight = false;
			flipScale.x= -1f;
		}
		this.transform.localScale = flipScale;
	}
	
	void ChangeState()
	{
		if(playerDist < ai_attack_range && playerDist > ai_retreat_range)
		{
			//grubState = AI_Enums.AI_State.ATTACK;
		}
		
		else if(playerDist > ai_attack_range && distFromStart < ai_max_movement)
		{
			//grubState = AI_Enums.AI_State.HUNT;
		}
		
		else if(playerDist < ai_retreat_range)
		{
			//grubState = AI_Enums.AI_State.RETREAT;
		}
		else
		{
			//grubState = AI_Enums.AI_State.PATROL;
		}
	}
	
	void HandleState()
	{
//		switch(grubState)
//		{
//		case AI_Enums.AI_State.RETREAT:
//			
//			
//			print ("Execute Retreat");
//			if(Mathf.Abs(rb.velocity.x) < 5.0f)
//			{
//				rb.AddForce( (this.transform.position - player.transform.position).normalized * speed, ForceMode.Impulse);
//			}
//			
//			
//			break;
//		case AI_Enums.AI_State.ATTACK:
//			
//			//GetComponent<ShootAtTarget>().shootTarget(projectile1,player.transform.position);
//			
//			
//			break;
//		case AI_Enums.AI_State.HUNT:
//			
//			print ("Execute Hunt");
//			if(Mathf.Abs (rb.velocity.x) < 5.0f)
//			{
//				rb.AddForce( (player.transform.position - this.transform.position).normalized * speed, ForceMode.Impulse);
//			}
//			break;
//		default:
//			break;
//		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "projectile")
		{
			ani.Play("ArmorGrub_Damaged");
			health--;

			if(health <= 0)
			{
				Destroy(this.gameObject);
			}
		}
	}
	
}
