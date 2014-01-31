Registry
========

A replacement for switch statements using a dictionary object and generics.

Example:

```csharp
long id = GetId();
string option = GetOption();
switch (option)
{
   case "OptionA":
       return ExecuteOptionA(id);
   case "OptionB":
       return ExecuteOptionB(id);
   case "OptionC":
       return ExecuteOptionC(id);
   default:
       return ExecuteOptionA(id);
}
```

This code using the Registry library;

```csharp
long id = GetId();
string option = GetOption();
var options = new Registry<string, long, Func<long, string>>(ExecuteOptionA);

options.Register("OptionA", ExecuteOptionA);
options.Register("OptionB", ExecuteOptionB);
options.Register("OptionC", ExecuteOptionC);

return options.GetAction(option)(id);
```
