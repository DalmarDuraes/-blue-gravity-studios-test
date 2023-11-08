using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityStudios
{
     public class PlayerInputHandler : MonoBehaviour
     {
          public void HandleInteract()
          {
               EventManager.Trigger(PlayerEvents.PlayerPressedNpcInteraction);
          }
     }
}
