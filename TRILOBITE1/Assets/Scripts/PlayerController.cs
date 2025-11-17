using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 30.0f;
    public float verticalInput;
    public float horizontalInput;
    public float xRange = 36;
    public float zRange = 100;
    private Rigidbody trilobiteRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //On this GameObject (the Trilobite), find the Rigidbody component and store it inside rb
        trilobiteRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        //Move Trilobite forward
        trilobiteRb.AddForce(Vector3.back * (speed * verticalInput));

        //Move Trilobite side to side
        trilobiteRb.AddForce(Vector3.left * (speed * horizontalInput));

        //Keep Trilobite in bounds
        if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        if (transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        if (transform.position.z < -zRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        if (transform.position.z > zRange)
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        
        //Stop Trilobite from tipping over
        trilobiteRb.freezeRotation = true;
    }
}