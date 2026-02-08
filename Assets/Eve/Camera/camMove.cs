using UnityEngine;

public class camMove : MonoBehaviour
{
    Animator camAn;
    void Start()
    {
        camAn = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        camAn.SetBool("aim", Input.GetKey("c"));
    }
}
