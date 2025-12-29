using UnityEngine;

public class YawOnlyFollowMotion : MonoBehaviour
{
    private Vector3 lastPos;

    private void Start()
    {
        lastPos = transform.position;
    }

    private void LateUpdate()
    {
        // Compute how far we moved this frame in world space.
        Vector3 delta = transform.position - lastPos;
        lastPos = transform.position;

        // If we did not move enough, don’t change rotation.
        if (delta.sqrMagnitude < 0.000001f)
            return;

        // Remove any vertical component so we never pitch.
        Vector3 flatForward = Vector3.ProjectOnPlane(delta, Vector3.up);

        if (flatForward.sqrMagnitude < 0.000001f)
            return;

        flatForward.Normalize();

        // Face in the direction of travel, staying upright, no pitch, no roll, just yaw
        transform.rotation = Quaternion.LookRotation(flatForward, Vector3.up);
    }
}