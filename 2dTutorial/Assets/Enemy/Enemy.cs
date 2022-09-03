using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed = 2f;
    [SerializeField] GameObject _gameState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, Time.deltaTime * _speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(gameObject);

        if (collider.gameObject.name == "Player")
            GameState.Instance.InitiateGameOver();

        Destroy(collider.gameObject);
        GameState.Instance.IncreaseScore(10);
    }
}
