using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed = 20f;
	public int damage = 40;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start () {
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D (Collider2D hitInfo)
	{
		
		Enemy enemy = hitInfo.GetComponent<Enemy>();
		Gate gate = hitInfo.GetComponent<Gate>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
			SoundManager.PlaySound("enemyHit");
		}
		if (gate != null){
			gate.open();
		}

		GameObject impact = Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);
		Destroy(impact,1);
	}
	
}