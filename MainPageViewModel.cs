using System.ComponentModel;
using System.Windows.Input;

namespace CustomBottomSheet;

public class MainPageViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public ICommand OpenBottomSheetCommand { get; }

    public MainPageViewModel()
    {
        OpenBottomSheetCommand = new Command(async () => await OpenBottomSheet());
    }

    private async Task OpenBottomSheet()
    {
        var bottomSheet = new Bottomsheet();
        var viewModel = new BottomsheetViewModel(bottomSheet);
        bottomSheet.BindingContext = viewModel;
        await bottomSheet.ShowAsync();
    }
}
