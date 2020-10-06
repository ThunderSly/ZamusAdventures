using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public HealthBar healthBar;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    bool crouch = false;

    public int maxHealth = 100;

    public int currentHealth = 100;
    private int damage = 20;
    private bool invincible = false;
    public float invincibilityTime = 1f;
 
    void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("Jump", true);

        }
        if (Input.GetButtonDown("Crouch")){
            crouch = true;
        }
        if (Input.GetButtonUp("Crouch")){
            crouch = false;

        }

    }
    public void OnCrouching(bool Crouch){
        animator.SetBool("Crouch", Crouch);

    }

    public void OnLanding(){
        
        animator.SetBool("Jump", false);

    }

    void FixedUpdate() {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(!invincible) {
            if(collision.gameObject.tag == "Enemy") {
                currentHealth -= damage;
                SoundManager.PlaySound("playerHit");
                if(currentHealth <= 0){
                    Destroy(gameObject);
                    SoundManager.PlaySound("gameOver");
                    SceneManager.LoadScene(0);
                }
                animator.SetBool("Hurt", true);
                StartCoroutine(Invulnerability());
            }

            if(collision.gameObject.tag == "Boss") {
                currentHealth -= damage*2;
                SoundManager.PlaySound("playerHit");
                if(currentHealth <= 0){
                    Destroy(gameObject);
                    SoundManager.PlaySound("gameOver");
                    SceneManager.LoadScene(0);
                }
                animator.SetBool("Hurt", true);
                StartCoroutine(Invulnerability());
            } 
            healthBar.SetHealth(currentHealth);
        }

        if(collision.gameObject.tag == "Wall"){
			Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }

    }
    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.gameObject.tag == "PowerUp"){
            PowerUp powerup = collision.GetComponent<PowerUp>();
            if (powerup != null){
                powerup.Die();
                
                if (currentHealth + 30 >= 100) {
                    currentHealth = 100;
                } else {
                    currentHealth += 30;
                }
                SoundManager.PlaySound("powerUp");
                healthBar.SetHealth(currentHealth);
		    }
        }

        if(collision.gameObject.tag == "Gate"){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if(collision.gameObject.tag == "Death"){
            SoundManager.PlaySound("gameOver");
            SceneManager.LoadScene(0);
        }              
    }

 
    IEnumerator Invulnerability() {
        invincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
        animator.SetBool("Hurt", false);
    }
}
