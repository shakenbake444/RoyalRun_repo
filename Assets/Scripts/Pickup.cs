using UnityEngine;

public class Pickup : MonoBehaviour
{
    const string playerString = "Player";

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(other.gameObject.name);
        }
    }

    void Update()
    {
        RotateContinuously();
    }
    
    private void RotateContinuously()
    {
        transform.Rotate(new Vector3(0, 1, 0), Space.Self);
    }
}
