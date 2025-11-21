using UnityEngine;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using CnControls;
using System.Collections;

public class UnityNetworkPlayer : NetworkBehaviour {

	public const int maxHealth = 100;
	public bool destroyOnDeath;

	//Game Objects
	public GameObject projectile;

	//time interval of fire
	private double nextFire = 0.0;
	private double fireRate = 1;

	[SyncVar(hook = "OnChangeHealth")]
	public int currentHealth = maxHealth;

	public RectTransform healthBar;

	//walking axis
	private float nextY;
	private float nextX;

	private Rigidbody2D rb;

	private NetworkStartPosition[] spawnPoints;

	void Start ()
	{
		if (isLocalPlayer)
		{
			spawnPoints = FindObjectsOfType<NetworkStartPosition>();


			// Setting up references.
			rb = GetComponent<Rigidbody2D> ();
			//m_Anim = GetComponent<Animator>();
			nextX = rb.transform.position.x;
			nextY = rb.transform.position.y;
		}
	}

	void Update()
	{
		if (!isLocalPlayer)
		{
			return;
		}

		//Get Moving Joystick Axis
		float h = CnInputManager.GetAxis("Horizontal");
		float v = CnInputManager.GetAxis("Vertical");

		//			//Get Shooting Joystick Axis
		float h2 = CnInputManager.GetAxis("Horizontal2");
		float v2 = CnInputManager.GetAxis("Vertical2");

		Move (h, v);
		Shoot (h2, v2);

	}

	public void Move(float h, float v)
	{
		//change movement by axis
		nextX = nextX + (float)(h*.1);
		nextY = nextY + (float)(v*.1);

		//move rigidbody
		rb.MovePosition(new Vector2(nextX, nextY));

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

			clone = Instantiate(projectile, rb.transform.position, rb.transform.rotation);

			Physics2D.IgnoreCollision(clone.GetComponent<Collider2D>(),  GetComponent<Collider2D>());

			clone.GetComponent<Rigidbody2D>().AddForce(moveVec*1000);

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
		if (!isServer)
			return;

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
				RpcRespawn();
			}
		}
	}

	void OnChangeHealth (int currentHealth )
	{
		healthBar.sizeDelta = new Vector2(currentHealth , healthBar.sizeDelta.y);
	}

	[ClientRpc]
	void RpcRespawn()
	{
		if (isLocalPlayer)
		{
			// Set the spawn point to origin as a default value
			Vector3 spawnPoint = Vector3.zero;

			// If there is a spawn point array and the array is not empty, pick one at random
			if (spawnPoints != null && spawnPoints.Length > 0)
			{
				spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
			}

			// Set the player’s position to the chosen spawn point
			transform.position = spawnPoints[1].transform.position;
		}
	}
}