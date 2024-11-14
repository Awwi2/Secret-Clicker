using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClickingLogic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text; 
    [SerializeField] float money = 0; //The abstract concept of currency in virtual world
    public float MPC = 1; //Money Per Click
    public float MPS = 0; //Money per Second
    public List<PermanentUpgrade> permanentUpgrades = new List<PermanentUpgrade>();

    public void CookieClicked()
    {
        money += MPC;
    }
    private void Update()
    {
        money += MPS * Time.deltaTime;
        text.text = "$ " + ((long)money).ToString();
        foreach(PermanentUpgrade b in permanentUpgrades)
        {
            Debug.Log(b.title);
        }
    }

    //Work in progress
    public class PermanentUpgrade
    {
        public Button button;
        public string title;
        public int cost;
        public float mpsModifier;

        public PermanentUpgrade(Button button, string title, int cost, float mpsModifier)
        {
            this.button = button;
            this.title = title;
            this.cost = cost;
            this.mpsModifier = mpsModifier;
        }
    }
}
