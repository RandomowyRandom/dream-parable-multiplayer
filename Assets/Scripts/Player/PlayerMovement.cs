using System;
using Mirror;
using Player.Interfaces;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(IPlayerInputProvider))]
    public class PlayerMovement: NetworkBehaviour
    {
        [SerializeField] 
        private float _speed = 15f;
        
        private IPlayerInputProvider _inputProvider;
        private Rigidbody2D _rigidbody2D;

        private Vector2 _movementInput;
        
        private void Awake()
        {
            _inputProvider = GetComponent<IPlayerInputProvider>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        private void Update()
        {
            if(!isOwned)
                return;
            
            _movementInput = _inputProvider.GetMovementInput();
        }

        private void FixedUpdate()
        {
            if(!isOwned)
                return;
            
            _rigidbody2D.AddForce(_movementInput * (10f * _speed), ForceMode2D.Force);
        }
    }
}