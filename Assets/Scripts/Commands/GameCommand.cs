using UnityEngine;

public abstract class GameCommand
{
	protected float moveDistance = 50f;
	public virtual void Move(Transform boxTrans) { }
	public abstract void Execute(Transform boxTrans, GameCommand command);
}
