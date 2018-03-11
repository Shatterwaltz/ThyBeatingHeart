using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour {
    public BulletMovement bullet;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("space")) {
            BulletMovement a = Instantiate(bullet, transform.position, transform.rotation);
            a.Initialize(3, new SineEquation(20,3), new LinearEquation(0), new LinearEquation(10));
        }

    }
}
