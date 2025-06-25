using The49.Maui.BottomSheet;
using System;
using Microsoft.Maui.Controls;

namespace CustomBottomSheet.Custom;

public class CustomBottomsheet : BottomSheet
{
    public static CustomBottomsheet CurrentBottomSheet { get; private set; }

    private bool isInitialized = false;
    private bool isDisposed = false;

    public CustomBottomsheet()
    {
        InitializeBottomSheet();
    }

    private void InitializeBottomSheet()
    {
        if (isInitialized || isDisposed) return;

        this.Showing += OnBottomSheetShowing;
        this.Shown += OnBottomSheetShown;
        this.Dismissed += OnBottomSheetDismissed;

        isInitialized = true;
    }

    private void OnBottomSheetShowing(object sender, EventArgs e)
    {
        if (isDisposed) return;

        if (CurrentBottomSheet != null && CurrentBottomSheet != this)
        {
            CurrentBottomSheet.CleanupBottomSheet();
        }

        CurrentBottomSheet = this;

        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            this.IsCancelable = true;
            this.HasBackdrop = true;
            HandleAndroidOpacityForBottomSheet(0.8);
        }
    }

    private void OnBottomSheetShown(object sender, EventArgs e)
    { }

    private void OnBottomSheetDismissed(object sender, DismissOrigin dismissOrigin)
    {
        CleanupBottomSheet();
    }
    private void CleanupBottomSheet()
    {
        if (isDisposed) return;

        if (DeviceInfo.Platform == DevicePlatform.Android)
        {
            HandleAndroidOpacityForBottomSheet(1.0);
        }

        if (CurrentBottomSheet == this)
        {
            CurrentBottomSheet = null;
        }

        ResetBottomSheetState();
    }

    private void ResetBottomSheetState()
    {

        if (!isDisposed && DeviceInfo.Platform == DevicePlatform.Android)
        {
            this.IsCancelable = true;
            this.HasBackdrop = true;
        }
    }

    public void ManualCleanup()
    {
        if (isDisposed) return;

        CleanupBottomSheet();
        DisposeBottomSheet();
    }

    private void DisposeBottomSheet()
    {
        if (isDisposed) return;

        if (isInitialized)
        {
            this.Showing -= OnBottomSheetShowing;
            this.Shown -= OnBottomSheetShown;
            this.Dismissed -= OnBottomSheetDismissed;
        }

        CleanupBottomSheet();

        isDisposed = true;
        isInitialized = false;
    }

    ~CustomBottomsheet()
    {
        DisposeBottomSheet();
    }
    public static void HandleAndroidOpacityForBottomSheet(double opacity)
    {
#if ANDROID
        var currentPageView = Shell.Current?.CurrentPage;

        if (currentPageView != null)
        {
            currentPageView.Opacity = opacity;
        }
        else
        {
            var currentPageOutsideShell = Application.Current.MainPage?.Navigation?.NavigationStack.LastOrDefault();

            if (currentPageOutsideShell != null)
            {
                currentPageOutsideShell.Opacity = opacity;
            }
        }
#endif
    }
}