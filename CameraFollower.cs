using UnityEngine;

/// <summary>
/// Follows the target GameObject, and rotates the camera if the right mouse button is held down.
/// How to use: Add the MonoBehaviour to the GameObject with the Camera.
/// </summary>
public class CameraFollower : MonoBehaviour
{
    [Tooltip("Gameobject to center the view on")]
    public GameObject Target;

    [Tooltip("Distance from the pivot point of the Target")]
    public float Distance;

    [Tooltip("Horizontal speed of the rotation")]
    public float HSpeed;
    [Tooltip("Vertical speed of the rotation")]
    public float VSpeed;

    [Tooltip("Minimum vertical rotation")]
    public float VMinRotation;
    [Tooltip("Maximum vertical rotation")]
    public float VMaxRotation;

    [Tooltip("Minimum horizontal rotation")]
    public float HMinRotation;
    [Tooltip("Maximum horizontal rotation")]
    public float HMaxRotation;

    //The current degrees of rotation
    Vector2 currentXY;
    //The current distance from the 
    float currentDistance;

    void Start()
    {
        CheckTarget();
        //We initialize the camera position
        PositionCamera();
    }

    void LateUpdate()
    {
        PositionCamera();
    }

    private void PositionCamera()
    {
        CheckTarget();
        currentDistance = Distance;

        //Apply rotation only if the mouse button is held down
        if (Input.GetMouseButton(1))
        {
            currentXY.x += Input.GetAxis("Mouse X") * HSpeed * currentDistance;
            currentXY.y -= Input.GetAxis("Mouse Y") * VSpeed;
        }

        currentXY.y = ClampAngle(currentXY.y, VMinRotation, VMaxRotation);
        currentXY.x = ClampAngle(currentXY.x, HMinRotation, HMaxRotation);

        Quaternion rotation = Quaternion.Euler(currentXY.y, currentXY.x, 0);
        RaycastHit hit;
        if (Physics.Linecast(Target.transform.position, transform.position, out hit))
        {
            currentDistance -= hit.distance;
        }
        Vector3 negDistance = new Vector3(0.0f, 0.0f, -currentDistance);
        Vector3 position = rotation * negDistance + Target.transform.position;

        transform.position = position;
        transform.rotation = rotation;
    }

    #region Helpers

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }

    private void CheckTarget()
    {
        if (Target == null)
        {
            Debug.LogError("No Target was set in the inspector (Target gone missing?)");
            throw new System.Exception("Target was not found for CameraFollower component");
        }
    }

    #endregion
}
