﻿using UnityEngine;

public enum EffectType{
	Root,
	Stun,
	MoveSpeedSlow,
	ArmorReduce
}

[System.Serializable]
 public class SkillEffect {
	public string skillId;
	public EffectType effectType;
	public float value;
	public float duration;

	public SkillEffect ()
 	{
 	}
 	
}
