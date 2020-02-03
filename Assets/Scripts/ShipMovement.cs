using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public delegate void ShipEvent();
    public event ShipEvent OnShipDestroyed;

    [Header("Waypoints the ship should go to, in this order")]
    public GameObject[] waypoints;

    [Header("Speed of the ship")]
    public float speed = 1f;

    [Header("Prefab to be instansiated when the ship is destroyed")]
    public GameObject destroyedPrefab;

    [Header("How much the speed affects the thrust sound volume")]
    public float thrustSoundFactor;

    AudioSource _thrustSound;
    // Current index we're at
    int _currentWaypointIndex = 0;
    Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _thrustSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // If we've hit the last waypoint, destroy ship
        if (_currentWaypointIndex >= waypoints.Length)
        {
            Destroyed();
            return;
        }

        GameObject currentWaypoint = waypoints[_currentWaypointIndex];

        Vector2 direction = currentWaypoint.transform.position - this.transform.position;
        direction.Normalize();

        // Face ship towards travel
        this.transform.up = Vector2.Lerp(this.transform.up, direction, 0.2f);

        _rb.AddForce(direction * speed * Time.deltaTime, ForceMode2D.Force);

        _thrustSound.volume = _rb.velocity.magnitude * thrustSoundFactor;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Hit the target waypoint? Move on to the next.
        // Hit an asteroid? BOOM
        if (collision.gameObject == waypoints[_currentWaypointIndex]) _currentWaypointIndex++;
        else if (collision.CompareTag("Asteroid")) Destroyed();
    }


    // Called when the ship is destroyed
    public void Destroyed()
    {
        GameObject destroyedFx = Instantiate(destroyedPrefab);
        destroyedFx.transform.position = this.transform.position;
        destroyedFx.transform.up = this.transform.up;

        destroyedFx.GetComponent<DestroyedShipFx>().DestroyFrom(_rb.velocity);

        OnShipDestroyed?.Invoke();

        Destroy(gameObject);
    }
}
