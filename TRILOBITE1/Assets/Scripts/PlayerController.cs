using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; //side-to-side speed (lane movement)
    public float verticalInput;
    public float horizontalInput;
    public float xRange = 9.0f; //how far left/right from the rail centre
    public float zRange = 100; //not used for rail movement, kept for reference
    private float laneOffset = 0f; //current left/right offset from the rail
    private Vector3 startLocalPos; // starting local position for LaneOffset
    public float laneSnapSpeed = 25.0f; //how quickly it snaps to the target lane offset
    //private Rigidbody trilobiteRb; now using Spline Animate on TrilobiteRoot, so all Rigidbody code removed
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //Forward movement now using Spline Animate on TrilobiteRoot, so all Rigidbody code removed
        startLocalPos = transform.localPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");
        horizontalInput = Input.GetAxisRaw("Horizontal");

        //Move Trilobite is automatic and controlled by the Spline Animate component on TrilobiteRoot
        
        //Move Trilobite side to side
        //This snaps the lane offset instantly based on input.
        laneOffset = horizontalInput * xRange;

        
        //Keep Trilobite in bounds

        //Clamp the lane offset so the player cannot move too far away from the rail centre.
        laneOffset = Mathf.Clamp(laneOffset, -xRange, xRange);

        //Apply the lane offset after Spline Animate has positioned the object this frame.
        transform.localPosition = startLocalPos + new Vector3(laneOffset, 0f, 0f);

    }

}