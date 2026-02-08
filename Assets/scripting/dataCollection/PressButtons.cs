using UnityEngine;
using UnityEngine.UI;

public class PressButtons : MonoBehaviour
{
    // Buttons to collect
    public Button movmentButtons;
    public Button run;
    public Button Aiming;
    public Button shooting;
    public Button jump;

    public Button crouch;

    public Button Pause;
  
    //sit
    //loot

    void Update()
    {
        // press Buttons
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) ||  Input.GetKeyDown(KeyCode.A))
            movmentButtons.onClick.Invoke();

        if (Input.GetKeyDown(KeyCode.C))
            Aiming.onClick.Invoke();

        if (Input.GetKeyDown(KeyCode.V) && Input.GetKey(KeyCode.C))
            shooting.onClick.Invoke();

        if (Input.GetKeyDown(KeyCode.Escape))
            Pause.onClick.Invoke();

        if (Input.GetKeyDown(KeyCode.Q))
            crouch.onClick.Invoke();
            
          if (Input.GetKeyDown(KeyCode.R) && Input.GetKey(KeyCode.W))
            run.onClick.Invoke();

            // sit
            //loot
    }
    
}
