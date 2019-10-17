namespace Trophies.Donations
{
    using UnityEngine;

    public class ControlInformation : MonoBehaviour
    {
        public RectTransform recttransform;

        public void onShowInformation()
        {
            ForceScrollTop();
        }

        private void ForceScrollTop()
        {
            // Esperar un momento para la animacion de AR
            LeanTween.delayedCall(.1f, () => {
                var position = recttransform.localPosition;
                position.y = 0;

                recttransform.localPosition = position;
            });
        }
    }
}