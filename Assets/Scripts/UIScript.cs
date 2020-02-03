using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public ShipMovement ship;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        ship.OnShipDestroyed += OnShipDestroyed;
    }

    public void OnShipDestroyed()
    {
        animator.Play("Panel show");
    }

    public void OnRestart()
    {
        SceneManager.LoadScene("MainScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
