using System.Windows.Input;

namespace DPGI_Lab7.Commands;

public class DataCommands
{
    public static RoutedCommand Delete { get; set; }
    public static RoutedCommand Create { get; set; }
    public static RoutedCommand Edit { get; set; }
    public static RoutedCommand Save { get; set; }
    public static RoutedCommand Find { get; set; }
    public static RoutedCommand Reload { get; set; }
    
    static DataCommands() {
        InputGestureCollection inputs = new InputGestureCollection();
        inputs.Add(new KeyGesture(Key.D, ModifierKeys.Control, "Ctrl+D"));
        Delete = new RoutedCommand("Delete", typeof(DataCommands), inputs);
        inputs.Add(new KeyGesture(Key.N, ModifierKeys.Control, "Ctrl+N"));
        Create = new RoutedCommand("Create", typeof(DataCommands),inputs);
        inputs.Add(new KeyGesture(Key.E, ModifierKeys.Control, "Ctrl+E"));
        Edit = new RoutedCommand("Edit", typeof(DataCommands), inputs);
        inputs.Add(new KeyGesture(Key.S, ModifierKeys.Control, "Ctrl+S"));
        Save = new RoutedCommand("Save", typeof(DataCommands),inputs);
        inputs.Add(new KeyGesture(Key.F, ModifierKeys.Control, "Ctrl+F"));
        Find = new RoutedCommand("Find", typeof(DataCommands),inputs);
        inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl+R"));
        Reload = new RoutedCommand("Reload", typeof(DataCommands),inputs);
    
    }

}