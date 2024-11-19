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
    public List<PermaUpgrades> permanentUpgrades;
    [SerializeField] private GameObject permaUpgradePrefab;
    [SerializeField] private GameObject upgradePanel;

    private void Start()
    {
        permanentUpgrades = new List<PermaUpgrades>(Resources.LoadAll<PermaUpgrades>("PermaUpgrades"));
        int verticalPos = 731;
        foreach(PermaUpgrades b in permanentUpgrades)
        {
            GameObject.Instantiate(permaUpgradePrefab, new Vector3(671.2686f, verticalPos, 0) , transform.rotation, upgradePanel.transform);
            verticalPos -= 85;
        }
    }

    public void CookieClicked()
    {
        money += MPC;
    }

    private void Update()
    {
        money += MPS * Time.deltaTime;
        text.text = "$ " + ((long)money).ToString();
        foreach(PermaUpgrades b in permanentUpgrades)
        {
            Debug.Log(b.title);
        }
    }
}
