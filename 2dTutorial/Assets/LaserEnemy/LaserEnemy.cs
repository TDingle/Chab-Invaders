using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    [SerializeField] float _speed = 2f;
    [SerializeField] GameObject _gameState;
    [SerializeField] GameObject _laserUFOPrefab;
    
  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        transform.position -= new Vector3(0, Time.deltaTime * _speed, 0);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y < 0)
        {
            Destroy(gameObject);


        }
    }
      

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);

        if (collider.gameObject.name == "Player")
        {
            GameState.Instance.InitiateGameOver();
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.name == "Shield")
        {
            GameState.Instance._Shield.SetActive(false);
        }
        else
        {
            Destroy(collider.gameObject);
        }

        
        GameState.Instance.IncreaseScore(50);
    }

   
}