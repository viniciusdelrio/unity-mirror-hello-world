using UnityEngine;

namespace MirrorHelloWorld.Movements
{
    public interface IMovement
    {
        void Move(Vector2 direction);
    }
}