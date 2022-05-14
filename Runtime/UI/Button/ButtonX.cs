using UnityEngine.Events;
using UnityEngine.UI;

namespace SingularityLab.Runtime.UI.CustomButton
{
    public sealed class ButtonX : Button
    {
        public void Subscribe(in UnityAction action)
        {
            onClick.AddListener(action);
        }

        public void Unsubscribe(in UnityAction action)
        {
            onClick.RemoveListener(action);
        }

        public void UnsubscribeAll()
        {
            onClick.RemoveAllListeners();
        }
    }
}