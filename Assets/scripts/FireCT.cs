using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class FireCT : ConditionTask {

		public GameObject fire;

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if (fire.activeInHierarchy)
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