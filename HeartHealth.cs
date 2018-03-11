using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealth : MonoBehaviour {

    public int HP = 1;

    /*
    public SerializeField HP {
        get { return _HP; }
        set { _HP = value;  }
    }
    */

    /*
    [Range(0.1f,0.9f)]
    public float number;
    */

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        if (HP <= 0) {
            Die();
        }
		
	}

    void Die() {
        /*
         * This kills the player
         *
         * Since this object with be attached to the player object, it can simply get a reference to it and call it's Die() funciton, which can trigger game
         * Over or something like that, I dunno.
         */

        // for now just destroy the game object
        Debug.Log("Destroying the game object!");
        Destroy(gameObject.transform.parent.gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        // Do damage if collision object is a "bullet"
        if (other.gameObject.tag == "Bullet") {
            Debug.Log("Taking some damage, boss!");
            if (HP >= 1) {
                HP -= 1;
            }
        }
        Debug.Log(HP);
    }
}
