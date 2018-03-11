using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour {
    
    private SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device Controller {
        get { return SteamVR_Controller.Input( ( int ) trackedObject.index ); }
    }

    /// <summary>
    /// Reference to the laser prefab.
    /// </summary>
    public  GameObject  laserPrefab;
    /// <summary>
    /// Stores a reference to the instance of the laser.
    /// </summary>
    private GameObject  laser;
    /// <summary>
    /// Stored for ease of use.
    /// </summary>
    private Transform   laserTransform;
    /// <summary>
    /// Position where the laser hits.
    /// </summary>
    private Vector3     hitPoint;

    void Start () {
        // Spawn a new laser and save a reference to it in laser.
        laser = Instantiate( laserPrefab );
        // Store the laser's transform component.
        laserTransform = laser.transform;
    }

    void Awake () {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    private void ShowLaser ( RaycastHit hit ) {
        // Show the laser
        laser.SetActive( true );
        // Position the laser between the controller and where the raycast hits.
        laserTransform.position = Vector3.Lerp( trackedObject.transform.position, hitPoint, .5f );
        // Point the laser at the position where the raycast hit.
        laserTransform.LookAt( hitPoint );
        // Scale the laser so it fits perfectly between the two positions.
        laserTransform.localScale = new Vector3( laserTransform.localScale.x, laserTransform.localScale.y, hit.distance );
    }

    // Update is called once per frame
    void Update () {
        // If the touchpad is held down...

        if ( Controller.GetPress( SteamVR_Controller.ButtonMask.Touchpad ) ) {
            RaycastHit hit;
            // Shoot a ray from the controller. If it hits something, make it store the
            // point where it hit and show the laser.
            if ( Physics.Raycast( trackedObject.transform.position, transform.forward, out hit, 100 ) ) {
                hitPoint = hit.point;
                Debug.Log( "casted" );
                ShowLaser( hit );
            }
        } else {
            // Hide the laser when the player releases the touchpad.
        }
	}
}
