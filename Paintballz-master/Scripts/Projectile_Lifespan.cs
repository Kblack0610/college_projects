using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Lifespan : MonoBehaviour {

	public float lifeSpan = 5;
	private float timer = 0;
	private Collider2D thisCol;

	public GameObject explosion;
		

	void Start () {
		timer = lifeSpan;
		thisCol = gameObject.GetComponent<Collider2D>();
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

	void OnCollisionEnter2D (Collision2D collision) {

		ContactPoint2D contact = collision.contacts[0];
		Vector3 pos = contact.point;

		if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player")
		{
			Instantiate(explosion, pos, Quaternion.identity);
			Destroy(this.gameObject);
		}
	}

	
}
