using System;
using System.Security.Cryptography.X509Certificates;

namespace DesignPattern.Observer;

// Observer pattern

static class ObserverPattern
{
    public static void Run()
    {
        Subject pub = new Subject();
        Observer sub = new Observer();

        sub.Subscribe(pub);

        pub.RaiseCustomEvent("hello, world");
    }
}

// used as parameters passing to callbacks that Subject provide
public class CustomEventArgs : EventArgs
{
    public string Message
    {
        get;
    }

    public CustomEventArgs(string message)
    {
        Message = message;
    }
}

public class Subject
{
    // EventHander<TEventArgs> is a delegate type which takes two arguments: object and TEventArgs type values
    public event EventHandler<CustomEventArgs>? CustomEvent;

    protected virtual void OnCustomEvent(CustomEventArgs e)
    {
        CustomEvent?.Invoke(this, e);
    }

    // Subject will call this method when it publish message, and then all callbacks bound on CustomEvent will be called one by one.
    public void RaiseCustomEvent(string message)
    {
        OnCustomEvent(new CustomEventArgs(message));
    }

}

// Observer just need to provide callbacks, and then register it on Subject's event.
public class Observer
{
    public void Subscribe(Subject pub)
    {
        pub.CustomEvent += OnCustomEvent;
    }

    private void OnCustomEvent(object sender, CustomEventArgs e)
    {
        Type type = sender.GetType();
        Console.WriteLine($"Sender: {type.Name}");
        Console.WriteLine($"Message: {e.Message}");
    }
}