using UnityEngine;

public class GestureWalker : MonoBehaviour
{
    public Animator animator;

    public OVRHand leftHand;
    public OVRHand rightHand;
    public Transform leftPointerPose; // Assigned in Inspector
    public float speed = 1.5f;

    void Update()
    {
        if (rightHand != null && rightHand.IsTracked)
        {
            bool isPinching = rightHand.GetFingerIsPinching(OVRHand.HandFinger.Index);

            if (isPinching)
            {

                // Animate
                animator.SetFloat("Walk", 1f);

                // ✅ Walk in left hand's pointing direction
                if (leftPointerPose != null)
                {
                    Vector3 direction = leftPointerPose.forward;
                    direction.y = 0f; // Keep movement horizontal
                    transform.forward = direction; // Rotate agent
                    transform.position += direction.normalized * speed * Time.deltaTime; // Move agent
                }
            }
            else
            {
                animator.SetFloat("Walk", 0f);
            }
        }
        else
        {
            animator.SetFloat("Walk", 0f);
        }
    }
}
