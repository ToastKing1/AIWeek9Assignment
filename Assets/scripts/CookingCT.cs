using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Conditions {

	public class CookingCT : ConditionTask {

		public BBParameter<Transform> stovePosition;
		public BBParameter<NavMeshAgent> navAgent;
		public BBParameter<bool> hasMeal;
		public BBParameter<GameObject> servedMeal;
		public BBParameter<Transform> idlePosition;
		public GameObject fire;

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
			if (servedMeal.value.activeInHierarchy)
			{
				navAgent.value.SetDestination(idlePosition.value.position);
                return false;
            }
				
			if (hasMeal.value)
				return true;

			if (!fire.activeInHierarchy)
			{
				navAgent.value.SetDestination(stovePosition.value.position);
				
			}

			if (!navAgent.value.pathPending && navAgent.value.remainingDistance < 0.2f)
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