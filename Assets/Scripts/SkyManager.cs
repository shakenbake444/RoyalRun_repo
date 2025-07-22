using UnityEngine;

public class SkyManager : MonoBehaviour
{
    public float skySpeed;
    public float skyRotation;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        skyRotation += Time.deltaTime * skySpeed;
        RenderSettings.skybox.SetFloat("_Rotation", skyRotation);
    }
}
