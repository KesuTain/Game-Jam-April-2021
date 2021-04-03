using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.EditorTools;
using UnityEditor;

[EditorTool("Custom Snap Move", typeof(CustomSnap))]
public class CustomSnappingTool : EditorTool
{
	public Texture2D toolIcon;

	private Transform oldTarget;
	CustomSnapPoint[] allPoints;
	CustomSnapPoint[] targetPoints;

	public override GUIContent toolbarIcon
	{
		get
		{
			return new GUIContent
			{
				image = toolIcon,
				text = "Custom Snap Move Tool",
				tooltip = "Custom Snap Move Tool - nice tool"
			};
		}
	}

	public override void OnToolGUI(EditorWindow window)
	{
		Transform targetTransform = ((CustomSnap)target).transform;

		if (targetTransform!=oldTarget)
		{
			allPoints = FindObjectsOfType<CustomSnapPoint>();
			targetPoints = targetTransform.GetComponentsInChildren<CustomSnapPoint>();
		}

		EditorGUI.BeginChangeCheck();
		Vector3 newPosition = Handles.PositionHandle(targetTransform.position, Quaternion.identity);

		if (EditorGUI.EndChangeCheck())
		{
			Undo.RecordObject(targetTransform, "Move with Snap Tool");
			MoveWithSnapping(targetTransform, newPosition);
		}
	}

	private void MoveWithSnapping(Transform targetTransform, Vector3 newPosition)
	{
		Vector3 bestPosition = newPosition;
		float closestDistance = float.PositiveInfinity;

		foreach (CustomSnapPoint point in allPoints)
		{
			if (point.transform.parent == targetTransform)
				continue;

			foreach (CustomSnapPoint ownPoint in targetPoints)
			{
				Vector3 targetPos = point.transform.position - (ownPoint.transform.position - targetTransform.position);
				float distance = Vector3.Distance(targetPos, newPosition);

				if (distance < closestDistance)
				{
					closestDistance = distance;
					bestPosition = targetPos;
				}
			}
		}

		if (closestDistance < 0.5f)
		{
			targetTransform.position = bestPosition;
		} else
		{
			targetTransform.position = newPosition;
		}
	}
}
