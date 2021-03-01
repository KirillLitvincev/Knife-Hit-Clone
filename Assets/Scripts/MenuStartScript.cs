using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStartScript : MonoBehaviour
{
    [SerializeField] private GameObject score, money;

    private void Start()
    {
        score.GetComponent<Text>().text = "Score: " + PlayerPrefs.GetInt("Record").ToString();
        money.GetComponent<Text>().text = PlayerPrefs.GetInt("Money").ToString();
    }
}
