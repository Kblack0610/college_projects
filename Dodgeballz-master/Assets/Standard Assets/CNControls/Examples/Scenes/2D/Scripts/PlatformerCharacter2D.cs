using System;
using UnityEngine;

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
			// Ensure that a BoxCollider2D and Rigidbody2D exist on the
			// GameObject this script is attached to.
			//Assert.IsNotNull (GetComponent<BoxCollider2D> ());
			//Assert.IsNotNull (GetComponent<Rigidbody2D> ());

			//rb = GetComponent<Rigidbody2D> ();

			// Set up the Rigidbody2D in case it isn't already
			// set up properly in the Unity editor.
			// The Rigidbody2D should be Dynamic, have a
			// Gravity Scale of 0 and have its Freeze Rotation
			// Constraint set to true.
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

			Debug.Log (nextX +  "," + nextY);
        }

		public void Shoot(float h2, float v2)
		{
			if (h2 != 0 && v2 != 0 && Time.time > nextFire) {
				nextFire = Time.time + fireRate;
				// Instantiate the projectile at the position and rotation of this transform
				GameObject clone;

				xDir = xDir + h2;
				yDir = yDir + v2;
				Debug.Log (rb.transform.position + "  ,  " + rb.transform.rotation);
				clone = Instantiate(projectile, rb.transform.position, Quaternion.Euler(0.0f ,0.0f , 180.0f) * rb.transform.rotation);
				Rigidbody2D proj = clone.GetComponent<Rigidbody2D>();

				// Give the cloned object an initial velocity along the current 
				// object's Z axis
				Vector2 force = new Vector2 (xDir * bulletSpeed, yDir * bulletSpeed);

				proj.velocity = force * 10;
				//proj.AddForce(force * 1000);
//				nextFire = Time.time + fireRate;
//				Rigidbody2D newBullet = (Rigidbody2D)Instantiate (bullet, rb.transform.GetChild (0).position, transform.rotation);


//				Vector2 force = new Vector2 (xDir * bulletSpeed, yDir * bulletSpeed);
//				newBullet.AddForce (force);
			}
		}
		}
}

