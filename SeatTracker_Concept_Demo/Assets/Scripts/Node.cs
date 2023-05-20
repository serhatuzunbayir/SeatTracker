using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private float _howManySecoWillTheCustomerWaitAtThisPoint;
    public float getHowManySec() {
        return this._howManySecoWillTheCustomerWaitAtThisPoint;
    }
}