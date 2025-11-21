using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Controller : MonoBehaviour {

    private float timer = 3;
    private Rigidbody2D rb;
    public GameObject explo;
   
		void Start () {
		rb = GetComponent<Rigidbody2D>();
        
        }
	
	
	void Update () {

        Vector3 pos = gameObject.transform.position;
		
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else 
        {
            Instantiate(explo, pos, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
