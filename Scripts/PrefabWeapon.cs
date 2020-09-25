using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabWeapon : MonoBehaviour {

	public Transform firePoint;

	public Transform firePoint_Crouch;
	public GameObject bulletPrefab;
	public Animator animator;

	bool crouch = false;
	float fireSpeed = 0.3f;

	float canFire = 1f;
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Crouch")){
            crouch = true;
        }
        if (Input.GetButtonUp("Crouch")){
            crouch = false;

        }

		if (Input.GetButton("Fire1")){
			if(Time.time > canFire){
				animator.SetBool("Shoot", true);
				Shoot();
				canFire = Time.time + fireSpeed;
				SoundManager.PlaySound("fireLaser");
			}
		}
		else{
			animator.SetBool("Shoot", false);
		}




	}

	void Shoot ()
	{	
		if (crouch){
			Instantiate(bulletPrefab, firePoint_Crouch.position, firePoint_Crouch.rotation);
		}
		else{
			Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		}


	}
}