using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickingLogic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] int cookieNumber = 0;

    public void CookieClicked()
    {
        cookieNumber++;
        text.text = cookieNumber.ToString();
    }
}
