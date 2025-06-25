namespace CustomBottomSheet;

using System.ComponentModel;
using System.Windows.Input;

public class BottomsheetViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private Bottomsheet bottomsheet;
    public ICommand OKCommand { get; }

    public BottomsheetViewModel( Bottomsheet bottomsheet)
    {
        this.bottomsheet = bottomsheet;
        OKCommand = new Command(async () => await OK());
    }

    private async Task OK()
    {

        await bottomsheet.DismissAsync();
    }
}
