using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeLoadSprite : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/knife/knife" + (PlayerPrefs.GetInt("idKnife") + 1));
    }
}
