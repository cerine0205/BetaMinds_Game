using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using UnityEngine;
using Newtonsoft.Json;
public class dataLogger : MonoBehaviour
{
    private string filePath; // مسار للملف الي بنحفظ فيه البيانات
    private Dictionary<string, string> data = new Dictionary<string, string>() // ديكشنري نخزن فيه البيانات قبل حفظها في الملف
    {
        //  كل البيانات مع قيم مبدئيه
        {"Button Name",null},
        {"Category",null},
        {"Click Count","0"},
      //  {"Event Number","0"},
        {"Previous Button",null},
        {"Hand",null},
        {"Color",null},
        {"Size",null},
        {"Idle Time","0" }
    };

    void Start()
    {
        // انشاء مسار الملف داخل مجلد Assets
        filePath = Application.dataPath + "/Files/PlayerData.json";
    }
    

    public void logClick(string buttonName, string category, int clickCount, int eventNum,string lastButtonPressed) 
    {                                                               // استلام بيانات الازرار وتخزينها في الدكشنري
        data["Button Name"] = buttonName;
        data["Category"] = category;
        data["Click Count"] = clickCount + "";
      //  data["Event Number"] = eventNum + "";
        data["Previous Button"] = lastButtonPressed;
    }

       public void logSurvayResult(string hand, string color, string size)// استلام بيانات الاستبيان وتخزينها في الدكشنري
    {   
        data["Hand"] = hand;
        data["Color"] = color;
        data["Size"] = size;
    }

    public void logScreenTime(float idleTime) // استلام زمن التوقف وتخزينه في الدكشنري
    {
        data["Idle Time"] = idleTime + "";
    }
    

    public void saveToJson() // داله تحفظ كل بيانات الدكشنري في ملف جيسون نربطها مع كل زر
    {
        // تحويل الديكشنري لنص جيسون مع مسافات واسطر جديده لتسهيل القراءه
        string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);

      if (File.Exists(filePath)) // اذا كان الملف موجود من قبل
        {
            // نحفظ البيانات القديمه والجديده
            string oldJson = File.ReadAllText(filePath);
            json = oldJson + ",\n" + json;
        } 

        //  نكتب كل النص الي في متغير json
        // في الملف الي سويناه قبل
        File.WriteAllText(filePath, json.Trim(',')); 
    }



}

















