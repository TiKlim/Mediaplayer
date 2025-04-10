﻿using System.Collections.ObjectModel;

namespace Mediaplayer2.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    
    public ObservableCollection<MainPageViewModel> Main { get; } = new();
}