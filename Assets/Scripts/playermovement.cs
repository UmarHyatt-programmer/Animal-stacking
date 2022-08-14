using UnityEngine;

public class playermovement : MonoBehaviour
{
    public Rigidbody rb;
    public int maxForce;
    public float farwardForce = 2000f;
    public float sidewayForce = 500f;
    public HyperInput _hyperInput;
    // public GameObject cam;
    //public float _maxLeft, _maxRight;
    Touch _touch;
    public float _speedModifier;

    private void Start()
    {
        _hyperInput = FindObjectOfType<HyperInput>();
    }
    // private void Update() 
    // {
    //     float _limit = Mathf.Clamp(_hyperInput.moveFactor,_maxLeft,_maxRight);



    //     transform.Translate(Vector3.right*_limit*Time.deltaTime*sidewayForce);
    // }
    // Update is called once per frame
    void FixedUpdate()
    {
        //  rb.velocity = new Vector3(0,0,farwardForce * Time.deltaTime);
        if (rb.velocity.magnitude < maxForce)
        {
            rb.AddForce(new Vector3(0, 0, farwardForce * Time.deltaTime));
        }

        if (Input.GetKey("d") || Input.GetKey("o"))
        {
            rb.AddForce(sidewayForce, 0, 0, ForceMode.Force);
        }
        if (Input.touchCount > 0)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Moved)
            {
                rb.AddForce(_touch.deltaPosition.x * _speedModifier, 0, 0, ForceMode.Force);
            }
        }
        if (Input.GetKey("a") || Input.GetKey("i"))
        {
            rb.AddForce(-sidewayForce, 0, 0, ForceMode.Force);
        }
    }
}
