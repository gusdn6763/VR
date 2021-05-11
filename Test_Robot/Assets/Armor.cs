using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Item
{
    public void Interactive()
    {
        print("UseItem");
    }

    public void StopInteractive()
    {
        throw new System.NotImplementedException();
    }
}
