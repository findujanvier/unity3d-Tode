﻿using UnityEngine;
using Entitas;
using Entitas.Unity.VisualDebugging;

public class GameManager : MonoBehaviour {
	public bool showDebug = true;
	public static bool debug;
	Systems _systems;

	void Awake() {
		#if !UNITY_EDITOR
		DIContainer.BindModules ();
		#endif
		var pools = Pools.sharedInstance;
		pools.SetAllPools ();

		debug = showDebug;
		_systems = CreateSystems(pools);
		_systems.Initialize();
	}

	void Update() {
		_systems.Execute();
	}

	Systems CreateSystems(Pools pools) {
		Systems systems;
		if(debug){
			systems = new DebugSystems ();
		}else{
			systems = new Systems ();
		}
		return systems
				//Map
				.Add(pools.pool.CreateSystem ( new TimeSystem () ))
				.Add(pools.pool.CreateSystem ( new CoroutineSystem () ))
				.Add(pools.pool.CreateSystem ( new CoroutineQueueSystem () ))
				.Add(pools.pool.CreateSystem ( new MapSystem () ))
				.Add(pools.pool.CreateSystem ( new LifeSystem () ))
				.Add(pools.pool.CreateSystem ( new GoldSystem () ))
				.Add(pools.pool.CreateSystem ( new PathSystem () ))
				.Add(pools.pool.CreateSystem ( new WaveSystem () ))
//
//				//Combat
				.Add(pools.pool.CreateSystem ( new CheckTargetSystem () ))
				.Add(pools.pool.CreateSystem ( new FindTargetSystem () ))
				.Add(pools.pool.CreateSystem ( new AttackOverTimeSystem () ))
				.Add(pools.pool.CreateSystem ( new AttackCooldownSystem () ))
				.Add(pools.pool.CreateSystem ( new HpRegenSystem () ))
//
//				//Tower
				.Add(pools.pool.CreateSystem ( new TowerInitSystem () ))
				.Add(pools.pool.CreateSystem ( new TowerUpgradeSystem () ))
				.Add(pools.pool.CreateSystem ( new TowerBuildSystem () ))
				.Add(pools.pool.CreateSystem ( new TowerStatsUpdateSystem () ))
				.Add(pools.pool.CreateSystem ( new TowerAttackSystem () ))
				.Add(pools.pool.CreateSystem ( new TowerSellSystem () ))
				.Add(pools.pool.CreateSystem ( new TowerResetSystem () ))
//
//				//Enemy
				.Add(pools.pool.CreateSystem ( new EnemyInitSystem () ))
				.Add(pools.pool.CreateSystem ( new EnemyMoveSystem () ))
				.Add(pools.pool.CreateSystem ( new EnemyReachEndSystem () ))
				.Add(pools.pool.CreateSystem ( new EnemyWatchHpSystem () ))
//				
//				//Projectile
				.Add(pools.pool.CreateSystem ( new ProjectileHomingSystem () ))
				.Add(pools.pool.CreateSystem ( new ProjectileThrowingSystem () ))
				.Add(pools.pool.CreateSystem ( new ProjectileLaserSystem () ))
				.Add(pools.pool.CreateSystem ( new ProjectileReachEndSystem () ))
//
//				//Skill
				.Add(pools.pool.CreateSystem ( new SkillInitSystem () ))
				.Add(pools.pool.CreateSystem ( new SkillCastSystem () ))
				.Add(pools.pool.CreateSystem ( new SkillEffectWatcherInitSystem () ))
				.Add(pools.pool.CreateSystem ( new SkillEffectWatcherSystem () ))
				.Add(pools.pool.CreateSystem ( new SkillUpgradeSystem () ))
//				
//				//View
				.Add(pools.pool.CreateSystem ( new TowerCreateViewSystem () ))
				.Add(pools.pool.CreateSystem ( new EnemyCreateViewSystem () ))
				.Add(pools.pool.CreateSystem ( new ProjectileCreateViewSystem () ))
				.Add(pools.pool.CreateSystem ( new ProjectileLaserViewSystem () ))
				.Add(pools.pool.CreateSystem ( new UpdateViewPositionSystem () ))
				.Add(pools.pool.CreateSystem ( new UpdateLookDirectionSystem () ))
				.Add(pools.pool.CreateSystem ( new UpdateViewLookAtSystem () ))
//
//				//View mecanim
				.Add(pools.pool.CreateSystem ( new MecanimAttackingSystem () ))
				.Add(pools.pool.CreateSystem ( new MecanimMoveSystem () ))
				.Add(pools.pool.CreateSystem ( new MecanimDyingSystem () ))
//
//				//View overlay bar
				.Add(pools.pool.CreateSystem ( new HeathBarViewSystem () ))
				.Add(pools.pool.CreateSystem ( new TowerProgressBarViewSystem () ))
//				
//				//General
				.Add(pools.pool.CreateSystem ( new EntityActiveSystem () ))
				.Add(pools.pool.CreateSystem ( new EntityDestroySystem () ))
			;
	}
}