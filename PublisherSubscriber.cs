using System;

namespace DesignPattern.PublisherSubscriber;

// publisher send messages into EventCenter，and subscriber receive messages from EventCenter


class PublisherSubscriberPattern
{
    public static void Run()
    {
        EventCenter eventCenter = new();
        Publisher publisher = new(eventCenter);
        Subscriber subscriber = new(eventCenter, "message");
        publisher.PublishMessage("message", "hello, world");
    }
}


// Event center used as a bridge between publisher and subscriber
public class EventCenter
{
    // store event name and corresponding subscribers
    private Dictionary<string, Action<string>> subscribers = new();

    // subscribe event
    public void Subscribe(string eventName, Action<string> subscriber)
    {
        if (!subscribers.ContainsKey(eventName))
        {
            subscribers[eventName] = subscriber;
        }
        else
        {
            // add callback to the end of delegate chain
            subscribers[eventName] += subscriber;
        }
    }

    // unsubscribe event
    public void Unsubscribe(string eventName, Action<string> subscriber)
    {
        if (subscribers.ContainsKey(eventName))
        {
            subscribers[eventName] -= subscriber;
        }
    }

    // publish event
    public void Publish(string eventName, string message)
    {
        if (subscribers.ContainsKey(eventName))
        {
            subscribers[eventName]?.Invoke(message);
        }
    }

}

// publisher
public class Publisher
{
    private EventCenter eventCenter;

    public Publisher(EventCenter eventCenter)
    {
        this.eventCenter = eventCenter;
    }

    public void PublishMessage(string eventName, string message)
    {
        eventCenter.Publish(eventName, message);
    }
}

// subscriber
public class Subscriber
{
    public Subscriber(EventCenter eventCenter, string eventName)
    {
        eventCenter.Subscribe(eventName, ReceiveMessage);
    }

    private void ReceiveMessage(string message)
    {
        Console.WriteLine($"Received message: {message}");
    }
}