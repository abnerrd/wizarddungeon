using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeliveryInputState : CancellableState
{
    public override iInputState HandleInput(InputParameters parameters)
    {
        if (Input.GetMouseButton(0))
        {
            switch (parameters.DeliveryInput)
            {
                case Delivery.Direction:
                    {
                        parameters.VectorInput.Add(Input.mousePosition);
                        break;
                    }
                case Delivery.Unit:
                    {
                        var unitSelect = HandleUnitSelection();
                        if(unitSelect == null)
                        {
                            return base.HandleInput(parameters);
                        }

                        parameters.UnitInput.Add(unitSelect);
                        break;
                    }
                case Delivery.Location:
                    {
                        parameters.VectorInput.Add(Input.mousePosition);
                        break;
                    }
                case Delivery.Invalid:
                default:
                    {
                        break;
                    }
            }

            return new ShootState();
        }

        return base.HandleInput(parameters);
    }

    private iSelectableUnit HandleUnitSelection()
    {
        var clickPosition = Input.mousePosition;

        var bounds = GetViewportBounds(clickPosition, clickPosition);

        //  TODO this is gross, you're gross
        //  Problem is that we're not "raycasting w/ rect to find collided objects --
        //  instead, we use post-processed viewport positions that every possible selectable is then comparing to see if they were indeed selected.
        var allSelectables = MonoBehaviour.FindObjectsOfType<GameObject>().Select(g => g.GetComponent<iSelectableUnit>()).ToList();

        for(int i = 0; i < allSelectables.Count; ++i)
        {
            var current = allSelectables[i];
            if (current != null)
            {
                var viewportPosition = Camera.main.WorldToViewportPoint(current.GetPosition());
                if (bounds.Contains(viewportPosition))
                {
                    return current;
                }
            }
        }

        return null;
    }

    public static Bounds GetViewportBounds(Vector3 position1, Vector3 position2)
    {
        var v1 = Camera.main.ScreenToViewportPoint(position1);
        var v2 = Camera.main.ScreenToViewportPoint(position2 * 2f);
        var min = Vector3.Min(v1, v2);
        var max = Vector3.Max(v1, v2);
        min.z = Camera.main.nearClipPlane;
        max.z = Camera.main.farClipPlane;

        var bounds = new Bounds();
        bounds.SetMinMax(min, max);
        return bounds;
    }
}
