using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollectController : MonoBehaviour
{
    public PlayerEnemyController pec;
    private int score;
    private bool level = false;
    private int currentLevel;
    public Vector3 checkpoint;
    private Animation anim;
    [SerializeField] private TextMeshProUGUI tm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = SceneManager.GetActiveScene().buildIndex * 6;
        currentLevel = SceneManager.GetActiveScene().buildIndex * 2 + 1;
        tm = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        checkpoint = GameObject.Find("Player").transform.position;
        pec = GetComponent<PlayerEnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").transform.position.y < -5 && level == false)
        {
            pec.HP = 0;
        }
            if ((score == 3 * currentLevel) && (level == false))
            {
                level = true;
                GameObject.Find($"LevelGap{currentLevel.ToString()}").GetComponent<Animation>().Play($"Lvl{currentLevel.ToString()}");

            }
            tm.SetText("Score: " + score.ToString());

            if (level == true)
            {
                if (GameObject.Find("Player").transform.position.x > 9 * currentLevel * currentLevel)
                {
                    checkpoint = GameObject.Find("Player").transform.position;
                    Debug.Log("Level changed");
                    level = false;
                    currentLevel++;
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