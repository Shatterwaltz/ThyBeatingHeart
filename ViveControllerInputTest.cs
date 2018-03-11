using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerInputTest : MonoBehaviour {

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

    // Update is called once per frame
    void Update () {
        /*
         * Write to the Console when the menu button is pressed.
         */
        if ( Controller.GetPressDown( SteamVR_Controller.ButtonMask.ApplicationMenu ) ) {
            Debug.Log( gameObject.name + " Menu Pressed" );
        }

        /*
         * Write to the Console when the menu button is released.
         */
        if ( Controller.GetPressUp( SteamVR_Controller.ButtonMask.ApplicationMenu ) ) {
            Debug.Log( gameObject.name + " Menu Released" );
        }

        /*
         * Get the position of the finger when it's on the touchpad and write it to the Console
         */
        if ( Controller.GetAxis() != Vector2.zero ) {
            Debug.Log( gameObject.name + Controller.GetAxis() );
        }

        /*
         * Write to the Console when the touchpad is pressed.
         */
        if ( Controller.GetPressDown( SteamVR_Controller.ButtonMask.Touchpad ) ) {
            Debug.Log( gameObject.name + " Touchpad Press" );
        }

        /*
         * Write to the Console when the touchpad is released.
         */
        if ( Controller.GetPressUp( SteamVR_Controller.ButtonMask.Touchpad ) ) {
            Debug.Log( gameObject.name + " Touchpad Release" );
        }

        /*
         * Writes to the Console when the hair trigger is squeezed.
         */
        if ( Controller.GetHairTriggerDown() ) {
            Debug.Log( gameObject.name + " Trigger Press" );
        }

        /*
         * Writes to the Console when the hair trigger is released.
         */
        if ( Controller.GetHairTriggerUp() ) {
            Debug.Log( gameObject.name + " Trigger Release" );
        }

        /*
         * Writes to the Console when one of the grip buttons is pressed.
         */
        if ( Controller.GetPressDown( SteamVR_Controller.ButtonMask.Grip ) ) {
            Debug.Log( gameObject.name + " Grip Press" );
        }

        /*
         * Writes to the Console when one of the grip buttons is released.
         */
        if ( Controller.GetPressUp( SteamVR_Controller.ButtonMask.Grip ) ) {
            Debug.Log( gameObject.name + " Grip Release" );
        }
    }
}
