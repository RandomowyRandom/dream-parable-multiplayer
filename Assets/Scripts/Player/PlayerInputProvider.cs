using System;
using Player.Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerInputProvider: MonoBehaviour, IPlayerInputProvider
    {
        public event Action OnShoot;

        private void Update()
        {
            if(Input.GetMouseButton(0))
                OnShoot?.Invoke();
        }
        
        public Vector2 GetMovementInput()
        {
            return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        }
    }
}