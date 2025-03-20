using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Conditions {

	public class ServeCT : ConditionTask {

		public BBParameter<Transform> counterPosition;
		public BBParameter<NavMeshAgent> navAgent;
		public BBParameter<bool> hasMeal;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            if (hasMeal.value == true && !navAgent.value.pathPending && navAgent.value.remainingDistance < 0.2f)
            {
				hasMeal.value = false;
                return true;
            }
            else
            {
                return false;
            }
		}
	}
}