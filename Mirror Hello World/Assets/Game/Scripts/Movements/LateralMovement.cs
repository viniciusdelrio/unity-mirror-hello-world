using UnityEngine;

namespace MirrorHelloWorld.Movements
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class LateralMovement : MonoBehaviour, IMovement
    {
        [SerializeField] 
        private float speed = 10.0f;

        private new Rigidbody2D rigidbody;

        public void Move(Vector2 direction) =>
            rigidbody.velocity = direction * speed * Time.deltaTime;

        private void Awake() =>
            rigidbody = GetComponent<Rigidbody2D>();
    }
}