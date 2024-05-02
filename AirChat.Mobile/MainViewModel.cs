using AirChat.API.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AirChat.Mobile;

public class MainViewModel : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler? PropertyChanged;

    public ICommand SendMessageCommand => new Command(async () =>
    {
        await SendMessageAsync();
    });


    public MainViewModel()
    {
        _client = new AirChatServiceClient(new HttpClient { BaseAddress = new Uri("https://127.0.0.1:7155") }); ;  
    }

    string _username;

    public string Username
    {
        get => _username;
        set
        {
            if (_username != value)
            {
                _username = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Username)));
            }
        }
    }

    string _message;
    private AirChatServiceClient _client;

    public string Message
    {
        get => _message;
        set
        {
            if (_message != value)
            {
                _message = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));
            }
        }
    }

    public async Task SendMessageAsync()
    {
        await _client.SendMessageAsync(Username, Message);
    }
}

