using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSkinsScene : MonoBehaviour
{
    public List<KnifeScriptableObject> knifeObject;
    [SerializeField] private List<GameObject> knife;
    [SerializeField] private List<Material> MaterialKnife;
    [SerializeField] private Sprite spriteGreen, spriteDark;
    public Text Money;
    public GameObject lookKnife;
    public GameObject Error;
    private int selectElement;
    [SerializeField] private GameObject prefabKnife, prefabKnifeWood;
    [SerializeField] private ParticleSystem KnifeParticle;
    public int SelectElement
    {
        get { return selectElement; }
        set { selectElement = value; }
    }

    private void Start()
    {
        Money.text = PlayerPrefs.GetInt("Money").ToString();
        StartFill();
    }


    public void Fill(int id)
    {
        for (int i = 0; i < knife.Count; i++)
        {
            knife[i].transform.Find("Select").gameObject.SetActive(false);
        }
        knife[id].transform.Find("Select").gameObject.SetActive(true);
    }
    public void StartFill()
    {
        for (int i = 1; i < knifeObject.Count; i++)
        {
            if (PlayerPrefs.GetInt("Knife" + i) == 1)
            {
                knifeObject[i].Active = true;
            }
        }
        for (int i = 0; i < knifeObject.Count; i++)
        {
            if (knifeObject[i].Active)
            {
                knife[i].GetComponent<Image>().sprite = spriteGreen;
                knife[i].transform.Find("Knife").GetComponent<Image>().sprite = knifeObject[i].SpriteKnife;
            }
        }
    }
}
