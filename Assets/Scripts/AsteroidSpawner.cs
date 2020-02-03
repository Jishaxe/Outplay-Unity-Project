using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [Header("Prefab to use as asteroid")]
    public GameObject asteroidPrefab;

    [Header("Amount of asteroids to spawn")]
    public int amount;

    [Header("Change how quickly the asteroids pop in from the center")]
    public float popinDelayMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        // Find world space coords of the top left and bottom right corners
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        for (int i = 0; i < amount; i++)
        {
            // Pick a random position within the screen
            Vector2 randomPosition = new Vector2(Random.Range(bottomLeft.x, topRight.x), Random.Range(bottomLeft.y, topRight.y));

            // create asteroid parented to the gameobject
            GameObject asteroid = Instantiate(asteroidPrefab, this.transform);

            asteroid.transform.position = randomPosition;

            // just reuse random position as random rotation cause im lazy
            asteroid.transform.rotation = Quaternion.AngleAxis(Random.Range(0, 360), Vector3.forward);

            asteroid.GetComponent<AsteroidDiversifier>().PopinAfter(1 - Mathf.Abs(asteroid.transform.position.magnitude) * popinDelayMultiplier);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
