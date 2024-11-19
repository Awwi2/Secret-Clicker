using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New PermaUpgrade", menuName = "Permanent Upgrade")]
public class PermaUpgrades : ScriptableObject
{
    public Sprite image;
    public string title = "New PermaUpgrade";
    public int cost;
    public float mpsModifier;
    public float mpcModifier;

    [Space(20)]
    [Header("Do not assign value in Inspector")]
    public Button button;
}
