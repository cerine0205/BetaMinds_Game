using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class survayResult : MonoBehaviour
{

    // ربط الازرار الي نحتاجها من الانسبكتور
    public Toggle right; 
    public Toggle Beige;
    public Toggle small;
    public Toggle meidum;
    //

    public dataLogger dataSaving; // نحتاجه لحفظ البيانات في ملف جيسون
   
    public void recordAnswer() // نربطه بزر ال submit 
    {
        //  نشيك على القيمه المدخله من المستخدم (هل حط صح على هذا الزر؟)
        string hand = right.isOn ? "Right" : "Left";
        string color = Beige.isOn ? "Beige" : "orange";
        string size = small.isOn ? "Small" : meidum.isOn ? "Meidum" : "Large";

        dataSaving.logSurvayResult(hand, color, size);  // ارسال البيانات لداله تحفظها في ديكشنري
    }

    
}
