using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace OpenFlightVRC
{
    public class OpenFlightWind : UdonSharpBehaviour
    {
        [Tooltip("How strong the wind is, in m/s. 5 is a good point to start, usually it's good to set this to gentle values.")]
        public Vector3 windForce = new(0, 5, 0);

        private bool isPlayerInside = false;

        public override void OnPlayerTriggerEnter(VRCPlayerApi player)
        {
            if (!player.isLocal) return;
            isPlayerInside = true;
        }

        public override void OnPlayerTriggerStay(VRCPlayerApi player)
        {
            if (!player.isLocal) return;
            isPlayerInside = true;
        }

        public override void OnPlayerTriggerExit(VRCPlayerApi player)
        {
            if (!player.isLocal) return;
            isPlayerInside = false;
        }

        public Vector3 GetCurrentForce()
        {
            if (isPlayerInside) return windForce;
            return Vector3.zero;
        }
    }
}
