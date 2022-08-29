using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullBlock : MonoBehaviour
{
    [SerializeField] private GameObject _rightFence;
    [SerializeField] private GameObject _leftFence;
    [SerializeField] private GameObject _backFence;
    [SerializeField] private GameObject _forwardFence;
    


    public void Setup() 
    {
        DestroyFence(_rightFence);
        DestroyFence(_leftFence);
        DestroyFence(_backFence);
        DestroyFence(_forwardFence);
    }

    public void VerticalRoute() 
    {
        CreateFence(_rightFence);
        CreateFence(_leftFence);
    }

    public void RightTurn() 
    {
        CreateFence(_leftFence);
        CreateFence(_backFence);
    }

    public void LeftTurn() 
    {
        CreateFence(_rightFence);
        CreateFence(_backFence);
    }

    public void HorizontalRoute() 
    {
        CreateFence(_forwardFence);
        CreateFence(_backFence);
    }

    public void VerticalTurnRight() 
    {
        CreateFence(_forwardFence);
        CreateFence(_rightFence);
    }

    public void VerticalTurnLeft() 
    {
        CreateFence(_forwardFence);
        CreateFence(_leftFence);
    }

    private void CreateFence(GameObject fence) 
    {
        fence.SetActive(true);
    }

    private void DestroyFence(GameObject fence)
    {
        fence.SetActive(false);
    }


}
