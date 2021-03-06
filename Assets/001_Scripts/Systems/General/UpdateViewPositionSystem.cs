﻿using UnityEngine;
using System.Collections;
using Entitas;

public class UpdateViewPositionSystem : IReactiveSystem, IEnsureComponents {
	#region IEnsureComponents implementation
	public IMatcher ensureComponents {
		get {
			return Matcher.View;
		}
	}
	#endregion

	#region IReactiveExecuteSystem implementation

	public void Execute (System.Collections.Generic.List<Entity> entities)
	{
		for (int i = 0; i < entities.Count; i++) {
			entities [i].view.go.transform.position = entities [i].position.value;
		}
	}

	#endregion

	#region IReactiveSystem implementation

	public TriggerOnEvent trigger {
		get {
			return Matcher.AllOf(Matcher.Position).OnEntityAdded ();
		}
	}

	#endregion


}
