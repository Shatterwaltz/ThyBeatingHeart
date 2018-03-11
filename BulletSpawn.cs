using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour {
    public float seconds;
    /// <summary>
    /// A reference to a tracked object, in this case a controller.
    /// </summary>
    private SteamVR_TrackedObject trackedObject;
    /// <summary>
    /// Provides easy access to the controller.
    /// Returns the controller's input through the tracked object's index.
    /// </summary>
    private SteamVR_Controller.Device Controller {
        get { return SteamVR_Controller.Input( ( int ) trackedObject.index ); }
    }

    void Awake () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    public BulletMovement bullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if( Controller.GetHairTriggerDown() ) {
            BulletMovement a = Instantiate(bullet, trackedObject.transform.position, trackedObject.transform.rotation);
            //a.transform.parent = transform.parent;
            a.Initialize(seconds, new LinearEquation(0), new LinearEquation(0), new LinearEquation(10));
        }

    }
}
