using UnityEngine;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using CnControls;
using System.Collections;

public class PhotonNetworkPlayer : MonoBehaviour {

	public const int maxHealth = 100;
	public bool destroyOnDeath;

	//Game Objects
	public GameObject projectile;

	//time interval of fire
	private double nextFire = 0.0;
	private double fireRate = 1;

	public int currentHealth = maxHealth;

	public RectTransform healthBar;

	//walking axis
	private float nextY;
	private float nextX;

	private Rigidbody2D rb;

    PhotonView m_PhotonView;

	void Start ()
	{
		// Setting up references.
		rb = GetComponent<Rigidbody2D> ();

		m_PhotonView = GetComponent<PhotonView>();

		//m_Anim = GetComponent<Animator>();
		nextX = rb.transform.position.x;
		nextY = rb.transform.position.y;
		
	}

	void Update()
	{

		//Get Moving Joystick Axis
		float h = CnInputManager.GetAxis("Horizontal");
		float v = CnInputManager.GetAxis("Vertical");

		//			//Get Shooting Joystick Axis
		float h2 = CnInputManager.GetAxis("Horizontal2");
		float v2 = CnInputManager.GetAxis("Vertical2");

		Move (h, v);
		Shoot (h2, v2);

	}

	void FixedUpdate()
	{
		if( m_PhotonView.isMine == false )
        {
            return;
        }
	}

	public void Move(float h, float v)
	{
		//change movement by axis
		nextX = nextX + (float)(h*.1);
		nextY = nextY + (float)(v*.1);

		//move rigidbody
		rb.MovePosition(new Vector2(nextX, nextY));

    	m_PhotonView.RPC("DoMove", PhotonTargets.Others);

	}

	public void Shoot(float h2, float v2)
	{
		Vector2 moveVec = new Vector2 (h2, v2);
		Vector3 rotVec = Vector3.forward;
		transform.rotation = Quaternion.LookRotation (rotVec, moveVec);

		if (h2 != 0 && v2 != 0 && Time.time > nextFire) {
			nextFire = Time.time + fireRate;

			// Instantiate the projectile at the position and rotation of this transform
			GameObject clone;

			//clone = Instantiate(projectile, rb.transform.position, rb.transform.rotation);
        	clone = PhotonNetwork.InstantiateSceneObject( projectile.name, rb.transform.position, rb.transform.rotation, 0, null );

			Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(),  GetComponent<Collider2D>());

			clone.GetComponent<Rigidbody2D>().AddForce(moveVec*1000);

            m_PhotonView.RPC("DoShoot", PhotonTargets.Others);

			//nextFire = Time.time + fireRate;
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player") {
			Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(),  GetComponent<Collider2D>());
		}
		if (collision.gameObject.tag == "Bullet") {
			Destroy (gameObject);
			Debug.Log (gameObject.tag);
		}
	}

	public void TakeDamage(int amount)
	{

		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			if (destroyOnDeath)
			{
				Destroy(gameObject);
			} 
			else
			{
				currentHealth = maxHealth;

				// called on the Server, invoked on the Clients
			}
		}
	}

	void OnChangeHealth (int currentHealth )
	{
		healthBar.sizeDelta = new Vector2(currentHealth , healthBar.sizeDelta.y);
	}
}