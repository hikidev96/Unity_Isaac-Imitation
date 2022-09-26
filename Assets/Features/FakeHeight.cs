using UnityEngine;

namespace II
{
    public class FakeHeight : MonoBehaviour
    {
        [SerializeField] private GameObject shadow;
        [SerializeField] private GameObject body;

        private Vector2 forwardDir = Vector2.right;
        private float horizontalPower;
        private float verticalPower;
        private float gravity = -9.8f;

        private void Update()
        {
            if (shadow.transform.localPosition.y > body.transform.localPosition.y) return;

            verticalPower += gravity * Time.deltaTime;

            body.transform.Translate(new Vector2(0.0f, verticalPower * Time.deltaTime), Space.Self);
            this.transform.Translate(forwardDir * horizontalPower * Time.deltaTime, Space.World);
        }
        
        public void Jump(float horizontalPower, float verticalPower)
        {
            this.forwardDir = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
            this.horizontalPower = horizontalPower;
            this.verticalPower = verticalPower;
        }
    }
}
