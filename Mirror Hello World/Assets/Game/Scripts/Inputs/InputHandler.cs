using UnityEngine;
using UnityEngine.Events;

namespace MirrorHelloWorld.Inputs
{
    public class InputHandler : MonoBehaviour
    {
        public UnityEvent<Vector2> MoveInputEvent;

        private Vector2 moveInput;

        private void Update()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");

            moveInput = new Vector2(horizontalInput, verticalInput);
        }

        private void FixedUpdate() =>
            MoveInputEvent?.Invoke(moveInput);
    }
}