using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Monobehaviours
{
public class SetAnimation : MonoBehaviour
{
        public AnimatorOverrideController[] overrideControllers;
        public LabyrintheMovement overrider;

        public void Set(int value)
        {
            overrider.SetAnimations(overrideControllers[value]);
        }
}

}
