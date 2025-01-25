using UnityEngine;

namespace Scripts
{

    /// Esto se usa para crear un patron de patrulla, son dos puntos en el que un enemigo se mueve

    public partial class PatrolPath : MonoBehaviour
    {
        /// Fin de la ruta de patrulla
        public Vector2 startPosition, endPosition;

        /// Se crea una instancia mover instance que se usa para mover una entidad por el camino a cierta velocidad

        public Mover CreateMover(float speed = 1) => new Mover(this, speed);

        void Reset()
        {
            startPosition = Vector3.left;
            endPosition = Vector3.right;
        }
    }
}