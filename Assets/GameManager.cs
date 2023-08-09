using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool won = false;
    public bool lost = false;
    public string nextScene;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lost && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void Win()
    {
        won = true;
        // play some sort of win screen with option to load next level, replay, or return
        SceneManager.LoadScene(nextScene);
    }
    public void Loss()
    {
        lost = true;
        // screen listing cause of death, tip, and retry button
    }
}
