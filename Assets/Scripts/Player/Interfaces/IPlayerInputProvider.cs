using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Player.Interfaces
{
    public interface IPlayerInputProvider
    {
        public Vector2 GetMovementInput();
        
        public event Action OnShoot;  
    }
}