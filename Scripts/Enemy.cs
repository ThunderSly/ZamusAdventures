  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	public int health = 100;

	public GameObject deathEffect;
	private Rigidbody2D m_Rigidbody2D;
	void Start(){
		if (tag == "Boss"){
			m_Rigidbody2D = GetComponent<Rigidbody2D>();
			m_Rigidbody2D.AddForce(new Vector2(250, 0));
		}

	}

	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0)
		{
			Die();
            SoundManager.PlaySound("enemyDeath");
			if(tag == "Boss"){
				SceneManager.LoadScene(0);
			}
		}
	}

	void Die ()
	{
		GameObject death = Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
        Destroy(death,1);
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if (tag == "Boss"){
			if (collision.gameObject.tag == "TileMap")
			{
				Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			}
			// else if (collision.gameObject.tag == "Player")
			// {
			// 	Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
			// }


			
		}

	}

}