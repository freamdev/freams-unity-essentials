using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


/// <summary>
/// Fires a ray from the camera forward and stores the first hitted object
/// Priority can be set via the layerPriorities field from the inspector
/// </summary>
public class CameraRaycaster : MonoBehaviour
{
    public Layer[] layerPriorities = {
        Layer.Ui,
        Layer.Ground
    };

    float DistanceToBackground = 1000f;
    Camera ViewCamera;

    RaycastHit RayHit;

    public RaycastHit hit
    {
        get { return RayHit; }
    }

    Layer RayLayer;
    public Layer LayerHit
    {
        get { return RayLayer; }
    }

    void Awake()
    {
        ViewCamera = Camera.main;
    }

    void Update()
    {
        // Look for and return priority layer hit
        foreach (Layer layer in layerPriorities)
        {
            var hit = RaycastForLayer(layer);
            if (hit.HasValue)
            {
                // set layer and hit
                RayHit = hit.Value;
                RayLayer = layer;
                return; // exit method
            }
        }
        // Otherwise return background hit
        RayHit.distance = DistanceToBackground;
        RayLayer = Layer.RaycastEndStop;
    }

    RaycastHit? RaycastForLayer(Layer layer)
    {
        Ray ray;
        ray = ViewCamera.ScreenPointToRay(Input.mousePosition);
        int layerMask = 1 << (int)layer;
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit, DistanceToBackground, layerMask);
        if (hasHit)
        {
            return hit;
        }
        return null;
    }
}