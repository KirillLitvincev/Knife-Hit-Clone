using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Speed setting", fileName = "New Speed Setting")]
public class SpeedSetting : ScriptableObject
{
    [SerializeField] private int speedRespawnKnife;
    public int SpeedRespawnKnife
    {
        get { return speedRespawnKnife; }
        protected set { }
    }

    [SerializeField] private int speedWood;
    public int SpeedWood
    {
        get { return speedWood; }
        protected set { }
    }
}
