using UnityEngine;

public class Reset : MonoBehaviour
{
    public Transform objectToReset;

    public void ResetPositionAndRotation()
    {
        objectToReset.position = Vector3.zero;
        
        objectToReset.eulerAngles = Vector3.zero;
    }
}
