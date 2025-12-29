using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float xRange = 15.0f; //how far left/right from the rail centre
    private int currentLane = 0; //current lane
    private Vector3 startLocalPos; // starting local position for LaneOffset
    public float laneSnapSpeed = 30.0f; //how quickly it snaps to the target lane offset
    private float laneOffset; // current x offset we are applying relative to startLocalPos
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //Forward movement now using Spline Animate on TrilobiteRoot, so all Rigidbody code removed
        startLocalPos = transform.localPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        //Move Trilobite forwards is controlled by Spline Animate on TrilobiteRoot
        
        //Move Trilobite side to side
        
        // This changes lane ONCE per key press and stays there
        if (Input.GetKeyDown(KeyCode.RightArrow))
            currentLane = Mathf.Max(currentLane - 1, -1);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            currentLane = Mathf.Min(currentLane + 1, 1);
        
        //Convert lane index
        float targetOffset = currentLane * xRange;

        
        //Keep Trilobite in bounds

        //Control how fast it slides.
        laneOffset = Mathf.Lerp(laneOffset, targetOffset, laneSnapSpeed * Time.deltaTime);
        
        //Apply the lane offset after Spline Animate has positioned the object this frame.
        transform.localPosition = startLocalPos + new Vector3(laneOffset, 0f, 0f);

    }

}