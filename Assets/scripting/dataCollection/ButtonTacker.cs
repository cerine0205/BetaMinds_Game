using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ButtonTacker : MonoBehaviour
{

    //  نخزن اسم كل زر مع عدد ضغطاته
    Dictionary<string, int> clickNum = new Dictionary<string , int>();

    public int eventNum = 0; //ترتيب الحدث هل كان الاول الثاني او ايش // data
    String lastButtonPressed = null; // data
    public dataLogger dataSaving; // نحتاجه لحفظ البيانات في ملف جيسون

    public void RecordClick(Button button) // داله ترتبط مع كل زر في يونتي لحساب بياناته
    {
        
        string buttonName = button.name; //data
        string buttonCategory = button.tag; //data
        eventNum++; 

        // count the num of click
        if (clickNum.ContainsKey(buttonName))
        {
            clickNum[buttonName]++; // الزر موجود من قبل زيد قيمته //data
        }

        else
        {
            clickNum[buttonName] = 1; // الزر جديد نبدا العد من واحد
        }


        dataSaving.logClick(buttonName, buttonCategory, clickNum[buttonName], eventNum, lastButtonPressed); // ارسال البيانات لداله تحفظها في ديكشنري

        lastButtonPressed = button.name; 

    }    
    
}

