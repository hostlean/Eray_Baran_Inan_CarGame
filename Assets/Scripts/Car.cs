using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private RotationHolder rotationHolder;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material purpleCar;
    [SerializeField] private Material endPointPurple;


    private void OnDisable()
    {
        if (movement.IsActiveVehicle)
        {
            meshRenderer.material = purpleCar;
            if(rotationHolder.OnTarget)
                SetEndPointVisibility();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == movement.EndPoint.gameObject)
        {
            rotationHolder.OnTarget = true;
            if (movement.IsActiveVehicle)
            {
                if (ActiveCarWait()) return;
                GameManager.Instance.StartNextSequence();
            }
            else
            {
                if (PreviousCarWait()) return;
                GameManager.Instance.StartSameSequence();
            }
        }

        if (movement.IsActiveVehicle &&
            (other.gameObject.CompareTag("Block") || other.gameObject.CompareTag("Car")))
        {
            rotationHolder.OnTarget = false;
            GameManager.Instance.StartSameSequence();
        }
    }

    private bool PreviousCarWait()
    {
        if (CarManager.Instance.WaitForPreviousCars)
        {
            if (CarManager.Instance.ActiveCar.OnTarget)
            {
                UnsubscribeMethods();
                if (CarManager.Instance.CheckIfAllCarsAtTarget())
                {
                    GameManager.Instance.StartNextSequence();
                }

                return true;
            }
        }

        return false;
    }

    private bool ActiveCarWait()
    {
        if (CarManager.Instance.WaitForPreviousCars)
        {
            UnsubscribeMethods();
            if (CarManager.Instance.CheckIfAllCarsAtTarget())
            {
                GameManager.Instance.StartNextSequence();
            }

            return true;
        }

        return false;
    }

    private void SetEndPointVisibility()
    {
        if (CarManager.Instance.ShowPreviousCarTargets)
            movement.EndPoint.material = endPointPurple;
        else
            movement.EndPoint.enabled = false;
    }

    private void UnsubscribeMethods()
    {
        movement.UnsubscribeMethods();
        rotationHolder.UnsubscribeMethods();
    }
    
    
    
}
