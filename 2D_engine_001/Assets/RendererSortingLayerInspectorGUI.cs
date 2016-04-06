using System;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Reflection;

[CanEditMultipleObjects()]
[CustomEditor(typeof(RendererSortingLayer))]
public class RendererSortingLayerInspectorGUI : Editor
{
	/// <summary>
	/// Reference to our particle systems.
	/// </summary>
	private ParticleSystem[] particleSystems;

	/// <summary>
	/// Reference to our renderers.
	/// </summary>
	private Renderer[] renderers;

	/// <summary>
	/// The sorting layer names.
	/// </summary>
	private string[] sortingLayerNames;

	/// <summary>
	/// The index of the popup menu.
	/// </summary>
	private int popupMenuIndex;

	/// <summary>
	/// Whether to apply the changes to child particle systems.
	/// </summary>
	private bool willApplyToChildren = false;

	/// <summary>
	/// Used to detect changes in willApplyToChildren.
	/// </summary>
	private bool hasAppliedToChildren = false;


	#region Editor

	void OnEnable()
	{
		// Load the layers names.
		this.sortingLayerNames = GetSortingLayerNames(); 
		int sortingLayersCount = this.sortingLayerNames.Length;

		// Load the ParticleSystem components attached to this game object and any of its children.
		this.particleSystems = (target as RendererSortingLayer).gameObject.GetComponentsInChildren<ParticleSystem>();
		int particleSystemsCount = this.particleSystems.Length;

		// Load our renderers.
		this.renderers = new Renderer[particleSystemsCount];
		for (int i = 0; i < particleSystemsCount; i++)
		{
			renderers[i] = particleSystems[i].GetComponent<Renderer>();	
		}

		// Initialize the popupMenuIndex with the current Sort Layer name.	
		for (int i = 0; i < sortingLayersCount; i++)
		{
			if (this.sortingLayerNames[i] == this.particleSystems[0].GetComponent<Renderer>().sortingLayerName)
			{
				this.popupMenuIndex = i;
			}
		}
	}
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		if (this.renderers.Length == 0)
		{
			// No renderers. Do nothing.
			return;
		}

		// Display the Sorting Layer popup menu.
		this.popupMenuIndex = EditorGUILayout.Popup("Sorting Layer", this.popupMenuIndex, this.sortingLayerNames);

		// Display the order within a Sorting Layer.
		int newSortingLayerOrder = EditorGUILayout.IntField("Order in Layer", this.renderers[0].sortingOrder); 

		// Display whether to apply the changes to child particle systems.
		this.willApplyToChildren = EditorGUILayout.ToggleLeft("Apply to Children", willApplyToChildren);

		if (this.sortingLayerNames[popupMenuIndex] != this.renderers[0].sortingLayerName 
		    || newSortingLayerOrder != this.renderers[0].sortingOrder 
		    || this.willApplyToChildren != this.hasAppliedToChildren)
		{
			// A change has occurred.

			// Record the change in the Undo class.
			Undo.RecordObject(renderers[0], "Change Particle System Renderer Order"); 

			if (this.willApplyToChildren)
			{
				// Change sortingLayerName and sortingOrder in each Renderer.

				for (int i = 0; i < renderers.Length; i++)	
				{
					this.renderers[i].sortingLayerName = this.sortingLayerNames[popupMenuIndex];
					this.renderers[i].sortingOrder = newSortingLayerOrder;
				}
			}
			else
			{
				// Change sortingLayerName and sortingOrder in this game object's Renderer only.

				this.renderers[0].sortingLayerName = sortingLayerNames[popupMenuIndex];
				this.renderers[0].sortingOrder = newSortingLayerOrder;
			}

			// Update this custom editor.
			EditorUtility.SetDirty(renderers[0]);
		}
	}

	#endregion Editor


	#region Helpers

	/// <summary>
	/// Gets the sorting layer names.
	/// </summary>
	/// <returns>The sorting layer names.</returns>
	public string[] GetSortingLayerNames()
	{
		Type internalEditorUtilityType = typeof(InternalEditorUtility);	
		PropertyInfo sortingLayersProperty = internalEditorUtilityType.GetProperty("sortingLayerNames", BindingFlags.Static | BindingFlags.NonPublic);
		return (string[])sortingLayersProperty.GetValue(null, new object[0]);
	}

	#endregion Helpers
}
