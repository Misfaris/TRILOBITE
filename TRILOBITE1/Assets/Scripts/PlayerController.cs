using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; //side-to-side speed (lane movement)
    public float verticalInput;
    public float horizontalInput;
    public float xRange = 3.0f; //how far left/right from the rail centre
    public float zRange = 100; //not used for rail movement, kept for reference
    private float laneOffset = 0f; //current left/right offset from the rail
    //private Rigidbody trilobiteRb; now using Spline Animate on TrilobiteRoot, so all Rigidbody code removed
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //Forward movement now using Spline Animate on TrilobiteRoot, so all Rigidbody code removed
        //trilobiteRb = GetComponent<Rigidbody>();
        //trilobiteRb.freezeRotation = true;
    }

    // Update is called once per frame
    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        //Move Trilobite forward
        //trilobiteRb.AddForce(Vector3.back * speed * verticalInput, ForceMode.VelocityChange);
        //Forward movement is automatic and controlled by the Spline Animate component on TrilobiteRoot
        
        //Move Trilobite side to side
        //trilobiteRb.AddForce(Vector3.left * speed * horizontalInput, ForceMode.VelocityChange);
        //This changes the local X position (lane offset) so left/right stays relative to the rail direction.
        laneOffset += horizontalInput * speed * Time.deltaTime;
        
        //Keep Trilobite in bounds
//        if (transform.position.x < -xRange)
//            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
//        if (transform.position.x > xRange)
//            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
//        if (transform.position.z < -zRange)
//            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
//        if (transform.position.z > zRange)
//            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        //Clamp the lane offset so the player cannot move too far away from the rail centre.
        laneOffset = Mathf.Clamp(laneOffset, -xRange, xRange);

        //Apply the lane offset after Spline Animate has positioned the object this frame.
        Vector3 localPos = transform.localPosition;
        localPos.x = laneOffset;
        transform.localPosition = localPos;
    }

}