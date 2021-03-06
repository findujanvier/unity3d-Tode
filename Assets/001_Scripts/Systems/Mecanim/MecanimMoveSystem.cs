﻿using UnityEngine;
using System.Collections;
using Entitas;
public class MecanimMoveSystem : IReactiveSystem {
	#region IReactiveExecuteSystem implementation
	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		for (int i = 0; i < entities.Count; i++) {
			var e = entities [i];
			e.AddCoroutineTask (StartMoving (e));
		}
	}
	#endregion

	#region IReactiveSystem implementation
	public TriggerOnEvent trigger {
		get {
			return Matcher.Movable.OnEntityAddedOrRemoved ();
		}
	}
	#endregion

	IEnumerator StartMoving(Entity e){
		while (!e.hasView) {
			yield return null;
		}

		if (e.view.Anim != null) {
			var anims = e.view.Anim;
			if (e.isMovable) {
				for (int j = 0; j < anims.Length; j++) {
					if (!anims[j].GetCurrentAnimatorStateInfo(AnimLayer.Base).IsName(AnimState.Move)) {
						anims [j].CrossFade (AnimState.Move, AnimParam.CrossTime);
					}
				}
			} else {
				for (int j = 0; j < anims.Length; j++) {
					if (!anims [j].GetCurrentAnimatorStateInfo (AnimLayer.Base).IsName (AnimState.Idle)) {
						anims [j].CrossFade (AnimState.Idle, AnimParam.CrossTime);
					}
				}
			}
		}
	}
}
