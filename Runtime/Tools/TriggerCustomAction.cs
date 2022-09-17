namespace SingularityLab.Runtime.Tools
{
    public sealed partial class TriggerCustomAction
    {
        public CustomAction<bool> OnChange { get; } = new();
        public bool Value { get; private set; } = false;

        public void Set(in bool value)
        {
            if (Value == value) return;

            Value = value;

            OnChange.Invoke(Value);
        }

        public static implicit operator bool(TriggerCustomAction trigger) => trigger.Value;
    }
}
