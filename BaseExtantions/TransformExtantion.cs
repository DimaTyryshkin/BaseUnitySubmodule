using UnityEngine;
using UnityEngine.Events;
using System.Collections;


public static class TransformExtantion
{
    /// <summary>
    ///   Transforms rect from local space to world space.
    /// </summary>
    public static Rect TransformRect(this Transform t, Rect rect)
    {
        Vector2 start = t.TransformPoint(rect.position);
        Vector2 end = t.TransformPoint(rect.max);

        Vector2 size = end - start;

        return new Rect(start, size);
    }


    public static T AddComponentAsChild<T>(this Transform parent, string name, bool localScaleToOne = true)
    {
        GameObject newGo = parent.AttachChild(new GameObject(name, typeof(T)));
        return newGo.GetComponent<T>();
    }



    //see  public static Object Instantiate(Object original, Transform parent, bool instantiateInWorldSpace);
    public static GameObject InstantiateAsChild(this Transform parent, string name, GameObject childPrefab, bool localScaleToOne = true)
    {
        var go = parent.InstantiateAsChild(childPrefab, localScaleToOne);
        go.name = name;
        return go;
    }

    public static GameObject InstantiateAsChild(this Transform parent, GameObject childPrefab, bool localScaleToOne = true)
    {
        var childGo = GameObject.Instantiate(childPrefab);
        //childGo.transform.localPosition = Vector3.zero;//Добавил возможно где-то что то отвалиться
        return parent.AttachChild(childGo, localScaleToOne);
    }

    public static GameObject AttachChild(this Transform parent, GameObject childGo, bool localScaleToOne = true)
    {
        Transform child = childGo.transform;
        child.SetParent(parent);
        if (localScaleToOne) child.localScale = Vector3.one;
        child.localPosition = Vector3.zero;

        return childGo;
    }

	public static void DestroyChildrensImmediate(this Transform transform)
	{
		int chindCount = transform.childCount;

		for (int i = chindCount - 1; i >= 0; i--)
		{
			Object.DestroyImmediate(transform.GetChild(i).gameObject);
		}
	}

	public static void DestroyChildrens(this Transform transform)
	{
		int chindCount = transform.childCount;

		for (int i = chindCount - 1; i >= 0; i--)
		{
			Object.Destroy(transform.GetChild(i).gameObject);
		}
	}

	public static void ForAllHierarchy(this Transform transform, UnityAction<Transform> action)
    {
        action(transform);

        for (int n = 0; n < transform.childCount; n++)
        {
            transform.GetChild(n).ForAllHierarchy(action);
        }
    }
}