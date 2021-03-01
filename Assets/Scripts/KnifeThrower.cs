using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrower : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private GameObject knifePrefab;
    [SerializeField] private GameObject knife;
    [SerializeField] private SpeedSetting speedSetting;
    private bool timer, pause = true;
    private float speed;

    public bool Pause
    {
        set { pause = value; }
    }
    public float Speed
    { 
        set { speed = value; }
    }

    void Start()
    {
        speed = speedSetting.SpeedRespawnKnife;
        knife = Instantiate(knifePrefab, transform);
        knife.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/knife/knife" + (PlayerPrefs.GetInt("idKnife") + 1));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&pause)
        {
            knife.transform.parent = null;
            knife.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force, ForceMode2D.Impulse);
            timer = true;
            pause = false;
        } 
    }

    private void FixedUpdate()
    {
        if (timer)
        {
            speed--;
            if (speed <= 0)
            {
                knife = Instantiate(knifePrefab, transform);
                knife.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/knife/knife"+ (PlayerPrefs.GetInt("idKnife") + 1));
                timer = false;
                speed = speedSetting.SpeedRespawnKnife;
                pause = true;

            }
        }
    }
}
