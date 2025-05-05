using UnityEngine;

public interface IControllable : IMoveable
{
    public void Move(Vector2 direction);
}
