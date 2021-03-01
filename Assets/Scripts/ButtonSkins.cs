using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSkins : MonoBehaviour
{
    [SerializeField] private ControlSkinsScene menager;

    public void clickButton(int id)
    {
        menager.Error.SetActive(false);
        menager.SelectElement = id;
        menager.lookKnife.transform.Find("ImageKnife").GetComponent<Image>().sprite = gameObject.transform.Find("Knife").gameObject.GetComponent<Image>().sprite;
        if (menager.knifeObject[id].Active) menager.lookKnife.transform.Find("Animation").gameObject.SetActive(true);
        else menager.lookKnife.transform.Find("Animation").gameObject.SetActive(false);
        menager.Fill(id);

    }
   
    public void Buy()
    {
        if(menager.knifeObject[menager.SelectElement].Active)
        {

            Error("Already bought");
        }
        else
        {
            int money = PlayerPrefs.GetInt("Money");
            if (money< 50)
            {
                Error("Not enough apples");
            }
            else
            {
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money")-50);
                menager.Money.text = PlayerPrefs.GetInt("Money").ToString();

                PlayerPrefs.SetInt("Knife" + menager.SelectElement, 1);
                menager.StartFill();
            }
        }
    }

    public void Use()
    {
        if (menager.knifeObject[menager.SelectElement].Active)
        {
            PlayerPrefs.SetInt("idKnife", menager.SelectElement);
            Error("Done");
        }
        else
        {
            Error("Not available");
        }
    }

    private void Error(string text)
    {
        menager.Error.GetComponent<Text>().text = text;
        menager.Error.SetActive(true);
    }



}
