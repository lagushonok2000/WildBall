using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private Rigidbody _bridgeRigidBody;
    [SerializeField] private GameObject _grid;

    private void OnCollisionEnter(Collision collision)
    {
        _bridgeRigidBody.isKinematic= false;
        _grid.SetActive(false);

    }
}
