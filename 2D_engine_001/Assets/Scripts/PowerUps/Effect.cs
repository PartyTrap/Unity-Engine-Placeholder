using UnityEngine;
using System.Collections;
using UnityEngine.Events;
 
public class Effect {

	public float length;
	public UnityAction action;
	public UnityAction endAction;


	public Effect(float length, UnityAction action, UnityAction endAction)
	{
		this.length = length;
		this.action = action;
		this.endAction = endAction;
	}
}

