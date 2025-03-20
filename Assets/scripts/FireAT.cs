using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class FireAT : ActionTask {

		public GameObject Extinguisher;
		public GameObject fire;
		public BBParameter<Transform> ExtinguisherPosition;
		public BBParameter<NavMeshAgent> navAgent;
		public BBParameter<bool> hasExtinguisher;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			if (hasExtinguisher.value)
			{
				navAgent.value.SetDestination(fire.transform.position);
				EndAction(true);

			}
			else
			{
				navAgent.value.SetDestination(ExtinguisherPosition.value.position);
			}
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (hasExtinguisher.value)
			{
				EndAction(true);
			}
			if (!navAgent.value.pathPending && navAgent.value.remainingDistance < 0.2f)
			{
				Extinguisher.SetActive(false);
				hasExtinguisher.value = true;
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}