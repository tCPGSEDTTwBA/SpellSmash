using UnityEngine;
using UnityEngine.InputSystem;

public abstract class GameCommand
{
	GameObject gameObject;
	public abstract void Execute();
}
