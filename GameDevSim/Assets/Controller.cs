using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviour {
    [SerializeField]
    GameObject DesignEnemy, ProgramEnemy, ArtEnemy;
    float timer = 0;

    [SerializeField]
    Text text, accuracy;

    public value DesignValue, ProgramValue, ArtValue, Sanity;

    public float leftConstraint = 0.0f;
    public float rightConstraint = 0.0f;
    public float topConstraint = 0.0f;
    public float bottomConstraint = 0.0f;
    public float distanceZ = 10.0f;

    playerController player;
    // Use this for initialization
    void Start () {
        leftConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).x;
        rightConstraint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, distanceZ)).x;

        bottomConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0.0f, 0.0f, distanceZ)).y;
        topConstraint = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height, distanceZ)).y;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


            accuracy.text = "Accuracy: " + ((int)(player.ShotsHit / player.shotsFired * 100)).ToString() + "%";
        

        if (timer > 1f)
        {
            timer = 0f;
            switch (Random.Range(0, 3))
            {
                case 0:
                    SpawnEnemy(ArtEnemy);
                    break;
                case 1:
                    SpawnEnemy(DesignEnemy);
                    break;
                case 2:
                    SpawnEnemy(ProgramEnemy);
                    break;

                default:
                    break;
            }
        }

        if (((int)(player.ShotsHit / player.shotsFired * 100)) < 25)
        {
            text.text = "Your accuracy is dipping low. Try being more precise and try to predict enemy movement";
        }

        else if (Sanity.currValue < 50)
        {
            text.text = "Your health is at less than 50%, try to heal, or dodge the enemy shots";
        }

        else
        {
            text.text = "The enemy shots are predictable and easy to dodge.";
        }

            if (DesignValue.currValue == 100 || ProgramValue.currValue == 100 || ArtValue.currValue == 100 )
        {
            Sanity.currValue += Time.deltaTime;
        }

        if (Sanity.currValue <= 1)
        {
            player.gameObject.SetActive(false);
            text.text = "You Died \n";
            if (DesignValue.currValue == 100 || ProgramValue.currValue == 100 || ArtValue.currValue == 100)
            {
                text.text += "You can do better by focusing on enemies that have a stronger presence \n";
            }
            if (((int)(player.ShotsHit / player.shotsFired * 100)) < 25)
            {
                text.text += "Your accuracy is really low. Sometimes it is better to be accurate than spray and pray. \n";
            }
            Invoke("LoadMainMenu", 5);
        }
    }
    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, new Vector3(Random.Range(leftConstraint, rightConstraint), Random.Range(bottomConstraint, topConstraint)),new Quaternion());
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
