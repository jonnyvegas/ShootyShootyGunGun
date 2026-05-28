using UnityEngine;

public interface IEnemy
{
    virtual public void SetTarget(Transform newTarget) { }
    virtual public void Init(Transform newTarget) { }
}
