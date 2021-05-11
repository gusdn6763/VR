using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInterraction
{
    void Interactive();
    void StopInteractive();
    void Drop();
}

interface IRobotBehaviour
{
    void Grab(IInterraction interraction);

    void Drop(IInterraction interraction);
    void Introduce();
    void Support();
}

[System.Serializable]
public class RobotPath
{
    public string introduce;
    public Vector3 pathPos;
}

public partial class Robot : MonoBehaviour
{
    private Queue<IInterraction> useables = new Queue<IInterraction>();

    public Dictionary<string, RobotPath> path;
    public List<Color> partColor;
}

public partial class Robot : MonoBehaviour, IRobotBehaviour
{


    public void HandUse()
    {
        IInterraction interraction = useables.Peek();
        if (interraction as Armor)
        {
            interraction.Drop();
        }
        else if (interraction as Potion)
        {
            interraction.Interactive();
        }
    }

    public virtual void Grab(IInterraction interraction)
    {
        useables.Enqueue(interraction);
    }

    public virtual void Drop(IInterraction interraction)
    {
        useables.Dequeue();
    }

    public virtual void Introduce()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Support()
    {
        throw new System.NotImplementedException();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("IInterraction"))
        {
            Grab(collision.gameObject.GetComponent<IInterraction>());
        }
    }

}
