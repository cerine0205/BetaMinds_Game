using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;


public class readJsonFile : MonoBehaviour
{
    public TextAsset file; // n8n suggestion
    public GameObject rightCanves;
    public GameObject leftCanves;
    public GameObject[] GameButtons;

    void Start()
    {
        if (file != null && file.text != "")
        {
            var Buttonschanges = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(file.text);

        
            foreach(var change in Buttonschanges)
            {
               ApplyChange(change["Button Name"], change["Suggested Action"],change["Color"], change["Hand"]);
            }
          
        }
    }
    
    void ApplyChange(string buttonName, string action,string color,string hand)
    {
        GameObject btn = null;
        foreach (GameObject b in GameButtons)
        {
            if (b.name == buttonName)
            {
                btn = b;
                break;
            }

        }

        if (btn == null) return;


        switch (action.Trim())
        {
            case "Increase size":
                btn.transform.localScale *= 1.5f;
                break;

            case "Decrease size":
                btn.transform.localScale *= .7f;
                break;

            case "Hide the button":
                btn.SetActive(false);
                break;

            default:
                break;

        }


        if (color != null)
        {
            switch (color.Trim())
            {
                case "orange":
                    foreach (GameObject b in GameButtons)
                    {
                        b.GetComponent<Image>().color = Color.orange;
                    }
                    break;

                case "Beige":
                    foreach (GameObject b in GameButtons)
                        b.GetComponent<Image>().color = Color.white;
                    break;

            }
        }

        if(hand != null)
        {
            switch (hand.Trim())
            {
                case "Right":
                    rightCanves.SetActive(true);
                    leftCanves.SetActive(false);
                    break;

                case "Left":
                    leftCanves.SetActive(true);
                    rightCanves.SetActive(false);
                    break;

            }
        }


    }
}
