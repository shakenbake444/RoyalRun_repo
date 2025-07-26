using UnityEngine;

public class RotateContinuously : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0), Space.Self);
    }
}
