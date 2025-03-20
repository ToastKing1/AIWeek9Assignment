using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class CookingAT : ActionTask {

		public BBParameter<Transform> stovePosition;
		public BBParameter<Transform> counterPosition;
		public BBParameter<NavMeshAgent> navAgent;
		public BBParameter<bool> hasMeal;
		public GameObject fire;
		public float timer = 0;
		public float timerLimit = 5;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			if (hasMeal.value == true)
				EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (!navAgent.value.pathPending && navAgent.value.remainingDistance < 0.2f)
			{
				timer += 1 * Time.deltaTime;

				if (timer > timerLimit)
				{
					float burnChance = Random.Range(0, 100);
					Debug.Log(burnChance);
					if (burnChance < 50)
					{
						hasMeal.value = false;
						fire.SetActive(true);
                        EndAction(true);
                    }
					else
					{
                        navAgent.value.SetDestination(counterPosition.value.position);
                        hasMeal.value = true;
						EndAction(true);
                    }
					timer = 0;
					
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