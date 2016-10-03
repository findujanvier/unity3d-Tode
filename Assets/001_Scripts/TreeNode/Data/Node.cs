﻿using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class Node <T> where T : class  {

	public T data;
	public Node<T> parent;
	public List<Node<T>> children;
	public int depth;

	public Node (T data){
		data = data;
		children = new List<Node<T>> ();
		depth = 0;
	}

	public Node <T> AddChild(T data){
		Node<T> n = new Node<T> (data);
		children.Add (n);
		n.parent = this;
		UpdateDepth (this);
		return this;
	}
		
	public Node <T> AddChild(Node<T> child){
		children.Add (child);
		child.parent = this;
		UpdateDepth (this);
		return this;
	}

	public Node <T> FindChildNodeByData (T data){
		return FindChildNodeByData (this, data);
	}

	void UpdateDepth(Node<T> parent){
		for (int i = 0; i < parent.children.Count; i++) {
			parent.children [i].depth = parent.depth + 1;
			UpdateDepth (parent.children [i]);
		}
	}

	Node <T> FindChildNodeByData(Node<T> node, T data){
		for (int i = 0; i < node.children.Count; i++) {
			if(node.children[i].data == data){
				return node.children [i];
			}
			var result = node.children [i].FindChildNodeByData (node.children [i], data);
			if(result != null){
				return result;
			}
		}
		return null;
	}
}
