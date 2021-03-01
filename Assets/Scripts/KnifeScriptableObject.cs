using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Knife", fileName = "Knife")]
public class KnifeScriptableObject : ScriptableObject
{
    [SerializeField] private Sprite spriteKnife;
    public Sprite SpriteKnife
    {
        get { return spriteKnife; }
    }

    [SerializeField] private bool active;
    public bool Active
    {
        get { return active; }
        set { active = value; }
    }


}