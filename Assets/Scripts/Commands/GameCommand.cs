using UnityEngine;

public abstract class GameCommand
{
	GameObject gameObject;
	public abstract bool Execute();
}
