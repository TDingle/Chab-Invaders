using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawn : MonoBehaviour
{
    [SerializeField] GameObject _laserUFOPrefab;
    bool shoot = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (shoot)
        {
            Instantiate(_laserUFOPrefab, transform.position + Vector3.forward, Quaternion.identity);
            StartCoroutine(shootLaser());
        }

    }
    IEnumerator shootLaser()
    {
        shoot = false;
        yield return new WaitForSeconds(4);
        shoot = true;
    }
}
    
