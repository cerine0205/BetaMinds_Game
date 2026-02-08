using UnityEngine;

public class ScreenTimeTracker : MonoBehaviour
{
    // idleTime هو زمن توقف الشاشه من غير ضغط اي زر
    private float idleTime = 0f;   // تعيين زمن توقف مبدئي

    private bool isTracking = true;  // متغير يساعدنا نوقف او نكمل حساب زمن التوقف

    public dataLogger savingData; // نحتاجه لحفظ البيانات في ملف جيسون
    void Update() // يشتغل في كل فريم
    {
        // طول ما اللعبه شغاله والمتغير قيمته ترو
        if (isTracking) 
            idleTime += Time.deltaTime; // زيد زمن توقف الشاشه

    }
    
    // if the user press any button
    public void userISInteract() // نربطه مع كل زر
    {
        isTracking = false; //  عشان يوقف يزود زمن التوقف
        savingData.logScreenTime(idleTime);  // ارسال البيانات لداله تحفظها في ديكشنري

        idleTime = 0f; //نعيد تعين القيمه عشان اذا بنحسب زمن توقف جديد
        isTracking = true; // عشان يبدا يحسب من جديد

    }
}
