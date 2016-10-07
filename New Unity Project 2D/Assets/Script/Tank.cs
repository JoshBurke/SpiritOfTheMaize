using UnityEngine;
using System.Collections;

public class Tank : MonoBehaviour {
    private Rigidbody2D _rigidBody;
    [SerializeField]
    private float _moveSpeed = 3f;

    private void Awake()
    {

    }
    public void Drive(float forward)
    {
        _rigidBody.velocity = transform.up * forward * _moveSpeed;
    }

}
