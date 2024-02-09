using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject launchPoint;
    private void Awake()
    {
        Transform launchPointTrans = transform.Find("LaunchPoint"); //a
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false); //b
    }
    void OnMouseEnter()
    {
        print("Slingshot:OnMouseEnter()");

    }
    void OnMouseExit()
    {
        print("Slingshot: OnMouseExit()");
    }
}
