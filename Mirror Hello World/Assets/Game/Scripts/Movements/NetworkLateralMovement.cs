using Mirror;
using UnityEngine;

namespace MirrorHelloWorld.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class NetworkLateralMovement : NetworkBehaviour, IMovement
    {
        [SerializeField] 
        private float speed = 10.0f;

        private new Rigidbody2D rigidbody;

        public void Move(Vector2 direction)
        {
            if (isLocalPlayer)
                CmdMove(direction);
        }

        [Command]
        private void CmdMove(Vector2 direction) =>
            rigidbody.velocity = new Vector2(direction.x * speed * Time.fixedDeltaTime, rigidbody.velocity.y);
            

        private void Awake() =>
            rigidbody = GetComponent<Rigidbody2D>();
    }
}