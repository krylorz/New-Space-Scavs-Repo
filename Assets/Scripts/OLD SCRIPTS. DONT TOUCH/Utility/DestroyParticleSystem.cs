using UnityEngine;
using System.Collections;

[RequireComponent (typeof (ParticleSystem))]
public class DestroyParticleSystem : MonoBehaviour {

		ParticleSystem ps;
		
		void Awake(){
			ps = GetComponent<ParticleSystem>();
		}
		
		
		public void Update() 
		{
			if(ps)
			{
				if(!ps.IsAlive())
				{
					Destroy(gameObject);
				}
			}
		}
	}