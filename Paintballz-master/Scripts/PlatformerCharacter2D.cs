using System;
using UnityEngine;
using UnityEngine.UI;

// Just in case so no "duplicate definition" stuff shows up
namespace UnityStandardAssets.Copy._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
   {

        private Animator m_Anim;            // Reference to the player's animator component.
		private Rigidbody2D rb;

		//Game Objects
		public GameObject projectile;
		

		public float bulletSpeed = .01f;
		private float turretRotationSpeed = 5f;

		//walking axis
		private float nextY;
		private float nextX;

		//shooting axis
		private float xDir;
		private float yDir;

		//time interval of fire
		private double nextFire = 0.0;
		private double fireRate = 0.1;

		//Dodge
		private float dodgeTimer = 0;

		
		
		
        private void Awake()
        {
            // Setting up references.
			rb = GetComponent<Rigidbody2D> ();
            //m_Anim = GetComponent<Animator>();
			nextX = rb.transform.position.x;
			nextY = rb.transform.position.y;

			xDir = rb.transform.position.x;
			yDir = rb.transform.position.y;

			
			

        }

		void Start () {

			rb.bodyType = RigidbodyType2D.Dynamic;
			//rb.gravityScale = 0;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;

		}

		public void Move(float h, float v)
        {
			//change movement by axis
			nextX = nextX + (float)(h*.1);
			nextY = nextY + (float)(v*.1);

			//move rigidbody
			rb.MovePosition(new Vector2(nextX, nextY));

			//Debug.Log (nextX +  "," + nextY);
        }

		public void Shoot(float h2, float v2)
		{
			if (h2 != 0 && v2 != 0 && Time.time > nextFire) {
				nextFire = Time.time + fireRate;

				Vector2 moveVec = new Vector2 (h2, v2);
				Vector3 rotVec = Vector3.forward;
				transform.rotation = Quaternion.LookRotation (rotVec, moveVec);

				// Instantiate the projectile at the position and rotation of this transform
				GameObject clone;

				clone = Instantiate(projectile, rb.transform.position, rb.transform.rotation);

				Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(),  GetComponent<Collider2D>());

				clone.GetComponent<Rigidbody2D>().AddForce(moveVec*1000);

				//nextFire = Time.time + fireRate;
			}
		}

		public void DodgeCall()
		{
			dodgeTimer = 0.1f;
			
		}
		public void Dodge(float h, float v)
		{
			if (dodgeTimer > 0)
			{
				dodgeTimer -= Time.deltaTime;
				
			}	
			
			
			
		}
	}
}

