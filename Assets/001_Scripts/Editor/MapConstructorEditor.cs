﻿using UnityEngine;
using UnityEditor;
using System.IO;
using UnityEditorInternal;

[CustomEditor (typeof(MapConstructor))]
public class MapConstructorEditor : Editor {
	int tpCount;
	int wpCount;
	int wCount;

	bool toggleWP;
	bool toggleTP;
	bool toggleW;
	private ReorderableList wpROL;
	private ReorderableList tpROL;
	// private ReorderableList waves;
	private ReorderableList wgROL;
	private SerializedObject mc;
	private SerializedProperty _wayPoints;	
	private SerializedProperty _towerPoints;	
	private SerializedProperty _waves;	
		
	private MapConstructor mapConstructor;

	public GUIStyle guiTitleStyle {
		get {
			var guiTitleStyle = new GUIStyle (GUI.skin.label);
			guiTitleStyle.normal.textColor = Color.black;
			guiTitleStyle.fontStyle = FontStyle.Bold;
			guiTitleStyle.fontSize = 16;
			guiTitleStyle.fixedHeight = 30;
			guiTitleStyle.alignment = TextAnchor.MiddleCenter;
			return guiTitleStyle;
		}
	}
	void OnEnable () {
		mapConstructor = target as MapConstructor;
		mc = new SerializedObject(mapConstructor);
        
		_wayPoints = mc.FindProperty ("wayPoints");
		_towerPoints = mc.FindProperty ("towerPoints");
		_waves = mc.FindProperty("waves");
		
		if (EditorPrefs.HasKey("TWP"))
			toggleWP = EditorPrefs.GetBool("TWP");
		if (EditorPrefs.HasKey("TTP"))
			toggleTP = EditorPrefs.GetBool("TTP");
		if (EditorPrefs.HasKey("TW"))
			toggleW = EditorPrefs.GetBool("TW");

		wpROL = new ReorderableList (mc, _wayPoints, true, true, true, true);
		tpROL = new ReorderableList (mc, _towerPoints, true, true, true, true);
		// waves = new ReorderableList (mc, mc.FindProperty("waves"), true, true, true, true);
		wgROL = new ReorderableList (mc, mc.FindProperty("waveGroups"), true, true, true, true);	// test
		

		//
		wpROL.onRemoveCallback += OnRemoveCallBack;
		tpROL.onRemoveCallback += OnRemoveCallBack;
		// waves.onRemoveCallback += OnRemoveCallBack;
		wgROL.onRemoveCallback += OnRemoveCallBack;

		//
		wpROL.drawElementCallback += OnDrawWayPointElementCallBack;
		tpROL.drawElementCallback += OnDrawTowerPointElementCallBack;
		// waves.drawElementCallback += OnDrawWaveCallBack;
		wgROL.drawElementCallback += OnDrawWaveGroupElementCallBack;

		wpROL.drawHeaderCallback += OnDrawWayPointHeaderCallBack;
		tpROL.drawHeaderCallback += OnDrawTowerPointHeaderCallBack;
		wgROL.drawHeaderCallback += OnDrawWaveGroupHeaderCallBack;
	}

	void OnDisable () {
		if (wpROL != null) wpROL.onRemoveCallback -= OnRemoveCallBack;
		if (tpROL != null) tpROL.onRemoveCallback -= OnRemoveCallBack;
		// if (waves != null) waveGroups.onRemoveCallback -= OnRemoveCallBack;
		if (wgROL != null) wgROL.onRemoveCallback -= OnRemoveCallBack;
	}


	// TODO separate remove call back
	private void OnRemoveCallBack (ReorderableList _list) {
		if (EditorUtility.DisplayDialog("Warning!", "Are you sure?", "Yes", "No")) {
			ReorderableList.defaultBehaviours.DoRemoveButton (_list);
		}
	}
	
	private void OnDrawWayPointElementCallBack (Rect _rect, int _index, bool _isActive, bool _isFocused) {
		var wp = wpROL.serializedProperty.GetArrayElementAtIndex(_index);
		EditorGUI.PropertyField (
			new Rect(_rect.x, _rect.y, 120, EditorGUIUtility.singleLineHeight),
			wp.FindPropertyRelative("id"),
			GUIContent.none
		);

		EditorGUI.PropertyField (
			new Rect(_rect.x + 130 , _rect.y, 320, EditorGUIUtility.singleLineHeight),
			wp.FindPropertyRelative("wayPointPosition"),
			GUIContent.none
		);
	}

	private void OnDrawTowerPointElementCallBack (Rect _rect, int _index, bool _isActive, bool _isFocused) {
		var tp = tpROL.serializedProperty.GetArrayElementAtIndex(_index);
		EditorGUI.PropertyField (
			new Rect(_rect.x, _rect.y, 120, EditorGUIUtility.singleLineHeight),
			tp.FindPropertyRelative("id"),
			GUIContent.none
		);

		EditorGUI.PropertyField (
			new Rect(_rect.x + 130, _rect.y, 320, EditorGUIUtility.singleLineHeight),
			tp.FindPropertyRelative("wayPointPosition"),
			GUIContent.none
		);
	}

	// private void OnDrawWaveCallBack (Rect rect, int index, bool isActive, bool isFocused) {
	// 	var w = waves.serializedProperty.GetArrayElementAtIndex(index);
	// 	EditorGUI.PropertyField (
	// 		new Rect(rect.x, rect.y, 100, EditorGUIUtility.singleLineHeight),
	// 		w.FindPropertyRelative ("id"),
	// 		GUIContent.none
	// 	);
	// 	waveGroups.DoLayoutList ();
	// }
	private void OnDrawWaveGroupElementCallBack (Rect _rect, int _index, bool _isActive, bool _isFocused) {
		// var props = new [] {"type", "amount", "spawnInterval", "waveDelay"};
		// for (int i = 0; i < props.Length; i++)
		// {
		// 	var sProp = mc.FindProperty(props[i]);
		// 	var guiContent = new GUIContent ();
		// 	guiContent.text = sProp.displayName;
		// 	EditorGUILayout.PropertyField (sProp, guiContent);
		// }

		var wg = wgROL.serializedProperty.GetArrayElementAtIndex(_index);
		// GUIContent guiContent;
		EditorGUI.PropertyField (
			new Rect(_rect.x, _rect.y, 100, EditorGUIUtility.singleLineHeight),
			wg.FindPropertyRelative ("type"),
			GUIContent.none
		);

		EditorGUI.PropertyField (
			new Rect(_rect.x + 100, _rect.y, 60, EditorGUIUtility.singleLineHeight),
			wg.FindPropertyRelative ("pathId"),
			GUIContent.none
		);

		EditorGUI.PropertyField (
			new Rect(_rect.x + 160, _rect.y, 60, EditorGUIUtility.singleLineHeight),
			wg.FindPropertyRelative ("amount"),
			GUIContent.none
		);

		EditorGUI.PropertyField (
			new Rect(_rect.x + 220, _rect.y, 60, EditorGUIUtility.singleLineHeight),
			wg.FindPropertyRelative ("spawnInterval"),
			GUIContent.none
		);

		EditorGUI.PropertyField (
			new Rect(_rect.x + 280, _rect.y, 60, EditorGUIUtility.singleLineHeight),
			wg.FindPropertyRelative ("waveDelay"),
			GUIContent.none
		);
	}

	private void OnDrawWayPointHeaderCallBack(Rect rect){
		EditorGUI.LabelField (rect, "Way Point List");
	}
	private void OnDrawTowerPointHeaderCallBack(Rect rect){
		EditorGUI.LabelField (rect, "Tower Point List");
	}
	private void OnDrawWaveGroupHeaderCallBack(Rect rect){
		EditorGUI.LabelField (rect, "Wave Group List");
	}

	public override void OnInspectorGUI (){
		DrawDefaultInspector();	// test

		if(mapConstructor == null)
			return;
		
		mc.Update();

		wpCount = EditorPrefs.GetInt("WPC");
		tpCount = EditorPrefs.GetInt("TPC");
		wCount = EditorPrefs.GetInt("WC");
		
		EditorGUILayout.BeginVertical ("box");

		EditorGUILayout.Space();
		EditorGUILayout.LabelField ("MAP CONSTRUCTOR", guiTitleStyle);
		EditorGUILayout.Space();

		mapConstructor.mapId = EditorGUILayout.IntField ("Map Id", mapConstructor.mapId);
		mapConstructor.mapPos = EditorGUILayout.Vector3Field ("Map Pos", mapConstructor.mapPos);
				
		EditorGUILayout.Space();

		#region waypoint 
		EditorGUI.indentLevel++;
		toggleWP = EditorGUILayout.Foldout(toggleWP, "Way Point");
		EditorPrefs.SetBool("TWP", toggleWP);
		if (toggleWP) {
			EditorGUI.indentLevel++;
			EditorGUILayout.BeginHorizontal ();
			if (GUILayout.Button ("Create A New Way Point")) {
				mapConstructor.CreateNewWayPoint (wpCount);
				wpCount++;
				EditorPrefs.SetInt("WPC", wpCount);
			}
			if (GUILayout.Button ("Clear All Way Points")) {
				mapConstructor.ClearAllWayPoints();
				if (EditorPrefs.HasKey("WPC"))
					EditorPrefs.SetInt("WPC", 0);
			}
			EditorGUILayout.EndHorizontal();
			wpROL.DoLayoutList();
			EditorGUI.indentLevel--;
		}
		EditorGUI.indentLevel--;
		EditorGUILayout.Space();
		#endregion waypoint

		#region towerpoint
		EditorGUI.indentLevel++;
		toggleTP = EditorGUILayout.Foldout(toggleTP, "Tower Point");
		EditorPrefs.SetBool("TTP", toggleTP);
		if (toggleTP) {
			EditorGUI.indentLevel++;
			EditorGUILayout.BeginHorizontal ();
			if (GUILayout.Button ("Create A New Tower Point")) {
				mapConstructor.CreateNewTowerPoint(tpCount);
				tpCount++;
				EditorPrefs.SetInt("TPC", tpCount);
			}
			if (GUILayout.Button ("Clear All Tower Points")) {
				mapConstructor.ClearAllTowerPoints();
				if (EditorPrefs.HasKey("TPC"))
					EditorPrefs.SetInt("TPC", 0);
			}
			EditorGUILayout.EndHorizontal();
			tpROL.DoLayoutList();
			EditorGUI.indentLevel--;
		}
		EditorGUI.indentLevel--;
		EditorGUILayout.Space();
		#endregion towerpoint

		EditorGUI.indentLevel++;
		toggleW = EditorGUILayout.Foldout(toggleW, "Wave");
		EditorPrefs.SetBool("TW", toggleW);
		if (toggleW) {
			EditorGUI.indentLevel++;
			EditorGUILayout.BeginHorizontal ();
			if (GUILayout.Button ("Create A New Wave")) {
				mapConstructor.CreateNewWave(wCount);
				wCount++;
				EditorPrefs.SetInt("WC", wCount);
			}
			if (GUILayout.Button ("Clear All Waves")) {
				mapConstructor.ClearAllWaves();
				if (EditorPrefs.HasKey("WC"))
					EditorPrefs.SetInt("WC", 0);
			}
			EditorGUILayout.EndHorizontal ();
			
			// display wave data
			for(int i = 0; i < _waves.arraySize; i++){
				SerializedProperty wave = _waves.GetArrayElementAtIndex(i);
				SerializedProperty groups = wave.FindPropertyRelative("groups");

				EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField (wave.FindPropertyRelative("id").intValue.ToString());
				if(GUILayout.Button("Add New Group")) {
					groups.InsertArrayElementAtIndex(groups.arraySize);
					// groups.GetArrayElementAtIndex(groups.arraySize -1).intValue = 0;
				}
				if(GUILayout.Button("Clear All Groups")) {
					groups.ClearArray();
					// groups.GetArrayElementAtIndex(groups.arraySize -1).intValue = 0;
				}
				EditorGUILayout.EndHorizontal();
				
				for(int j = 0; j < groups.arraySize; j++){
					// groups.GetArrayElementAtIndex(groups.arraySize)
					wgROL.DoLayoutList();
				}
			}
			EditorGUI.indentLevel--;
		}
		EditorGUI.indentLevel--;
		EditorGUILayout.EndVertical ();

		#region map constructor window
		// TODO: make map constructor window
		EditorGUILayout.BeginVertical ();
		if (GUILayout.Button ("Open Map Constructor Window")) {
				Debug.Log ("open map constructor window");
		}
		EditorGUILayout.EndVertical ();
		#endregion map constructor window

		#region data
		// TODO: save and load map data to xml 
		EditorGUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Save")) {
			var text = mapConstructor.Save();
			WriteMapData(text);
			// TODO: 
			// - [x]confirm windows 
			// - kiem tra cac truong co empty khong
		}
		if (GUILayout.Button ("Load")) {
			mapConstructor.Load (LoadMapData());
			// TODO: confirm windows
		}
		if (GUILayout.Button ("Reset")) {
			mapConstructor.Reset();
			EditorPrefs.SetInt("WPC", 0);
			EditorPrefs.SetInt("TPC", 0);
			EditorPrefs.SetInt("WC", 0);

			mc.ApplyModifiedProperties();
			// TODO: confirm windows
		}
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.Space();
		#endregion data
		

		if (GUI.changed)
			EditorUtility.SetDirty(mapConstructor);

		mc.ApplyModifiedProperties();
	}
	
	public void OnSceneGUI (){
		if (mapConstructor == null)
			return;
		
		// EditorGUI.BeginChangeCheck();
        // Vector3 pos = Handles.PositionHandle(mapConstructor.mapPos, Quaternion.identity);
        // if (EditorGUI.EndChangeCheck()) {
        //     Undo.RecordObject(mapConstructor, "Move Map");
        //     mapConstructor.mapPos = pos;
        //     mapConstructor.Update ();
        // }
	
		// draw line between waypoint
		if(mapConstructor.wayPoints == null)
			return;
		
		
		EditorGUI.BeginChangeCheck();
		// if (_wayPoints.arraySize > 0) {
		// 	for (int i = 0; i < _wayPoints.arraySize; i++)
		// 	{
		// 		// var newPos = Handles.PositionHandle(mapConstructor.wayPoints[i].wayPointGo.transform.position, Quaternion.identity);
		// 		if (EditorGUI.EndChangeCheck()) {
		// 		// 	Undo.RecordObject(mapConstructor, "Move Wave Point");
		// 		// 	mapConstructor.wayPoints[i].wayPointGo.transform.position = newPos;
		// 		// 	mapConstructor.wayPoints[i].wayPointPosition = newPos;
		// 		// 	mapConstructor.Update ();
		// 		}
		// 		// var wp = _wayPoints.GetArrayElementAtIndex(i);
		// 		// mapConstructor.wayPoints[i].wayPointGo.transform.position = wp.FindPropertyRelative("wayPointPosition").vector3Value;
		// 	}
		// }
		// for( int i = 0; i < mapConstructor.wayPoints.Count; i++ )
		// {	
		// 	// mapConstructor.wayPoints[i].wayPointGo.transform.position = wp.FindPropertyRelative("wayPointGo").; 
		// 	// if(i < mapConstructor.wayPoints.Count - 1)
		// 	// 	Handles.DrawLine(mapConstructor.wayPoints[i].wayPointGo.transform.position, mapConstructor.wayPoints[i + 1].wayPointGo.transform.position );
		// }

		// // draw tower range circle
		// if(mapConstructor.towerPoints == null )
		// 	return;
		// for( int i = 0; i < mapConstructor.towerPoints.Count; i++ )
		// {
		// 	// Handles.DrawWireDisc(mapConstructor.towerPoints[i].towerPointGo.transform.position, Vector3.up, 1f);
		// }
	}

	#region database
	const string mapGroupDataDirectory = "Assets/Resources/Maps";	
	public void WriteMapData (string data) {

		var path = EditorUtility.SaveFilePanel("Save Map Data", mapGroupDataDirectory, "map_"+mapConstructor.mapId+".txt", "txt");
		
		if (!string.IsNullOrEmpty(path))
		{
			using (FileStream fs = new FileStream (path, FileMode.Create)) {
				using (StreamWriter writer = new StreamWriter(fs)) {
					writer.Write(data);
				}
			}
		}

		// refresh project database
		AssetDatabase.Refresh();
	}

	private string LoadMapData () {
		var path = EditorUtility.OpenFilePanel("Load Map Data", mapGroupDataDirectory, "txt");

		var reader = new WWW("file:///" + path);
		while(!reader.isDone){
		}

		return reader.text;
	}
	#endregion database
}
