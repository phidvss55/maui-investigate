# iOS Build Instructions

## Quick Start

1. **Open Terminal** and navigate to project:
   ```bash
   cd /Users/dinhphi/Documents/Dev/dotnet/MauiApp1/MauiApp1
   ```

2. **Build for iOS Debug**:
   ```bash
   dotnet build -c Debug -f net10.0-ios
   ```

3. **Run on Simulator**:
   ```bash
   dotnet build -t:Run -c Debug -f net10.0-ios
   ```

## Alternative: Using Build Script

```bash
cd /Users/dinhphi/Documents/Dev/dotnet/MauiApp1
./build-ios.sh Debug
```

## Simulator Management

**List available simulators:**
```bash
xcrun simctl list devices available
```

**Boot a specific simulator:**
```bash
xcrun simctl boot "iPhone 15"
```

**Open Simulator app manually:**
- Open Xcode
- Xcode → Devices and Simulators → Select device → Boot

## Release Build

For App Store distribution:
```bash
dotnet build -c Release -f net10.0-ios
```

## Troubleshooting

### "dotnet: command not found"
- Install .NET 10.0 SDK from https://dotnet.microsoft.com/download

### "iOS SDK not found"
- Install Xcode: `xcode-select --install`
- Or install from App Store

### App crashes on launch
1. Check Xcode console for error details
2. Verify all imports are correct
3. Check MainPage.xaml bindings

### Build takes very long
- First build includes full iOS toolchain download (~2-3 GB)
- Subsequent builds are much faster
- Release builds are slower than Debug builds

---

**Your project is configured and ready to build!** ✨
