using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee_Attack : MonoBehaviour {

	private Animator anim;
	public GameObject weapon;
	public GameObject hitBox;

	private Collider2D atkBox;
	private bool attacking;
	private float atkTimer = 0;
	public float atkCD = 0.3f;

	void Awake () {
		anim = weapon.GetComponent<Animator>();
		atkBox = hitBox.GetComponent<BoxCollider2D>();
		atkBox.enabled = false;

		attacking = false;
	}
	void Update () {
	
		if (attacking)
			if (atkTimer > 0)
			{
				atkTimer -= Time.deltaTime;
			}
			else
			{
				attacking= false;
				atkBox.enabled = false;

			}
	}

    public void MeleeHit() 
    {
        Debug.Log("Melee");
        if (!attacking)
        {
            anim.SetTrigger("Melee");
            attacking = true;
			atkTimer = atkCD;
			atkBox.enabled = true;
        }
    }
}
