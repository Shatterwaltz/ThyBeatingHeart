using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    // Use this for initialization
    public AudioClip grunt;
    private AudioSource source;
    public float invulnTime = 0;
    float timeSinceHit = 0;
    bool wasHit = false;
    void Awake () {
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if ( wasHit ) {
            timeSinceHit += Time.deltaTime;
        }
	}
    private void OnTriggerEnter ( Collider other ) {
        if ( other.tag == "Bullet" ) {
            wasHit = true;
            if ( timeSinceHit > invulnTime ) {
                source.PlayOneShot( grunt );

                Debug.Log( "HIT" );
                wasHit = false;
                timeSinceHit = 0;
            }
        }
    }
}
