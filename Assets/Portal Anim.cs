using UnityEngine;

public class PortalAnim : MonoBehaviour
{
    public Animator animator;
    public float triggerDistance = 5f;
    public Transform playerObject;  // Reference to the player object

    private bool playerInRange = false;
    private float animationStartTime;

    void Start()
    {
        // Assign the Animator component if not already set
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Ensure playerObject is assigned in the inspector
        if (playerObject == null)
        {
            Debug.LogError("Player object not assigned in the inspector!");
            return;
        }
    }

    void Update()
    {
        // Check if player is within trigger distance
        float distance = Vector3.Distance(transform.position, playerObject.position);
        playerInRange = distance <= triggerDistance;

        if (playerInRange)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("your_animation_name")) // Use IsName() for compatibility
            {
                // Start animation and record start time
                animator.Play("your_animation_name", 0, 0.5f);
                animationStartTime = Time.time;
            }
        }
        else
        {
            // Player left the area, check if animation was playing
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("your_animation_name")) // Use IsName() for compatibility
            {
                // Calculate elapsed time
                float elapsedTime = Time.time - animationStartTime;

                // Access the first clip in the array and its length
                float remainingTime = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length - elapsedTime;
                animator.speed = 0f; // Pause animation
                animationStartTime = Time.time - remainingTime * 0.5f; // Set start time to half point
            }
            else
            {
                // Reset animation start time if it's not playing
                animationStartTime = 0f;
            }
        }
    }
}
