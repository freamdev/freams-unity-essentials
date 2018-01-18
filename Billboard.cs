using UnityEngine;

/// <summary>
/// Rotates the object towards the camera.
/// How to use: Add the MonoBehaviour to the UI element that needs to face the camera.
/// </summary>
public class Billboard : MonoBehaviour
{
    [Tooltip("The UI element will face this Camera. Defaults to the Main Camera if left empty")]
    public Camera MyCamera;

    void Start()
    {
        if(MyCamera == null)
        {
            Debug.Log("No Camera was selected for " + gameObject.name + " setting Main Camera");
            MyCamera = Camera.main;
        }
    }

    void Update()
    {
        var transform = GetComponent<Transform>();
        transform.LookAt(transform.position + MyCamera.transform.rotation * Vector3.forward,
                        MyCamera.transform.rotation * Vector3.up);
    }
}