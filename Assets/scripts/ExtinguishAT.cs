using NodeCanvas.Framework;
using NodeCanvas.Tasks.Conditions;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ExtinguishAT : ActionTask {

        public GameObject Extinguisher;
		public GameObject fire;
        public BBParameter<Transform> ExtinguisherPosition;
        public BBParameter<NavMeshAgent> navAgent;
        public BBParameter<bool> hasExtinguisher;
		public float timer = 0;
		public float timerLimit = 5;
		bool puttingBackExtinguisher = false;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            navAgent.value.SetDestination(fire.transform.position);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (!fire.activeInHierarchy)
			{
				if (!puttingBackExtinguisher)
				{
                    navAgent.value.SetDestination(ExtinguisherPosition.value.position);
					puttingBackExtinguisher = true;
                }
				if (hasExtinguisher.value && !navAgent.value.pathPending && navAgent.value.remainingDistance < 0.2f)
				{
					Extinguisher.SetActive(true);
					hasExtinguisher.value = false;
					EndAction(true);
				}
			}
			else
			{
				if (hasExtinguisher.value && !navAgent.value.pathPending && navAgent.value.remainingDistance < 0.2f)
				{
					timer += 1 * Time.deltaTime;
				}

				if (timer >= timerLimit)
				{
					fire.SetActive(false);
				}
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