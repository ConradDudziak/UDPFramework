using UnityEngine;

public class SingletonBehavior<T> : MonoBehaviour where T: MonoBehaviour {
	private static T inst;

	public static T instance {
		get {
			if (inst != null) {
				return inst;
			}

			inst = FindObjectOfType<T>();
			if (inst == null) {
				var go = new GameObject(typeof(T) + "_Singleton");
				inst = go.AddComponent<T>();
			}

			return inst;
		}
	}
}
