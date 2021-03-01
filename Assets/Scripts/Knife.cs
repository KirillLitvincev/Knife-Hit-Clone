using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knife : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;
    public bool attachedToWood;
    private GameObject oblectNew;
    private bool playTimer = false, pause = false;
    private float timer = 60;
    [SerializeField] private ParticleSystem hitPrefab;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!pause)
        {
            if (col.gameObject.tag == "Knife" && col.gameObject.GetComponent<Knife>().attachedToWood == true)
            {
                pause = true;
                Handheld.Vibrate();
                Destroy(gameObject);

                PlayerPrefs.SetInt("SaveScore", int.Parse(GameObject.Find("Score").GetComponent<Text>().text));
                PlayerPrefs.SetInt("Money", int.Parse(GameObject.Find("Currency").GetComponent<Text>().text));

                Pause();

                GameObject.Find("Text Record").GetComponent<Text>().text = PlayerPrefs.GetInt("SaveScore").ToString();
                GameObject.Find("Money").GetComponent<Text>().text = PlayerPrefs.GetInt("Money").ToString();

                if (PlayerPrefs.GetInt("SaveScore") > PlayerPrefs.GetInt("Record"))
                {
                    PlayerPrefs.SetInt("Record", PlayerPrefs.GetInt("SaveScore"));
                    Debug.Log(PlayerPrefs.GetInt("Record"));
                }
            }

            if (col.gameObject.tag == "Wood" && !attachedToWood)
            {
                Handheld.Vibrate();
                rigidbody.velocity = Vector2.zero;
                transform.parent = col.transform;

                playParticle(col.transform.position, hitPrefab);
                Animator anim = col.GetComponent<Animator>();
                anim.Play("Hit");

                attachedToWood = true;
                col.gameObject.GetComponent<Wood>().Health -= 1;

                int score = int.Parse(GameObject.Find("Score").GetComponent<Text>().text);
                score++;
                GameObject.Find("Score").GetComponent<Text>().text = score.ToString();
                GameObject.Find("Knife Counter").GetComponent<KnifeCounter>().setHitedKnife();
            }

            if (col.gameObject.tag == "Apple")
            {
                oblectNew = col.transform.Find("CutApple").gameObject;
                oblectNew.transform.parent = null;
                Destroy(col.gameObject);

                int Currency = int.Parse(GameObject.Find("Currency").GetComponent<Text>().text);
                Currency = Currency + 2;
                GameObject.Find("Currency").GetComponent<Text>().text = Currency.ToString();

                oblectNew.SetActive(true);
                oblectNew.transform.Find("Apple_Right").GetComponent<Rigidbody2D>().AddForce(new Vector2(3, 5), ForceMode2D.Impulse);
                oblectNew.transform.Find("Apple_Left").GetComponent<Rigidbody2D>().AddForce(new Vector2(-3, 5), ForceMode2D.Impulse);
                playTimer = true;
            }
        }
    }
    private void FixedUpdate()
    {
        if (playTimer)
        {
            timer--;
            if (timer <= 0) Destroy(oblectNew);
        }
    }
    public void playParticle(Vector3 pos, ParticleSystem _particle)
    {

        ParticleSystem tempParticle = Instantiate(_particle);
        tempParticle.transform.position = pos;
        tempParticle.Play();


    }

    private void Pause()
    {
        

        
        GameObject ui = GameObject.Find("Start Level");
        ui.GetComponent<StartLevel>().FieldPlay.SetActive(false);
        ui.GetComponent<StartLevel>().Ui.SetActive(false);
        ui.GetComponent<StartLevel>().GameOver.SetActive(true);
        ui.SetActive(false);

    }
}
