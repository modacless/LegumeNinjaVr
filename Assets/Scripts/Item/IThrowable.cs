using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IThrowable
{
    public void ThrowItem(Vector3 direction, float force);
    public void EnableItem();

}
