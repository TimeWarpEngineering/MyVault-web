# Clipboard

Once navigation.clopboard becomes a standard and Edge implements it we can update this to just use it.



navigation.clipboard doesn't work in Edge

```Typescript
const nav = <any>window.navigator;
nav.clipboard.writeText("Test");
```

I thought it would be as easy as :

```csharp
protected async Task CopyToClipboardAsync ()
    {
      await JSRuntime.Current.InvokeAsync<object>("navigator.clipboard.writeText", ReceiveAddress);
    }
```

but not to be, yet.

# Add ClipboardInterop

So we will use js interop and use the same concept that docFX uses for the Copy to Clipboard functionality