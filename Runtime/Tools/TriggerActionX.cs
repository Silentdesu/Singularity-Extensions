namespace SingularityLab.Runtime.Tools
{
    public struct TriggerActionX
    {
        public ActionX<bool> OnChange { get; }

        public bool Value { get; private set; }

        public void Set(in bool value)
        {
            if (Value == value) return;

            Value = value;

            OnChange.InvokeSafe(Value);
        }

        public static implicit operator bool(TriggerActionX trigger) => trigger.Value;
    }
}
