using UnityEngine;

namespace Scripts
{
    public partial class Patrol
    {

        /// Mover oscila entre el punto de inicio y final, se define por speed.

        public class Mover
        {
            Patrol path;
            float p = 0;
            float duration;
            float startTime;

            public Mover(Patrol path, float speed)
            {
                this.path = path;
                this.duration = (path.endPosition - path.startPosition).magnitude / speed;
                this.startTime = Time.time;
            }


            /// Obtener la posición del frame actual
            public Vector2 Position
            {
                get
                {
                    p = Mathf.InverseLerp(0, duration, Mathf.PingPong(Time.time - startTime, duration));
                    return path.transform.TransformPoint(Vector2.Lerp(path.startPosition, path.endPosition, p));
                }
            }
        }
    }
}