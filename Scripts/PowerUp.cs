using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
	public void Die ()
	{
		Destroy(gameObject);
	}
}
