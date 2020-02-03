using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDiversifier : MonoBehaviour
{
    [Header("Asteroid sprites we can use")]
    public Sprite[] asteroidSprites;

    [Header("How much to slightly push the asteroid")]
    public float pushForce;

    [Header("How much the size should vary for the asteroid")]
    public Vector2 sizeVariation;

    public SpriteRenderer spriteRenderer;

    Animator _animator;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        spriteRenderer.sprite = asteroidSprites[Random.Range(0, asteroidSprites.Length)];

        _rb.AddForce(new Vector2(Random.Range(0, pushForce), Random.Range(0, pushForce)));
        _rb.AddTorque(Random.Range(0, pushForce));

        spriteRenderer.gameObject.transform.localScale = Vector2.one * Random.Range(sizeVariation.x, sizeVariation.y);
    }

    public void PopinAfter(float seconds)
    {
        StartCoroutine(DelayPopin(seconds));
    }

    IEnumerator DelayPopin(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _animator.Play("popin");
    }
}
