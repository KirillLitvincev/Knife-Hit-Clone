using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Probability Apple&Knife", fileName = "New Probability")]
public class Probability : ScriptableObject
{
    [SerializeField] private int apple;
    public int Apple
    {
        get { return apple; }
        protected set { }
    }

    [SerializeField] private int knife;
    public int Knife
    {
        get { return knife; }
        protected set { }
    }
}
