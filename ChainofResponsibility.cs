using System;

namespace DesignPattern.ChainofResponsibility;

public static class ChainofResponsibilityPattern
{
    public static void Run()
    {
        Request req = new("check engine, gear box and car body");
        FilterChain chain = new();
        chain.Add(new EngineFilter())
            .Add(new GearboxFilter())
            .Add(new CarbodyFilter())
            .doFilter(req);
        Console.WriteLine("-----------request-----------response-----------");

        Request_1 request = new();
        request.reqMsg = "check engine, gear box and car body";
        Response_1 response = new();
        response.respMsg = "------response-----\n";

        FilterChain_1 chain_1 = new();
        chain_1.Add(new EngineFilter_1()).Add(new GearboxFilter_1()).Add(new CarbodyFilter_1());
        chain_1.doFilter(request, response);
        Console.WriteLine(response.respMsg);

    }
}

// Scenario 1: execute filter check and produce qualified car

class Request
{
    public string ReqMsg { set; get; }

    public Request(string requestMessage)
    {
        ReqMsg = requestMessage;
    }

}

// define something the process needs to do one by one
interface IFilter
{
    bool doFilter(Request request);
}

// concrete filters
class EngineFilter : IFilter
{
    public bool doFilter(Request request)
    {
        if (request.ReqMsg.Contains("engine"))
        {
            Console.WriteLine("---engine checking has done---");
        }
        return true;
    }
}

class GearboxFilter : IFilter
{
    public bool doFilter(Request request)
    {
        if (request.ReqMsg.Contains("gear"))
        {
            Console.WriteLine("---gear checking has done---");
        }
        return true;
    }
}

class CarbodyFilter : IFilter
{
    public bool doFilter(Request request)
    {
        if (request.ReqMsg.Contains("car body"))
        {
            Console.WriteLine("---car body has done----");
        }
        return true;
    }
}

class FilterChain : IFilter
{
    List<IFilter> filters = new List<IFilter>();

    // chain of responsibility, supporting chained calls
    public FilterChain Add(IFilter filter)
    {
        filters.Add(filter);
        return this;
    }
    // general form
    // public void Add(IFilter filter)
    // {
    //     filters.Add(filter);
    // }

    public bool doFilter(Request request)
    {
        foreach (IFilter f in filters)
        {
            if (!f.doFilter(request))
            {
                // stop when any filter failed
                return false;
            }
        }
        return true;
    }
}

// Scenario 2: just like dealing with requests and responses one by one in web development.
// request ----> filter 1 -----> filter 2 -------> filter 3
//               filter 1 <----- filter 2 <------- filter 3 <------ response


class Request_1
{
    public string? reqMsg;
}

class Response_1
{
    public string? respMsg;
}

interface IFilter_1
{
    void doFilter(Request_1 request, Response_1 response, FilterChain_1 chain);
}

class EngineFilter_1 : IFilter_1
{
    public void doFilter(Request_1 request, Response_1 response, FilterChain_1 chain)
    {
        // deal with request firstly
        if (request.reqMsg.Contains("engine"))
        {
            Console.WriteLine("----EngineFilter checking ----");
        }
        // passing the request to next filter by chain
        chain.doFilter(request, response);
        // deal with response
        response.respMsg += "----EngineFilter done----\n";
    }
}

class GearboxFilter_1 : IFilter_1
{
    public void doFilter(Request_1 request, Response_1 response, FilterChain_1 chain)
    {
        if (request.reqMsg.Contains("gear"))
        {
            Console.WriteLine("----Gear box checking----");
        }
        // passing the request to next filter by chain
        chain.doFilter(request, response);
        // deal with response
        response.respMsg += "----Gear box done----\n";
    }
}

class CarbodyFilter_1 : IFilter_1
{
    public void doFilter(Request_1 request, Response_1 response, FilterChain_1 chain)
    {
        if (request.reqMsg.Contains("car body"))
        {
            Console.WriteLine("----Car box checking----");
        }
        // passing the request to next filter by chain
        chain.doFilter(request, response);
        // deal with response
        response.respMsg += "----Car box done----\n";
    }
}

class FilterChain_1
{
    List<IFilter_1> filters = new();
    int filterIndex = 0;

    public FilterChain_1 Add(IFilter_1 filter)
    {
        filters.Add(filter);
        return this;
    }

    public void doFilter(Request_1 request, Response_1 response)
    {
        // if request chain finish, stop passing to next filter.
        if (filterIndex == filters.Count)
        {
            return;
        }
        IFilter_1 f = filters[filterIndex];
        filterIndex++;
        f.doFilter(request, response, this);
    }

}