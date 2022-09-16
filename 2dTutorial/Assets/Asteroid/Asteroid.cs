using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float _speed = 2f;
    [SerializeField] GameObject _gameState;
    [SerializeField] Sprite []  hitSprite;
    [SerializeField] int timehit;
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
        if(tag == "Breakable")
        {
            HitControl();
        }

        if (collider.gameObject.name == "Player")
        {
            Destroy(collider.gameObject);
            GameState.Instance.InitiateGameOver();
        }

        else if (collider.gameObject.name == "Shield")
        {
            GameState.Instance._Shield.SetActive(false);
        }
        else
        {
            Destroy(collider.gameObject);
        }

        
        GameState.Instance.IncreaseScore(5);
    }
    private void HitControl()
    {
        timehit++;
        int maxhit = hitSprite.Length + 1;
        if(timehit >= maxhit)
        {
            Destroy(gameObject);
        }
        else
        {
            ShowNextSprite();
        }
        
    }
    private void ShowNextSprite()
    {
        int spriteIndex = timehit - 1;
        if(hitSprite[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        }
        
    }
}
