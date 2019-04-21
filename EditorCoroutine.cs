using System.Collections;
using UnityEngine;

namespace UnityEditor
{
    public class EditorCoroutine
    {
        /// <summary>
        /// Use only "yield return null" to skip frame in editor
        /// </summary> 
        /// <param name="routineContainer">corotine still live while <paramref name="routineContainer"/> still exist </param>
        /// <returns></returns>
        public static EditorCoroutine Start(IEnumerator routine, UnityEngine.Object routineContainer)
        {
            Debug.Log("Start");
            EditorCoroutine coroutine = new EditorCoroutine(routine, routineContainer);
            coroutine.Start();
            return coroutine;
        }

        IEnumerator routine;
        UnityEngine.Object routineContainer;

        EditorCoroutine(IEnumerator routine, UnityEngine.Object routineContainer)
        {
            this.routine = routine;
            this.routineContainer = routineContainer;
        }

        void Start()
        {
            EditorApplication.update += Update;
        }

        public void Stop()
        {
            EditorApplication.update -= Update;
        }

        void Update()
        {
            if (routineContainer)
            {
                if (!routine.MoveNext())
                {
                    Stop();
                }
            }
            else
            {
                Stop();
            }
        }
    }
}