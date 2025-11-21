using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : MonoBehaviour {

	private Rigidbody2D rb;
	public GameObject Grenade;
	private bool launching = false;
	public float nadeForce = 50f;


	void Start () {
		rb = GetComponent<Rigidbody2D>();
		
	}
	
	public void Launch (float h2, float v2) {
		
		Vector2 aimVec = new Vector2 (h2,v2);
	
				
		if (h2 != 0 && v2 != 0 )
		{
			if (launching)
			{
				Debug.Log("LAUNCH");
				GameObject nade;

				nade = Instantiate(Grenade, rb.transform.position, rb.transform.rotation);

				Physics2D.IgnoreCollision(nade.GetComponent<Collider2D>(),  GetComponent<Collider2D>());

				nade.GetComponent<Rigidbody2D>().AddForce(aimVec*nadeForce, ForceMode2D.Force);

				launching = false;
			}
		
		}
	}

	public void LaunchOnClick () {
		launching = true;
		Debug.Log("BITCH");
	
	}
}
