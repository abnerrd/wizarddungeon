using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectingBoundsState : CancellableState
{
    public override iInputState HandleInput(InputParameters parameters)
    {
        if (Input.GetMouseButtonUp(0))
        {
            parameters.UnitInput.AddRange(HandleSelection(parameters.VectorInput[0]));
            return new MoveInputState();
        }

        return base.HandleInput(parameters);
    }

    private List<iSelectableUnit> HandleSelection(Vector3 startPosition)
    {
        //  TODO Calculate square area and get Selectables
        var endPosition = Input.mousePosition;

        Debug.Log($"Release: {startPosition} to {endPosition} ");

        var bounds = GetViewportBounds(startPosition, endPosition);

        //  TODO this is gross, you're gross
        //  Problem is that we're not "raycasting w/ rect to find collided objects --
        //  instead, we use post-processed viewport positions that every possible selectable is then comparing to see if they were indeed selected.
        var allSelectables = MonoBehaviour.FindObjectsOfType<GameObject>().Select(g => g.GetComponent<iSelectableUnit>()).ToList();
        var selectedUnits = new List<iSelectableUnit>();

        for (int i = 0; i < allSelectables.Count; ++i)
        {
            var current = allSelectables[i];
            if (current != null)
            {
                var viewportPosition = Camera.main.WorldToViewportPoint(current.GetPosition());
                if (bounds.Contains(viewportPosition))
                {
                    selectedUnits.AddExclusive(current);
                }
            }
        }

        Debug.Log($"UNITS: {selectedUnits.Count}");
        return selectedUnits;
    }

    //  https://hyunkell.com/blog/rts-style-unit-selection-in-unity-5/
    public static Bounds GetViewportBounds(Vector3 position1, Vector3 position2)
    {
        var v1 = Camera.main.ScreenToViewportPoint(position1);
        var v2 = Camera.main.ScreenToViewportPoint(position2);
        var min = Vector3.Min(v1, v2);
        var max = Vector3.Max(v1, v2);
        min.z = Camera.main.nearClipPlane;
        max.z = Camera.main.farClipPlane;

        var bounds = new Bounds();
        bounds.SetMinMax(min, max);
        return bounds;
    }
}
