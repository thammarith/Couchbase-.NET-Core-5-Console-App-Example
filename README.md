# Couchbase with .NET Core 5 Console App using Dependency Injection

This repository contains a working example for using Couchbase with .NET Core 5 Console App using Dependency Injection

## Why do we need this?

If you read the [Couchbase documents](https://docs.couchbase.com/dotnet-sdk/current/howtos/managing-connections.html#connection-di) and other tutorials, you will find that most of them use ASP.NET which is a web server. However, if you are working on a console application like me, you'll find that the document is non-existent for this use case.

## The problems

On the documentation, you'll see this block of code. You may think it is easy! Then you use this code in yours and you'll find that you cannot access `Configuration`.

```c#
public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();

    services.AddCouchbase(Configuration.GetSection("Couchbase"));
    services.AddCouchbaseBucket<INamedBucketProvider>("");
}
```

Now, what do you do next? Using [this example](https://github.com/brantburnett/Couchbase.Net.StepByStep/blob/master/Couchbase.Net.StepByStep/Program.cs), you'll see you can use `.UseStartup<Startup>()` to chain the configuration during the host building process and we can use generic host that is available on .NET Core console app! Easy!

No.

[You cannot use `.UseStartup<Startup>()` with .NET Core console app (at least in the version 5).](https://stackoverflow.com/questions/41407221/startup-cs-in-a-self-hosted-net-core-console-application) There is a nice workaround to that on [Stackoverflow](https://stackoverflow.com/a/63603562/3769649).

## The solution

Using [the answer](https://stackoverflow.com/a/63603562/3769649) from Stackoverflow, we can achieve using `.UseStartup<Startup>()` in a console application. This repository shows you how.

## .NET Core 6

If you're using .NET Core 6, this might not be relevant. The 6th version should allow doing this by default. (See [#42258](https://github.com/dotnet/runtime/issues/42258), [#42364](https://github.com/dotnet/runtime/issues/42364) on dotnet/runtime)

## Contributing

Pull requests are welcomed.
