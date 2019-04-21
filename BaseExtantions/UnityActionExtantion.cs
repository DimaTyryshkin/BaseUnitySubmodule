using UnityEngine.Events;

public static class UnityActionExtantion
{
	public static void TryInvoke(this UnityAction action)
	{
		if (action != null)
			action.Invoke();
	}

	public static void TryInvoke<T>(this UnityAction<T> action, T arg1)
	{
		if (action != null)
			action.Invoke(arg1);
	}

	public static void TryInvoke<T, T2>(this UnityAction<T, T2> action, T arg1, T2 arg2)
	{
		if (action != null)
			action.Invoke(arg1, arg2);
	}

	public static void TryInvoke<T, T2, T3>(this UnityAction<T, T2, T3> action, T arg1, T2 arg2, T3 arg3)
	{
		if (action != null)
			action.Invoke(arg1, arg2, arg3);
	}

	public static void TryInvoke<T, T2, T3, T4>(this UnityAction<T, T2, T3, T4> action, T arg1, T2 arg2, T3 arg3, T4 arg4)
	{
		if (action != null)
			action.Invoke(arg1, arg2, arg3, arg4);
	}
}