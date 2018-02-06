using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    CameraRaycaster cameraRaycaster;

	// Use awake if input processing must happen before anything.
	void Start () {
		cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
    }
	
	void Update () {
        //We process the input at every update call
        ProcessInput();
	}

    private void ProcessInput()
    {
        switch (cameraRaycaster.LayerHit)
        {
            //Example logic for hitting a specific layer with the mouse
            case Layer.Ground: GroundMouseOver(cameraRaycaster.hit); break;
            case Layer.RaycastEndStop: print("Mouse is outside of recognized game area"); break;
            default: break;
        }
    }

    //Example handler for a mouse over event
    private void GroundMouseOver(RaycastHit hit)
    {
        print("Mousing over ground");
    }
}
