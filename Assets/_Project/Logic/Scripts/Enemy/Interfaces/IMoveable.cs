using UnityEngine;

public interface IMoveable
{
    public Rigidbody2D Rigidbody { get; set; }

    public bool IsFacingRight { get; set; }

    public void MoveTo(Vector2 velocity);

    public void AdjustFacingDirection(Vector2 velocity);
}
