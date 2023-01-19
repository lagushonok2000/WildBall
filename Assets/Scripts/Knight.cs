using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    [SerializeField] private Animator _knightAnimator;
    [SerializeField] private Collider _knightCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            _knightAnimator.SetTrigger("active");
            _knightCollider.enabled= false;
        }
    }
}
