using Mirror;
using UnityEngine;

namespace MirrorHelloWorld
{
    public class PlayerController : NetworkBehaviour
    {
        [Header("Attributes")]
        [SerializeField] private float moveSpeed = 400.0f;

        [Header("Dependencies")]
        [SerializeField] private new Rigidbody2D rigidbody;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Animator animator;

        private readonly int moveAnimationParameter = Animator.StringToHash("IsMoving");

        private void Update()
        {
            if (isLocalPlayer)
                HandleInput();
        }

        private void HandleInput()
        {
            var horizontalAxis = Input.GetAxis("Horizontal");

            CmdMove(horizontalAxis);
        }

        #region Commands

        [Command]
        private void CmdMove(float horizontalInput)
        {
            rigidbody.velocity = new Vector2(horizontalInput * moveSpeed * Time.fixedDeltaTime, 0);

            var isMoving = horizontalInput != 0;

            if (isMoving)
            {
                var flipX = horizontalInput < 0;

                RpcFlipPlayer(flipX);
            }

            RpcMoveAnimation(isMoving);
        }

        #endregion

        #region Rpcs

        [ClientRpc]
        private void RpcFlipPlayer(bool flipX) => 
            spriteRenderer.flipX = flipX;

        [ClientRpc]
        private void RpcMoveAnimation(bool isMoving) =>
            animator.SetBool(moveAnimationParameter, isMoving);

        #endregion
    }
}