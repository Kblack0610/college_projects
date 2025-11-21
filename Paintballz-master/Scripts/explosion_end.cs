using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_end : MonoBehaviour {

	public float timer = 1;
	void Start () {
		
	}
	
	void Update () {

		if (timer > 0)
		{
			timer -= Time.deltaTime;
		}
		else 
		{
			Destroy(gameObject);
		}	
	}
}
