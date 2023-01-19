using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] private GameObject _canvasText;
    [SerializeField] private Animator _doorAnimator;

    private bool _isTrigger = false;


    private void Update()
    {
        if (_isTrigger && Input.GetKeyDown(KeyCode.E))
        {
            _doorAnimator.SetTrigger("open");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _isTrigger = true;
       _canvasText.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _isTrigger = false;
        _canvasText.SetActive(false);
    }
}
