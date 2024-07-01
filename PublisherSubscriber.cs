using System;
using System.Security.Cryptography.X509Certificates;

namespace DesignPattern.publisherSubscriber;

// publisher and subscriber pattern

static class publisherSubscriber
{
    public static void Run()
    {
        publisher pub = new publisher();
        subscriber sub = new subscriber();

        sub.subscribe(pub);

        pub.RaiseCustomEvent("hello, world");
    }
}

// used as parameters passing to callbacks that subscribers provide
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

public class publisher
{
    // EventHander<TEventArgs> is a delegate type which takes two arguments: object and TEventArgs type values
    public event EventHandler<CustomEventArgs>? CustomEvent;

    protected virtual void OnCustomEvent(CustomEventArgs e)
    {
        CustomEvent?.Invoke(this, e);
    }

    // publisher will call this method when it publish message, and then all callbacks bound on CustomEvent will be called one by one.
    public void RaiseCustomEvent(string message)
    {
        OnCustomEvent(new CustomEventArgs(message));
    }

}

// Subscriber just need to provide callbacks, and then register it on publisher's event.
public class subscriber
{
    public void subscribe(publisher pub)
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