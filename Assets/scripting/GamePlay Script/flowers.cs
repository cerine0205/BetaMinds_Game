using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class flowers : MonoBehaviour
{
    //buttons
    public Button healing;

    public Button flowerButton;
    public TextMeshProUGUI flowerNum;
    public Image flowerImage;

    public Button flowerButton2;
    public TextMeshProUGUI flowerNum2;
    public Image flowerImage2;

    Animator anim;
    Rigidbody rig;
    public int flowerCount = 0;
    GameObject nearbyFlower;
    bool crouch = false;

    bool isFrozen = false;
    float freezeTimer = 0f;

    bool TimerTrigger = false;
    bool notCollecting = false;
    float notCollectTimer;

    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool sit = Input.GetKeyDown("q");

        if (sit) { crouch = !crouch; }

        if (Input.GetKeyDown("e") && nearbyFlower != null && !crouch)
        {
            anim.SetTrigger("looting");
            flowerCount++;
            print("Flowers collected: " + flowerCount);
            Destroy(nearbyFlower);
            nearbyFlower = null;
            flowerButton.gameObject.SetActive(false);
            flowerButton2.gameObject.SetActive(false);

            isFrozen = true;
            freezeTimer = 0.983f;

            TimerTrigger = true;
            notCollectTimer = 7f;
        }

        if (flowerCount > 0)
        {
            if (Input.GetKeyDown("f") && !crouch)
            {
                anim.SetTrigger("healing");
                flowerCount--;
                isFrozen = true;
                freezeTimer = 1.800f;

                //press Button
                healing.onClick.Invoke();
            }
        }
        else
        {
            if (Input.GetKeyDown("f") && !crouch) { print("no heal in storage"); }
        }

        flowerNum.text = "x " + flowerCount;
        flowerNum2.text = "x " + flowerCount;

        ShowFlower();

        if (isFrozen)
        {
            freezeTimer -= Time.deltaTime;
            rig.linearVelocity = new Vector3(0, rig.linearVelocity.y, 0);
            if (freezeTimer <= 0f)
                isFrozen = false;
            return;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("flower"))
        {
            flowerButton.gameObject.SetActive(true);
            flowerButton2.gameObject.SetActive(true);
            nearbyFlower = other.gameObject;
            notCollecting = false;
            TimerTrigger = false;
            notCollectTimer = 0f;
            flowerImage.gameObject.SetActive(true);
            flowerNum.gameObject.SetActive(true);
            flowerImage2.gameObject.SetActive(true);
            flowerNum2.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("flower") && other.gameObject == nearbyFlower)
        {
            flowerButton.gameObject.SetActive(false);
            flowerButton2.gameObject.SetActive(false);
            nearbyFlower = null;
        }
    }

    void ShowFlower()
    {
        if (notCollecting == true)
        {
            flowerImage.gameObject.SetActive(false);
            flowerNum.gameObject.SetActive(false);
            flowerImage2.gameObject.SetActive(false);
            flowerNum2.gameObject.SetActive(false);
        }
        else
        {
            flowerImage.gameObject.SetActive(true);
            flowerNum.gameObject.SetActive(true);
            flowerImage2.gameObject.SetActive(true);
            flowerNum2.gameObject.SetActive(true);
        }

        if (TimerTrigger == true)
        {
            notCollectTimer -= Time.deltaTime;
            if (notCollectTimer <= 0f)
                notCollecting = true;
            return;
        }
    }
}
