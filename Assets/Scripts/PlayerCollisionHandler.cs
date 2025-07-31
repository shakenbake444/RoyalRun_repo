using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    const string hitString = "Hit";
    private float hitCoolDownTime = 1.0f;
    private bool HitTimerDone = false;
    void OnCollisionEnter(Collision collision)
    {
        if (HitTimerDone)
        {
            animator.SetTrigger(hitString);
            HitTimerDone = false;
            hitCoolDownTime = 1.0f;
        }
        Debug.Log("some t");
        
    }

    void Update()
    {
        hitCoolDownTime -= Time.deltaTime;

        if (hitCoolDownTime <= 0.01f)
        {
            HitTimerDone = true;
            hitCoolDownTime = 1.0f;
        }
    }
}
