using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartLevel : MonoBehaviour
{
    [SerializeField]private GameObject gameOver, ui, fieldPlay, prefabWood, money;
    public GameObject GameOver
    {
        get { return gameOver; }
        set { gameOver = value; }
    }

    public GameObject Ui
    {
        get { return ui; }
        set { ui = value; }
    }

    public GameObject FieldPlay
    {
        get { return fieldPlay; }
        set { fieldPlay = value; }
    }

    public GameObject PrefabWood
    {
        get { return prefabWood; }
        set { prefabWood = value; }
    }

    public GameObject Money
    {
        get { return money; }
        set { money = value; }
    }


    void Start()
    {
        money.GetComponent<Text>().text = PlayerPrefs.GetInt("Money").ToString();
        CreateWood();
    }

    public void CreateWood()
    {
        Instantiate(prefabWood, fieldPlay.transform);
    }
}
