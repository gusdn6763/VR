using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInterraction
{

    public void Drop()
    {
    }

    public virtual void Interactive()
    {
        print("UseItem");
    }

    public virtual void StopInteractive()
    {
        throw new System.NotImplementedException();
    }
}
