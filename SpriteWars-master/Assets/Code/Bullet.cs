using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = transform.up * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(col.gameObject);

            MenuManager mm = GameObject.Find("MenuManager").GetComponent<MenuManager>();
            mm.switchToMenu(2);
        }
    }
}
