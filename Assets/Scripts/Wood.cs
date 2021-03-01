using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wood : MonoBehaviour
{
    private int health;

    [SerializeField] private GameObject startScript;
    private int knifeCount;
    [SerializeField] private ParticleSystem prefabParticleWood, prefabParticleKnife, prefabParticleKnifeWood;
    [SerializeField] private GameObject applePrefab, knifePrefab;

    private bool playTimer = false;
    private float timer = 90;
    private GameObject apple, knife;
    private GameObject knifeCounter;

    [SerializeField] private List<Vector3> listSpawnKnife = new List<Vector3>();
    [SerializeField] private List<Vector3> listSpawnApple = new List<Vector3>();
    [SerializeField] private Probability probability;
    [SerializeField] private SpeedSetting speed;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public void playParticle(Vector3 pos, ParticleSystem _particle)
    {
        ParticleSystem tempParticle = Instantiate(_particle);
        tempParticle.transform.position = pos;
        tempParticle.Play();
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, speed.SpeedWood);
        if (Health == 0)
        {

            if (playTimer)
            {
                timer--;
                if (timer <= 0) TimerStop();
            }
            else
            {
                gameObject.GetComponent<CircleCollider2D>().enabled = false;
                foreach (Transform child in transform) Destroy(child.gameObject);
                gameObject.GetComponent<SpriteRenderer>().sprite = null;
                Handheld.Vibrate();

                playParticle(transform.position, prefabParticleWood);
                playParticle(transform.position, prefabParticleKnife);
                playParticle(transform.position, prefabParticleKnifeWood);

                playTimer = true;
                GameObject.Find("Knife Thrower").GetComponent<KnifeThrower>().Speed = 90f;
                GameObject.Find("Knife Thrower").GetComponent<KnifeThrower>().Pause = false;
            }

        }
    }

    void TimerStop()
    {
        startScript.GetComponent<StartLevel>().CreateWood();
        Destroy(gameObject);
    }

    void Start()
    {
        startScript = GameObject.Find("Start Level");
        knifeCounter = GameObject.Find("Knife Counter");
        health = Random.Range(4, 8);
        knifeCounter.GetComponent<KnifeCounter>().GenerationKnifeIcon(Health);
        GenerationApple_Knife();

        prefabParticleKnife.GetComponent<Renderer>().material = Resources.Load<Material>("Material/knife/Knife " + (PlayerPrefs.GetInt("idKnife") + 1));
        SettingParticle();
    }

    private void SettingParticle()
    {
        var em = prefabParticleKnife.emission;
        em.enabled = true;
        em.rateOverTime = 0;
        em.SetBursts(new ParticleSystem.Burst[] { (new ParticleSystem.Burst(0.0f, Health)) });

        em = prefabParticleKnifeWood.emission;
        em.enabled = true;
        em.rateOverTime = 0;
        em.SetBursts(new ParticleSystem.Burst[] { (new ParticleSystem.Burst(0.0f, knifeCount)) });
    }
    private void GenerationApple_Knife()
    {
        int randomNumber;
        int probabilityApple = Random.Range(0, 100);
        knifeCount = Random.Range(0, probability.Knife);
        if (probabilityApple <= probability.Apple)
        {
            randomNumber = Random.Range(0, listSpawnApple.Count);
            GenerationObject(randomNumber, applePrefab, apple, listSpawnApple);
        }
        for (int i = 0; i < knifeCount; i++)
        {
            randomNumber = Random.Range(0, listSpawnKnife.Count);
            GenerationObject(randomNumber, knifePrefab, knife, listSpawnKnife);
            listSpawnKnife.RemoveAt(randomNumber);
        }
    }

    private void GenerationObject(int number, GameObject prefab, GameObject @object, List<Vector3> position)
    {
        @object = Instantiate(prefab, transform);
        @object.transform.localPosition = position[number];

        var dir = transform.position - @object.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        @object.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
}
