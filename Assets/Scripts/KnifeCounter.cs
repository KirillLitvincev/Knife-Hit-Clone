using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnifeCounter : MonoBehaviour
{
    [SerializeField] private GameObject knifeIcon;
    [SerializeField] private Color activeColor;
    [SerializeField] private Color deactiveColor;
    List<GameObject> iconList = new List<GameObject>();
    private int val;

    public void GenerationKnifeIcon(int count)
    {
        foreach (var item in iconList)
        {
            Destroy(item);
            val = 0;
        }
        iconList.Clear();

        for (int i = 0; i < count; i++)
        {
            GameObject temp = Instantiate<GameObject>(knifeIcon, transform);
            temp.GetComponent<Image>().color = activeColor;
            iconList.Add(temp);
        }
    }
    public void setHitedKnife()
    {
        val++;
        for (int i = 0; i < iconList.Count; i++)
        {
            iconList[i].GetComponent<Image>().color = i < val ? deactiveColor : activeColor;
        }
    }
}
