using Mirror;
using UnityEngine;

namespace MirrorHelloWorld.Characters
{
    [RequireComponent(typeof(Animator))]
    public class NetworkAnimationController : NetworkBehaviour
    {
        private Animator animator;

        private void Awake() =>
            animator = GetComponent<Animator>();

    }
}