using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class ExtinguishCT : ConditionTask {

        public GameObject fire;
        public BBParameter<NavMeshAgent> navAgent;
        public BBParameter<bool> hasExtinguisher;

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
            
        }

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            if (hasExtinguisher.value && !navAgent.value.pathPending && navAgent.value.remainingDistance < 0.2f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}