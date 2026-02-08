using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class EveMove : MonoBehaviour
{
    public CapsuleCollider myColider;
    public float speed;
    public Rigidbody rig;
    public Transform body;
    public Transform myCam;
    public GameObject gun;

    public float Vertical;
    public float Horizontal;

    float mouseRotationX;
    float mouseRotationY;
    float rotationSpeed = 5;
    float angle;

    float backSpeed = 1.1f;
    float walkSpeed = 2;
    float runSpeed = 4;

    bool crouch = false;

    public ParticleSystem gunfire;
    public ParticleSystem flash;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        body = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        bool run = Input.GetKey("r");
        bool forward = Input.GetKey("w");
        bool back = Input.GetKey("s");
        bool left = Input.GetKey("a");
        bool right = Input.GetKey("d");

        bool aim = Input.GetKey("c");
        bool sit = Input.GetKeyDown("q");

        if (sit) { crouch = !crouch; }
        

        if (forward && run && !crouch)
        {
            speed = runSpeed;
        }
        else if (forward || (forward && run && crouch) || left || right)
        {
            speed = walkSpeed;
        }
        else if (back)
        {
            speed = backSpeed;
        }
        
        /*else if (sit && forward && run)
        {
            timer = 0.833f;
        }*/

        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        Vector3 move = body.forward * Vertical + body.right *Horizontal;

        if (aim)
        {
            rig.linearVelocity = new Vector3(move.x * 0, rig.linearVelocity.y, move.z * 0);
        }
        else { rig.linearVelocity = new Vector3(move.x * speed, rig.linearVelocity.y, move.z * speed); }


            mouseRotationX = Input.GetAxis("Mouse X");
            mouseRotationY = Input.GetAxis("Mouse Y");

            body.Rotate(0, mouseRotationX * rotationSpeed, 0);

            angle -= mouseRotationY * rotationSpeed;
            angle = Mathf.Clamp(angle, -60, 60);

            myCam.rotation = Quaternion.Euler(11, body.eulerAngles.y, 0f);


        if (crouch)
        {
            if (aim)
            {
                gun.SetActive(true);
            }
            else
            {
                gun.SetActive(false);
            }
        }
        else
        {
            gun.SetActive(true);
        }


        if (aim)
        {
            if (Input.GetKeyDown("v"))
            {
                if (gunfire != null && flash != null)
                {
                    gunfire.Play();
                    flash.Play();
                }
            }
        }
            
        


    }

    
}
