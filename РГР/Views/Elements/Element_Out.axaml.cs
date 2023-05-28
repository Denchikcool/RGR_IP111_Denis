using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;

namespace РГР.Views.Elements
{
    public class Element_Out : TemplatedControl
    {
        public static readonly StyledProperty<string> Value_ElProperty = AvaloniaProperty.Register<Element_Out, string>("Value_El");

        public string Value_El
        {
            get => GetValue(Value_ElProperty);
            set => SetValue(Value_ElProperty, value);
        }
    }
}
