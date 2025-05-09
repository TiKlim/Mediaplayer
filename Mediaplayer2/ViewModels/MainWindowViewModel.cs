﻿using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Mail;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using Avalonia.Controls;
using Mediaplayer2.Views;
using ReactiveUI;
using Splat;

namespace Mediaplayer2.ViewModels;

public class MainWindowViewModel : ViewModelBase, IScreen
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    
    public RoutingState Router { get; }

    private bool _isSelected;

    private string _selectedClasses;

    private string _background;

    //private object _currentView;

    public string SelectedClasses
    {
        get => _selectedClasses;
        set => this.RaiseAndSetIfChanged(ref _selectedClasses, value);
    }

    public string Background
    {
        get => _background;
        set => this.RaiseAndSetIfChanged(ref _background, value);
    }

    /*public object CurrentView
    {
        get => _currentView;
        set => this.RaiseAndSetIfChanged(ref _currentView, value);
    }*/
    
    public ReactiveCommand<Unit, IRoutableViewModel> ToHomePageCommand { get; }
    
    public ReactiveCommand<Unit, IRoutableViewModel> ToMusicPageCommand { get; }
    
    public ReactiveCommand<Unit, IRoutableViewModel> ToVideoPageCommand { get; }
    
    public ReactiveCommand<Unit, IRoutableViewModel> ToPlaylistPageCommand { get; }
    
    public ReactiveCommand<Unit, IRoutableViewModel> ToSettingsPageCommand { get; }
    
    //public ReactiveCommand<Unit, Unit> ToAudioEditPageCommand { get; }

    public MainWindowViewModel()
    {
        Router = new RoutingState();
        
        Router.Navigate.Execute(new MainPageViewModel(this)).ObserveOn(RxApp.MainThreadScheduler);
        
        ToHomePageCommand = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new MainPageViewModel(this)).ObserveOn(RxApp.MainThreadScheduler));
        ToMusicPageCommand = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new MusicPageViewModel(this)).ObserveOn(RxApp.MainThreadScheduler));
        ToVideoPageCommand = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new VideoPageViewModel(this)).ObserveOn(RxApp.MainThreadScheduler));
        ToPlaylistPageCommand = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new PlaylistPageViewModel(this)).ObserveOn(RxApp.MainThreadScheduler));
        ToSettingsPageCommand = ReactiveCommand.CreateFromObservable(() => Router.Navigate.Execute(new SettingsPageViewModel(this)).ObserveOn(RxApp.MainThreadScheduler));

        if (_isSelected) 
        {
            Background = "#f7d2d3";
            SelectedClasses = "SelectedPage";
        }
        else
        {
            Background = "Transparent";
            SelectedClasses = "LeftPanel";
        }
    }
    
    private void HomePage()
    {
        //CurrentView = new MainPageView();
        _isSelected = true; //???
    }

    /*private void MusicPage()
    {
        CurrentView = new MusicPageView();
    }*/

    private IObservable<IRoutableViewModel> ToMusic()
    {
        return Router.Navigate.Execute(new MusicPageViewModel(this));
    }
    
    private void VideoPage()
    {
        //CurrentView = new VideoPageView();
    }
    
    private void PlaylistPage()
    {
        //CurrentView = new PlaylistPageView();
    }
    
    private void SettingsPage()
    {
        //CurrentView = new SettingsPageView();
    }

    private void AudioEditPage()
    {
        //CurrentView = new EditAudioView();
    }
}