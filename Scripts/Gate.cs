using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public float openTime = 5f;
    [SerializeField] private Collider2D OpenDisableCollider;
    public void open(){
        animator.SetBool("shot", true);
        SoundManager.PlaySound("gateOpen");
        OpenDisableCollider.enabled = false;
        StartCoroutine(OpenTimer());
    }
    public void close(){
        animator.SetBool("shot", false);
        OpenDisableCollider.enabled = true;
    }


    IEnumerator OpenTimer() {
        yield return new WaitForSeconds(openTime);
        close();
    }
}
