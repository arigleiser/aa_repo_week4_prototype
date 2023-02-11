using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class releaseApples : MonoBehaviour
{
    public GameObject applePrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(appleWave());
    }
    private void spawnEnemy()
    {
        GameObject a = Instantiate(applePrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * -2);
    }
    IEnumerator appleWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}