using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerCollectController : MonoBehaviour
{
    private int score = 0;
    private bool level = false;
    private int currentLevel = 1;
    private Animation anim;
    [SerializeField] private TextMeshProUGUI tm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tm = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((score == 3) && (level == false))
        {
            level = true;
            GameObject.Find($"LevelGap{currentLevel.ToString()}").GetComponent<Animation>().Play($"Lvl{currentLevel.ToString()}");

        }
        tm.SetText("Score: " + score.ToString());

        if (level == true)
        {
            if (GameObject.Find("Player").transform.position.x > 10)
            {
                level = false;
                currentLevel++;
                score = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coins")
        {
            
            StartCoroutine(PlayUntilDestroy(collision.gameObject));
        }
    }
    IEnumerator PlayUntilDestroy(GameObject coin)
    {
        AudioSource sound = coin.GetComponent<AudioSource>();
        score++;
        sound.Play();
        yield return new WaitForSeconds(0.5f);
        Destroy(coin);
    }

}