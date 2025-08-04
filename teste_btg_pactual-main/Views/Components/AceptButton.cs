using System.Runtime.CompilerServices;

namespace ClientCRUD.Views.Components;
public class AceptButton : Button
{
    public AceptButton()
    { 
        BackgroundColor = Color.FromArgb("#1954A6"); 
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if (propertyName != null)
        {
            if (propertyName == nameof(IsEnabled)) 
                UpdateColors();

        }
    }

    private void UpdateColors()
    {
        if (IsEnabled)
        {
            BackgroundColor = Color.FromArgb("#1954A6");
            TextColor = Colors.White;
        }
        else
        {
            BackgroundColor = Colors.LightGray;
            TextColor = Colors.White;
        }
    }
}
