using UnityEngine;

/// <summary>
/// Extension methods for unity GameObjects
/// How to use: Simply add the file to your Unity project
/// </summary>
public static class ExtensionMethods
{
    #region Vector3 Distance, Direction extensions
    /// <summary>
    /// Returns the distance between two Gameobjects
    /// </summary>
    /// <param name="c">Extension parameter</param>
    /// <param name="other">The second gameobject</param>
    /// <returns></returns>
    public static float Distance(this GameObject e, GameObject other)
    {
        return e.transform.position.Distance(other.transform.position);
    }

    /// <summary>
    /// Returns the distance between two points in space
    /// </summary>
    /// <param name="c">Extension parameter</param>
    /// <param name="other">The second point in space</param>
    /// <returns></returns>
    public static float Distance(this Vector3 e, Vector3 other)
    {
        return Vector3.Distance(e, other);
    }

    /// <summary>
    /// Returns a direction vector between two Gameobjects
    /// </summary>
    /// <param name="e">The gameobject thats at the start position of the vector</param>
    /// <param name="other">The gameobject at the end of the direction vector</param>
    /// <returns></returns>
    public static Vector3 Direction(this GameObject e, GameObject other)
    {
        return e.transform.position.Direction(other.transform.position);
    }

    /// <summary>
    /// Returns a direction vector between two points in space
    /// </summary>
    /// <param name="e">The start position of the vector</param>
    /// <param name="other">The end position of the direction vector</param>
    /// <returns></returns>
    public static Vector3 Direction(this Vector3 e, Vector3 other)
    {
        return other - e;
    }
    #endregion
}
