using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameState : MonoBehaviour
{

    int _score = 0;

    bool _isGameOver = false;

    [SerializeField] GameObject _scoreText;
    [SerializeField] GameObject _gameOverText;

    public static GameState Instance;

    private void Awake()
    {
        Instance = this; 
    }

    public void IncreaseScore(int amount)
    {
        _score += amount;
        _scoreText.GetComponent<Text>().text = "Score: " + _score;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetButtonDown("Submit") && _isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void InitiateGameOver()
    {
        _isGameOver = true;
        _gameOverText.SetActive(true);
    }
}
