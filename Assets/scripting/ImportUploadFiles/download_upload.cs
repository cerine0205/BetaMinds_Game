using UnityEngine;

using UnityEngine.Networking;

using System.Collections;

using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;



public class downloadTest2 : MonoBehaviour

{
    private string path = Application.dataPath + "/Files/n8nSuggestion.json"; 

    public TextAsset playerDataFile;

    //private string url = "https://cerine07.app.n8n.cloud/webhook-test/e0a7ed0e-ce63-410e-866b-cd15e2352cd1"; //test
    private string url = "https://cerine07.app.n8n.cloud/webhook/e0a7ed0e-ce63-410e-866b-cd15e2352cd1"; // production

    playerData player = new playerData();


    IEnumerator Start()

    {

        string jsonData = "[" + playerDataFile.text + "]";

        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);


        UnityWebRequest req = new UnityWebRequest(url, "POST");

        req.uploadHandler = new UploadHandlerRaw(bodyRaw);

        req.downloadHandler = new DownloadHandlerBuffer();

        req.SetRequestHeader("Content-Type", "application/json");



        yield return req.SendWebRequest();


        if (req.result == UnityWebRequest.Result.Success)

        {

            string jsonResponse = req.downloadHandler.text;

            Debug.Log(" Raw Response: " + jsonResponse);


            File.WriteAllText(path, jsonResponse);
            N8N_Response response = JsonUtility.FromJson<N8N_Response>(jsonResponse);

        }

        else
        {
             Debug.LogError(" Error: " + req.error);
        }

    }

}



[System.Serializable]

public class N8N_Response

{
    public string ButtonName;
    public string action;
    public string color;
    public string hand;
    public string message;
}



[System.Serializable]
class playerData
{
    public string ButtonName;
    public string Category;
    public string ClickCount;
    public string EventNumber;
    public string PreviousButton;
    public string Hand;
    public string Color;
    public string Size;
    public string IdleTime;
}
