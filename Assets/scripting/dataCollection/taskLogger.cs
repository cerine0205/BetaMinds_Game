using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.InputSystem.Interactions;

public class TaskLogger : MonoBehaviour
{
    private string filePath; // مسار للملف الي بنحفظ فيه البيانات
    private List<string> usedButtons = new List<string>(); //  قائمه لحفظ كل الازرار المستخدمه لتنفيذ مهمه محدده
    private int ActualEventNum = 0; // لحساب عدد الاحداث الي المستخدم يسويها عشان ينفذ مهمه محدده

    private Dictionary<string, object> taskData = new Dictionary<string, object> // ديكشنري نخزن فيه بيانات المهمه قبل حفظها في الملف
    {
        //  كل البيانات مع قيم مبدئيه
        {"Task Name", null},
        {"Expected Event Number",0 },
        {"Expected Buttons",new List<string>() },
        {"Actual Event Number",0},
        {"Used Buttons",new List<string>()}
    };

    void Start()
    {
        // انشاء مسار الملف داخل مجلد Assets
        filePath = Application.dataPath + "/taskData.json";
    }

    public void RegisterButtonPress(Button pressedButton) // نربطه مع كل الازرار عشان نسجل الزر المستعمل
    {
        string buttonName = "";

        if (pressedButton != null)
        {
            buttonName = pressedButton.name; // نحفظ اسم الزر الي استعمله
            ActualEventNum++; //  كل مره يستعمل زر جديد نزيد عدد الاحداث

        }

        usedButtons.Add(buttonName); //  نضيف اسم الزر لقائمه الازرار المستعمله
    }

    void openDoorTask() //  تحديد القيم للمهمه
    {
        taskData["Task Name"] = "open door";
        taskData["Expected Event Number"] = 1;
        taskData["Expected Buttons"] = new List<string>() { "open" };
        taskData["Actual Event Number"] = ActualEventNum;
        taskData["Used Buttons"] = usedButtons;

    }

    void doubleJumbTask() //  تحديد القيم للمهمه
    {
        taskData["Task Name"] = "double jump";
        taskData["Expected Event Number"] = 2;
        taskData["Expected Buttons"] = new List<string>() { "jump", "jump" };
        taskData["Actual Event Number"] = ActualEventNum;
        taskData["Used Buttons"] = usedButtons;

    }

    public void ResetTask(string taskName)  // نربطه مع زر نبي تنفيذ المهمه ينتهي عنده
    {
        // نسجل البيانات في الدكشنري عن طريق استدعاء الدوال المخصصه
        if (taskName == "open door")
            openDoorTask(); //  تحديث البيانات الجديده لمهمه فتح الباب

        else if (taskName == "double jump")
            doubleJumbTask(); // تحديث البيانات الجديده لمهمه النط المزدوج

        saveToJson(); // حفظ البيانات في ملف جيسون

        //اعاده تعيين للقيم عشان لو بنسجل مهام جديده
        usedButtons.Clear();
        ActualEventNum = 0;
    }

    void saveToJson() // داله تحفظ كل بيانات الدكشنري في ملف جيسون 
    {
        // تحويل الديكشنري لنص جيسون مع مسافات واسطر جديده لتسهيل القراءه
        string json = JsonConvert.SerializeObject(taskData, Newtonsoft.Json.Formatting.Indented);

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











////