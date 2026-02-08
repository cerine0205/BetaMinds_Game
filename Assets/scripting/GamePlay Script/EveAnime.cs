using UnityEngine;

public class EveAnime : MonoBehaviour
{
    Animator EveAn;
    bool crouch = false;

    void Start()
    {
        EveAn = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool walk = Input.GetKey("w");
        bool back = Input.GetKey("s");
        bool right = Input.GetKey("d");
        bool left = Input.GetKey("a");

        bool run = Input.GetKey("r");
        bool aim = Input.GetKey("c");
        bool shoot = Input.GetKeyDown("v");
        bool sit = Input.GetKeyDown("q");

        if (sit)
        {
            if (!crouch)
            {
                EveAn.SetBool("crouching", true);
                EveAn.SetBool("standing", false);
            }
            else
            {
                EveAn.SetBool("standing", true);
                EveAn.SetBool("crouching", false);
            }
                crouch = !crouch;
        }

        if(EveAn.GetBool("crouching") == true)
        {
            EveAn.SetBool("CrWalking", walk);
            EveAn.SetBool("CrBacking", back);
            EveAn.SetBool("CrRight", right);
            EveAn.SetBool("CrLeft", left);
        }

        EveAn.SetBool("walking", walk);
        EveAn.SetBool("behind", back);
        EveAn.SetBool("Right", right);
        EveAn.SetBool("Left", left);

        EveAn.SetBool("running", run && walk);
        EveAn.SetBool("aiming", aim);
        if (aim && shoot)
        {
            EveAn.SetTrigger("shooting");
        }
    }
}
