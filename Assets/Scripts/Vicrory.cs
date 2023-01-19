using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vicrory : MonoBehaviour
{
    [SerializeField] private GameObject _victoryCanvas;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            _victoryCanvas.SetActive(true);
            Time.timeScale= 0;
        }
    }
}
