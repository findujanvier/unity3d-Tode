﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class TreeEditorUtils {

	public static void CreateTree (TreeType _treeType, string _treeName) {
		
		TreeGUI currentTree = new TreeGUI(_treeType, _treeName);

		if (currentTree != null) {
			TreeEditorWindow currentWindow = (TreeEditorWindow)EditorWindow.GetWindow <TreeEditorWindow> ();
			if (currentWindow != null) {
				currentWindow.currentTree = currentTree;
			}

			// add root node
			AddRootNode (currentTree, new Vector2(50f, 50f));

		} else {
			EditorUtility.DisplayDialog ("Tree Node Message", "Unable to create new tree", "OK");
		}

	}

	public static void SaveTree (TreeGUI _currentTree) {
		BinaryFormatter bf = new BinaryFormatter ();
		if (!Directory.Exists (Application.dataPath + TreeNodeConstants.DatabasePath + _currentTree.treeData.treeType.ToString())) {
			Directory.CreateDirectory (Application.dataPath + TreeNodeConstants.DatabasePath + _currentTree.treeData.treeType.ToString());
		}
		FileStream file = File.Create (Application.dataPath + TreeNodeConstants.DatabasePath + _currentTree.treeData.treeType.ToString() + "/" + _currentTree.treeData.treeName + TreeNodeConstants.DataExtension);
		bf.Serialize (file, _currentTree.treeData);
		file.Close ();
		AssetDatabase.Refresh ();
	}



	public static  void LoadTree () {
		Tree<string> treeData = null;
		string treePath = EditorUtility.OpenFilePanel ("Load Tree", Application.dataPath + TreeNodeConstants.DatabasePath, "txt");
		int appPathLength = Application.dataPath.Length;
		string finalPath = treePath.Substring (appPathLength - TreeNodeConstants.DataExtension.Length - 1);

		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = File.Open (finalPath, FileMode.Open);
		treeData = (Tree<string>) bf.Deserialize (file);
		file.Close ();
		if (treeData != null) {
			TreeEditorWindow currentWindow = (TreeEditorWindow)EditorWindow.GetWindow<TreeEditorWindow> ();
			if (currentWindow != null) {
				TreeGUI currentTree = new TreeGUI(treeData.treeType, treeData.treeName);
				currentTree.treeData = treeData;
				currentWindow.currentTree = currentTree;
			}
		} else {
			EditorUtility.DisplayDialog ("Tree Node Message", "Unable to load selected tree!", "OK");
		}
	}

	public static void UnloadTree () {
		TreeEditorWindow currentWindow = (TreeEditorWindow)EditorWindow.GetWindow <TreeEditorWindow> ();
		if (currentWindow != null) {
			currentWindow.currentTree = null;
		}
	}

	public static void AddRootNode (TreeGUI _currentTree,  Vector2 _position) {
		if (_currentTree != null) {
			var nodeRect = new Rect (_position.x, _position.y, 100f, 40f);
			var newNode = new NodeGUI (true, new Node<string> (_currentTree.existIds [0]), nodeRect, null, _currentTree);

			_currentTree.treeData.Root = newNode.nodeData;
		}
	}

	public static void AddNode (TreeGUI _currentTree,  Vector2 _position) {
		if (_currentTree != null) {
			var nodeRect = new Rect (_position.x, _position.y, 100f, 40f);
			var newNode = new NodeGUI (false, new Node<string> (_currentTree.existIds [0]), nodeRect, null, _currentTree);
		}
	}

	public static void RemoveNode (NodeGUI _node) {
		for (int i = 0; i < _node.nodeData.children.Count; i++) {
			_node.nodeData.children[i].parent = null;
		}
		if (_node.nodeData.parent != null)
			_node.nodeData.parent.children.Remove (_node.nodeData);
		_node.nodeData.parent = null;
		_node.nodeData = null;

		for (int i = 0; i < _node.childNodes.Count; i++) {
			_node.childNodes[i].parentNode = null;
		}
		_node.currentTree.nodes.Remove (_node);
	}

	public static void RemoveParentNode (NodeGUI _node) {
		_node.parentNode.nodeData.children.Remove(_node.nodeData);
		// remove this node's parent data
		_node.nodeData.parent = null;

		_node.parentNode = null;
	}

//	public static void DrawGrid (Rect _viewRect, float _gridSpacing, float _gridOpacity, Color _gridColor) {
//		int widthDivs = Mathf.CeilToInt (_viewRect.width - _gridSpacing);
//		int heightDivs = Mathf.CeilToInt (_viewRect.height - _gridSpacing);
//		Handles.BeginGUI ();
//		Handles.color = new Color (_gridColor.r, _gridColor.g, _gridColor.b, _gridOpacity);
//
//		for (int x = 0; x < widthDivs; x++) {
//			Handles.DrawLine (new Vector3 (_gridSpacing * x, 0f, 0f), new Vector3 (_gridSpacing * x, _viewRect.height, 0f));
//		}
//
//		for (int y = 0; y < heightDivs; y++) {
//			Handles.DrawLine (new Vector3 (0f, _gridSpacing * y, 0f), new Vector3 (_viewRect.width, _gridSpacing * y, 0f));
//		}
//		Handles.color = Color.white;
//		Handles.EndGUI ();
//	}

	public static string UppercaseFirst(string s)
	{
		// Check for empty string.
		if (string.IsNullOrEmpty(s))
		{
			return string.Empty;
		}
		// Return char and concat substring.
		return char.ToUpper(s[0]) + s.Substring(1);
	}
}
